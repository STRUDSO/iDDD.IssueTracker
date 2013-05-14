using System.Collections.Generic;
using System.Linq;
using Ploeh.AutoFixture;
using SaasOvation.IssueTrack.Domain.Model.Products;
using Xunit;
using Xunit.Extensions;

namespace iDDD.IssueTracker.Test.Domain.Products
{
    public class ProductIdTests
    {
        [Fact]
        public void Dummy(){}

        [Theory, AutoMoqData]
        public void New_Can_CreateProductId(Generator<ProductId> productIds)
        {
            IEnumerable<ProductId> enumerable = productIds.Take(2);

            Assert.NotEqual(enumerable.First(), enumerable.Last());
        }

        [Theory, AutoMoqData]
        public void New_DefaultCtor_GeneratesUniqueId(ProductId productId)
        {
            Assert.NotNull(productId.Id);
        }
    }
}