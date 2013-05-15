using System;

namespace SaasOvation.IssueTrack.Domain.Model.Products.Issues
{
    public class Issue
    {
        public Issue(IssueId id, string summary, string description)
        {
            if (id == null) throw new ArgumentNullException("id");
            if (summary == null) throw new ArgumentNullException("summary");
            if (description == null) throw new ArgumentNullException("description");
            Id = id;
            Summary = summary;
            Description = description;
            Status = IssueStatus.Open;
        }

        public IssueId Id { get; private set; }
        public string Summary { get; private set; }
        public string Description { get; private set; }
        public IssueStatus Status { get; private set; }
        public IssuePriority Priority { get; private set; }

        public void ChangeSeverity(IssueStatus newStatus)
        {
            DomainEventPublisher.Publish(new DefectSeverityChanged(Id, Status, newStatus));
            Status = newStatus;
        }
    }

    public class Feature : Issue
    {
        public Feature(IssueId id, string summary, string description) : base(id, summary, description)
        {
        }
    }

    public enum IssuePriority
    {
        Low,
        Medium,
        High
    }
}