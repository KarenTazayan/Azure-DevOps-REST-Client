using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();

var app = builder.Build();

app.MapPost("/webhooks/azuredevops/git-repo-created",
    async (
        JsonDocument payload,
        IConfiguration configuration,
        IHttpClientFactory httpClientFactory,
        CancellationToken cancellationToken) =>
    {
        var root = payload.RootElement;

        var eventType = root.GetProperty("eventType").GetString();
        if (!string.Equals(eventType, "git.repo.created", StringComparison.OrdinalIgnoreCase))
        {
            return Results.BadRequest(new { error = "Unexpected event type." });
        }

        var repository = root.GetProperty("resource").GetProperty("repository");
        var initiatedBy = root.GetProperty("resource").GetProperty("initiatedBy");

        var repoId = repository.GetProperty("id").GetString();
        var repoName = repository.GetProperty("name").GetString();
        var projectId = repository.GetProperty("project").GetProperty("id").GetString();
        var initiatedByStorageKey = initiatedBy.GetProperty("id").GetString();
        var initiatedByDisplayName = initiatedBy.GetProperty("displayName").GetString();
        var initiatedByUniqueName = initiatedBy.GetProperty("uniqueName").GetString();

        if (string.IsNullOrWhiteSpace(repoId) ||
            string.IsNullOrWhiteSpace(projectId) ||
            string.IsNullOrWhiteSpace(initiatedByStorageKey))
        {
            return Results.BadRequest(new
            {
                error = "Missing repository id, project id, or initiatedBy id."
            });
        }

        var organization = configuration["AzureDevOps:Organization"];
        var pat = configuration["AzureDevOps:Pat"];

        if (string.IsNullOrWhiteSpace(organization) || string.IsNullOrWhiteSpace(pat))
        {
            return Results.Problem("AzureDevOps:Organization or AzureDevOps:Pat is not configured.");
        }

        using var client = httpClientFactory.CreateClient();

        var basic = Convert.ToBase64String(Encoding.ASCII.GetBytes($":{pat}"));
        client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Basic", basic);

        // 1. Resolve descriptor from storage key
        var url =
            $"https://vssps.dev.azure.com/{organization}/_apis/identities" +
            $"?identityIds={Uri.EscapeDataString(initiatedByStorageKey)}" +
            $"&api-version=7.1";

        using var response = await client.GetAsync(url, cancellationToken);
        var body = await response.Content.ReadAsStringAsync(cancellationToken);

        response.EnsureSuccessStatusCode();

        using var json = JsonDocument.Parse(body);
        var descriptor = json.RootElement.GetProperty("value")[0].GetProperty("descriptor").GetString();

        if (string.IsNullOrWhiteSpace(descriptor))
        {
            throw new InvalidOperationException("Descriptor not found.");
        }

        // 2. Deny Delete or disable repository
        // Git repo security namespace
        const string gitRepositoriesNamespaceId = "2e9eb7ed-3c0a-47d4-87c1-0ffdd275fd87";
        // Token format for repo permissions
        var token = $"repoV2/{projectId}/{repoId}";

        // Delete repository / disable repository bit
        const int denyDeleteOrDisableRepository = 512;

        var aceUrl =
            $"https://dev.azure.com/{organization}/_apis/accesscontrolentries/{gitRepositoriesNamespaceId}?api-version=7.1";

        var aceBody = new
        {
            token,
            merge = false,
            accessControlEntries = new[]
            {
                new
                {
                    descriptor,
                    allow = 0,
                    deny = denyDeleteOrDisableRepository
                }
            }
        };

        using var aceContent = new StringContent(JsonSerializer.Serialize(aceBody), Encoding.UTF8, "application/json");

        using var aceResponse = await client.PostAsync(aceUrl, aceContent, cancellationToken);
        var aceResponseBody = await aceResponse.Content.ReadAsStringAsync(cancellationToken);

        return Results.Ok(new
        {
            eventType,
            repoId,
            repoName,
            projectId,
            initiatedByDisplayName,
            initiatedByUniqueName,
            permissionUpdateStatusCode = (int)aceResponse.StatusCode,
            permissionUpdateResponse = aceResponseBody
        });
    });

app.Run();