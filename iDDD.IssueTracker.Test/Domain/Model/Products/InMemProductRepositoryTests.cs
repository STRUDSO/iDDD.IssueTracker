using System.Collections.Generic;
using System.Linq;
using Ploeh.AutoFixture.Xunit;
using SaasOvation.IssueTrack.Domain.Model.Products;
using SaasOvation.IssueTrack.Domain.Model.Tenants;
using Xunit;
using Xunit.Extensions;

namespace iDDD.IssueTracker.Test.Domain.Model.Products
{
    public class InMemRepositoryTests
    {
        [Theory, AutoMoqData]
        public void OfId_NoProducts_ReturnsNull(InMemRepository<Product, ProductId> sut, TenantId tenant, ProductId productId)
        {
            Assert.Null(sut.OfId(tenant, productId));
        }

        [Theory, AutoMoqData]
        public void OfId_ContainsProduct_1ProductReturned([Frozen] IEnumerable<Product> products, InMemRepository<Product, ProductId> sut, TenantId tenant)
        {
            var actual = sut.OfId(tenant, products.First().Id);
            Assert.NotNull(actual);
        }
    }
}