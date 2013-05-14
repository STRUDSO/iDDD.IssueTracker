using SaasOvation.IssueTrack.Domain.Model.Tenants;

namespace SaasOvation.IssueTrack.Domain.Model.Products
{
    public class Product
    {
        public Product(ProductId id, TenantId tenantId)
        {
            Id = id;
            TenantId = tenantId;
        }

        public ProductId Id { get; private set; }
        public TenantId TenantId { get; private set; }
    }
}
