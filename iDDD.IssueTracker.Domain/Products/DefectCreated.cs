namespace SaasOvation.IssueTrack.Domain.Model.Products
{
    public class DefectCreated
    {
        public DefectCreated(IssueId issueId)
        {
            IssueId = issueId;
        }

        public IssueId IssueId { get; private set; }
    }
}