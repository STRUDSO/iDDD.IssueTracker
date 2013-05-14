using System;

namespace SaasOvation.IssueTrack.Domain.Model.Products
{
    public class ProductManager
    {
        public ProductManager(ProductManagerId id)
        {
            if (id == null) throw new ArgumentNullException("id");
            Id = id;
        }

        public ProductManagerId Id { get; private set; }
    }
}