namespace AzureDevOpsRESTClient
{
    public record SecurityNamespaceAction
    {
        public int Bit { get; init; }
        public string Name { get; init; }
        public string DisplayName { get; init; }
        public string NamespaceId { get; init; }
    }
}
