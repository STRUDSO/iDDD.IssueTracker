namespace SaasOvation.IssueTrack.Domain.Model.Products
{
    public class Issue
    {
        public Issue(IssueId id, string summary, string description)
        {
            Id = id;
            Summary = summary;
            Description = description;
        }

        public IssueId Id { get; private set; }

        public string Summary { get; private set; }

        public string Description { get; private set; }
    }
}