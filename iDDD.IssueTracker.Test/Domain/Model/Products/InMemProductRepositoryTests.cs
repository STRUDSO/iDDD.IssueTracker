using System.Collections.Generic;
using System.Linq;
using Ploeh.AutoFixture.Xunit;
using SaasOvation.IssueTrack.Domain.Model;
using SaasOvation.IssueTrack.Domain.Model.Products;
using SaasOvation.IssueTrack.Domain.Model.Tenants;
using Xunit;
using Xunit.Extensions;

namespace iDDD.IssueTracker.Test.Domain.Model.Products
{
    public abstract class InMemRepositoryTests<TRepo, TProduct, TId>
        where TRepo : IRepository<TProduct, TId>
        where TProduct : IHaveId<TId>
    {
        [Theory, AutoMoqData]
        public void OfId_NoProducts_ReturnsNull(TRepo sut, TenantId tenant, TId productId)
        {
            Assert.Null(sut.OfId(tenant, productId));
        }

        [Theory, AutoMoqData]
        public void OfId_ContainsProduct_1ProductReturned([Frozen] IEnumerable<TProduct> products, TRepo sut,
                                                          TenantId tenant)
        {
            sut.SaveAll(tenant, products);

            TProduct actual = sut.OfId(tenant, products.First().Id);
            
            Assert.NotNull(actual);
        }
    }

    public class InMemRepositoryTestsImpl :
        InMemRepositoryTests<InMemRepository<Product, ProductId>, Product, ProductId>
    {
    }
}