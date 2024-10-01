namespace AzureDevOpsRESTClient
{
    public record SecurityNamespaceAction(string Name, string DisplayName, string NamespaceId)
    {
        public int Bit { get; init; }
    }
}
