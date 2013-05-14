using System;

namespace SaasOvation.IssueTrack.Domain.Model.Products
{
    public class Issue
    {
        public Issue(IssueId id, string summary, string description, IssueType type)
        {
            if (id == null) throw new ArgumentNullException("id");
            if (summary == null) throw new ArgumentNullException("summary");
            if (description == null) throw new ArgumentNullException("description");
            if (type == null) throw new ArgumentNullException("type");
            Id = id;
            Summary = summary;
            Description = description;
            Type = type;
            Status = IssueStatus.Open;

            if (type == IssueType.Defect)
                DomainEventPublisher.Publish(new DefectCreated(Id));
        }

        public IssueId Id { get; private set; }
        public string Summary { get; private set; }
        public string Description { get; private set; }
        public IssueType Type { get; private set; }
        public IssueStatus Status { get; private set; }
        public IssuePriority Priority { get; private set; }

        public void ChangeSeverity(IssueStatus newStatus)
        {
            DomainEventPublisher.Publish(new DefectSeverityChanged(Id, Status, newStatus));
            Status = newStatus;
        }
    }

    public enum IssuePriority
    {
        Low,
        Medium,
        High
    }
}