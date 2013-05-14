namespace SaasOvation.IssueTrack.Domain.Model.Products
{
    public class ProductManager
    {
        public ProductManager(ProductManagerId id)
        {
            Id = id;
        }

        public ProductManagerId Id { get; private set; }
    }
}