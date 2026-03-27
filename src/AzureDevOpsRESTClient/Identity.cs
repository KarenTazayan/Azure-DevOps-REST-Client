namespace AzureDevOpsRESTClient
{
    public record Identity(string Id, string Descriptor, string SubjectDescriptor, string ProviderDisplayName)
    {
        public bool IsActive { get; init; }
    }
}
