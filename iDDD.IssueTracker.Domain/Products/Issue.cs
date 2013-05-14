namespace SaasOvation.IssueTrack.Domain.Model.Products
{
    public class Issue
    {
        public Issue(IssueId id, string summary, string description, IssueType type)
        {
            Id = id;
            Summary = summary;
            Description = description;
            Type = type;
            Status = IssueStatus.Open;
        }

        public IssueId Id { get; private set; }
        public string Summary { get; private set; }
        public string Description { get; private set; }
        public IssueType Type { get; private set; }
        public IssueStatus Status { get; private set; }
    }
}