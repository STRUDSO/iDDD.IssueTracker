using System;

namespace SaasOvation.IssueTrack.Domain.Model.Products
{
    public class ProductId : IAmId
    {
        private ProductId(string id)
        {
            Id = id;
        }

        public ProductId() : this(Guid.NewGuid().ToString())
        {
        }

        public string Id { get; private set; }
    }
}