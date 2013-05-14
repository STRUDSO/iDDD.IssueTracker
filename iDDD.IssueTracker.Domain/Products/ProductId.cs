using System;

namespace SaasOvation.IssueTrack.Domain.Model.Products
{
    public class ProductId
    {
        public ProductId()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; private set; }
    }
}