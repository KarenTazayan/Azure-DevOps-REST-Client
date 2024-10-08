﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using static AzureDevOpsRESTClient.AzureDevOpsRestApiGlobalConfig;

namespace AzureDevOpsRESTClient
{
    internal class UserEntitlementsService(RestClient restClient)
    {
        public async Task<Result<string>> GetAll(string userId)
        {
            var url = $"https://vsaex.dev.azure.com/{restClient.OrgName}/_apis/userentitlements/{userId}" +
                      $"?{ApiVersion}";

            var httpClient = restClient.GetHttpClient();
            using var response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return Result.CreateSuccess(JToken.Parse(json).ToString(Formatting.Indented));
            }
            else
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                return Result.CreateFail<string>($"Failed to connect: {response.ReasonPhrase}");
            }
        }

        public async Task<Result<string>> Add(string originId, string descriptor)
        {
            var url = $"https://vsaex.dev.azure.com/{restClient.OrgName}/_apis/userentitlements?{ApiVersion}";
            var httpClient = restClient.GetHttpClient();

            var body = $$"""
                       {
                           "accessLevel": {
                           "licensingSource": "account",
                           "accountLicenseType": "express"
                         },
                         "user": {
                           "descriptor": "{{descriptor}}",
                           "originId": "{{originId}}",
                           "subjectKind": "user"
                         }
                       }
                       """;

            var content = new StringContent(body, System.Text.Encoding.UTF8, "application/json");

            using var response = await httpClient.PostAsync(url, content);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return Result.CreateSuccess(JToken.Parse(json).ToString(Formatting.Indented));
            }
            else
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                return Result.CreateFail<string>($"Failed to connect: {response.ReasonPhrase}");
            }
        }

        public async Task<Result<string>> Add(string requestBody)
        {
            var url = $"https://vsaex.dev.azure.com/{restClient.OrgName}/_apis/userentitlements?{ApiVersion}";
            var httpClient = restClient.GetHttpClient();

            var content = new StringContent(requestBody, System.Text.Encoding.UTF8, "application/json");

            using var response = await httpClient.PostAsync(url, content);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return Result.CreateSuccess(JToken.Parse(json).ToString(Formatting.Indented));
            }
            else
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                return Result.CreateFail<string>($"Failed to connect: {response.ReasonPhrase}");
            }
        }

        public async Task<Result<string>> Search(string filter)
        {
            var url = $"https://vsaex.dev.azure.com/{restClient.OrgName}" +
                      $"/_apis/userentitlements?$filter=name eq '{filter}'&{ApiVersion}";

            var httpClient = restClient.GetHttpClient();
            using var response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return Result.CreateSuccess(JToken.Parse(json).ToString(Formatting.Indented));
            }
            else
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                return Result.CreateFail<string>($"Failed to connect: {response.ReasonPhrase}");
            }
        }
    }
}
