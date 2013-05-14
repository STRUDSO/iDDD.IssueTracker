using System;
using SaasOvation.IssueTrack.Domain.Model.Products;

namespace SaasOvation.IssueTrack.Domain.Model.Tenants
{
    public class TenantId : IAmId
    {
        public TenantId(string id)
        {
            Id = id;
        }

        public string Id { get; private set; }
    }
}