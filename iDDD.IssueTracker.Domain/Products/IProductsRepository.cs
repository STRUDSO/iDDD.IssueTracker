using System.Collections.Generic;
using SaasOvation.IssueTrack.Domain.Model.Tenants;

namespace SaasOvation.IssueTrack.Domain.Model.Products
{
    public interface IProductsRepository
    {
        IEnumerable<Product> AllByTenant(TenantId isAny);
    }
}