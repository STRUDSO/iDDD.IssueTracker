using System;

namespace SaasOvation.IssueTrack.Domain.Model.Tenants
{
    public class TenantId : IAmId
    {
        public TenantId(string id)
        {
            if (id == null) throw new ArgumentNullException("id");
            Id = id;
        }

        public string Id { get; private set; }
    }
}