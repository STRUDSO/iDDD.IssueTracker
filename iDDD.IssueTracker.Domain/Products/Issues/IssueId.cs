using System;

namespace SaasOvation.IssueTrack.Domain.Model.Products.Issues
{
    public class IssueId : IAmId
    {
        public IssueId() : this(Guid.NewGuid().ToString())
        {
        }

        public IssueId(string id)
        {
            if (id == null) throw new ArgumentNullException("id");
            Id = id;
        }

        public string Id { get; private set; }
    }
}