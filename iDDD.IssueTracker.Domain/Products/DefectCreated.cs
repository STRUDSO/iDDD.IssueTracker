using System;

namespace SaasOvation.IssueTrack.Domain.Model.Products
{
    public class DefectCreated
    {
        public DefectCreated(IssueId issueId)
        {
            if (issueId == null) throw new ArgumentNullException("issueId");
            IssueId = issueId;
        }

        public IssueId IssueId { get; private set; }
    }
}