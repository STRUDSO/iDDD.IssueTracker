using System;

namespace SaasOvation.IssueTrack.Domain.Model.Products
{
    public class DefectSeverityChanged
    {
        public IssueId IssueId { get; private set; }
        public IssueStatus Status { get; private set; }
        public IssueStatus NewStatus { get; private set; }

        public DefectSeverityChanged(IssueId issueId, IssueStatus status, IssueStatus newStatus)
        {
            if (issueId == null) throw new ArgumentNullException("issueId");
            if (status == null) throw new ArgumentNullException("status");
            if (newStatus == null) throw new ArgumentNullException("newStatus");
            IssueId = issueId;
            Status = status;
            NewStatus = newStatus;
        }
    }
}