namespace SaasOvation.IssueTrack.Domain.Model.Products.Issues
{
    public class Defect: Issue
    {
        public Defect(IssueId id, string summary, string description) : base(id, summary, description)
        {
            DomainEventPublisher.Publish(new DefectCreated(Id));
        }
    }
}