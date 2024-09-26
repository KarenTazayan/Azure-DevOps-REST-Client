namespace AzureDevOpsRESTClient
{
    [Serializable]
    public record SecurityNamespace
    {
        public Guid NamespaceId { get; init; }
        public string Name { get; init; }
        public string DisplayName { get; init; }
        public string SeparatorValue { get; init; }
        public int ElementLength { get; init; }
        public int WritePermission { get; init; }
        public int ReadPermission { get; init; }
        public string DataspaceCategory { get; init; }
        public SecurityNamespaceAction[] Actions { get; init; }
    }
}
