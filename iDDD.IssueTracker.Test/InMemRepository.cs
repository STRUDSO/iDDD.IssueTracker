using System.Collections.Generic;
using System.Linq;
using SaasOvation.IssueTrack.Domain.Model;
using SaasOvation.IssueTrack.Domain.Model.Tenants;

namespace iDDD.IssueTracker.Test.Domain.Model.Products
{
    public interface IRepository<T, TId> where T : IHaveId<TId>
    {
        T OfId(TenantId tenant, TId productId);
        void SaveAll(TenantId tenant, IEnumerable<T> all);
    }

    public class InMemRepository<T, TId> : IRepository<T, TId> where T : IHaveId<TId>
    {
        private readonly List<T> _products = new List<T>();

        public T OfId(TenantId tenant, TId productId)
        {
            return _products.SingleOrDefault(x => x.Id.Equals(productId));
        }

        public void SaveAll(TenantId tenant, IEnumerable<T> all)
        {
            _products.AddRange(all);
        }
    }
}