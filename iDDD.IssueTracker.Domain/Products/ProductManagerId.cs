namespace SaasOvation.IssueTrack.Domain.Model.Products
{
    public class ProductManagerId : IAmId
    {
        public ProductManagerId(string id)
        {
            Id = id;
        }

        public string Id { get; private set; }
    }
}