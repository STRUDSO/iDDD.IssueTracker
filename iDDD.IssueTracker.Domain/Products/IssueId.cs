using System;

namespace SaasOvation.IssueTrack.Domain.Model.Products
{
    public class IssueId : IAmId
    {
        public IssueId() : this(Guid.NewGuid().ToString())
        {
        }

        public IssueId(string id)
        {
            Id = id;
        }

        public string Id { get; private set; }
    }
}