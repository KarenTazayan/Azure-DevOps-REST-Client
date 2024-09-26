namespace AzureDevOpsRESTClient
{
    public record User
    {
        public string SubjectKind { get; init; }
        public string DirectoryAlias { get; init; }
        public string Domain { get; init; }
        public string PrincipalName { get; init; }
        public string MailAddress { get; init; }
        public string Origin { get; init; }
        public string OriginId { get; init; }
        public string DisplayName { get; init; }
        public string Descriptor { get; init; }
        public string Url { get; init; }
    }
}
