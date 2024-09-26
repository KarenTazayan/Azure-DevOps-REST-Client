namespace AzureDevOpsRESTClient
{
    public record Identity
    {
        public string Id { get; init; }
        public string Descriptor { get; init; }
        public string SubjectDescriptor { get; init; }
        public string ProviderDisplayName { get; init; }
        public bool IsActive { get; init; }
    }
}
