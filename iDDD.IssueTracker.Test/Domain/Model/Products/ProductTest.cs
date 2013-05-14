using Ploeh.AutoFixture.Xunit;
using SaasOvation.IssueTrack.Domain.Model.Products;
using SaasOvation.IssueTrack.Domain.Model.Tenants;
using Xunit;
using Xunit.Extensions;

namespace iDDD.IssueTracker.Test.Domain.Products
{
    public class ProductTest
    {
        [Fact]
        public void Fact()
        {
        }

        [Theory, AutoMoqData]
        public void Create_Product_WillSetIdentity([Frozen] ProductId id, Product product)
        {
            Assert.Equal(id, product.Id);
        }

        [Theory, AutoMoqData]
        public void Create_Product_WillSetTenantIdentity([Frozen] TenantId id, Product product)
        {
            Assert.Equal(id, product.TenantId);
        }
    }
}
