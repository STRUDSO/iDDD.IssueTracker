using System;

namespace SaasOvation.IssueTrack.Domain.Model.Products
{
    public class ProductManagerId : IAmId
    {
        public ProductManagerId(string id)
        {
            if (id == null) throw new ArgumentNullException("id");
            Id = id;
        }

        public string Id { get; private set; }
    }
}