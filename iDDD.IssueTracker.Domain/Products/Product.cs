using SaasOvation.IssueTrack.Domain.Model.Tenants;

namespace SaasOvation.IssueTrack.Domain.Model.Products
{
    public class Product
    {
        public Product(ProductId id, TenantId tenantId, string name, string description,
                       ProductManager productManager, IssueAssigner assigner)
        {
            Id = id;
            TenantId = tenantId;
            Name = name;
            Description = description;
            ProductManager = productManager;
            IssueAssigner = assigner;
        }

        public ProductId Id { get; private set; }
        public TenantId TenantId { get; private set; }
        
        public IssueAssigner IssueAssigner { get; private set; }
        public ProductManager ProductManager { get; private set; }

        public string Name { get; private set; }
        public string Description { get; private set; }
    }
}