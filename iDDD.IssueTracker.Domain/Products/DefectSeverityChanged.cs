namespace SaasOvation.IssueTrack.Domain.Model.Products
{
    public class DefectSeverityChanged
    {
        public IssueId IssueId { get; private set; }

        public DefectSeverityChanged(IssueId issueId)
        {
            IssueId = issueId;
        }
    }
}