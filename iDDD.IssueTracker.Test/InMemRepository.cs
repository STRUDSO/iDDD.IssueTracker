using System.Collections.Generic;
using System.Linq;
using SaasOvation.IssueTrack.Domain.Model;
using SaasOvation.IssueTrack.Domain.Model.Tenants;

namespace iDDD.IssueTracker.Test.Domain.Model.Products
{
    public class InMemRepository<T, TId> where T : IHaveId<TId>
    {
        private readonly IEnumerable<T> _products;

        public InMemRepository(IEnumerable<T> products)
        {
            _products = products;
        }

        public T OfId(TenantId tenant, TId productId)
        {
            return _products.SingleOrDefault(x => x.Id.Equals(productId));
        }
    }
}