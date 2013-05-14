using System.Linq;
using Moq;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.Xunit;
using SaasOvation.IssueTrack.Domain.Model.Products;
using SaasOvation.IssueTrack.Domain.Model.Tenants;
using Xunit;
using Xunit.Extensions;

namespace iDDD.IssueTracker.Test.Domain.Model.Products
{
    public class ProductDefectRankingServiceTests
    {
        [Theory, AutoMoqData]
        public void GetRankedProducts_OnlyOne_Returns1([Frozen] Mock<IProductsRepository> productsRepository, ProductDefectRankingService sut, Generator<Product> products, TenantId tenantId)
        {
            var enumerable = products.Take(1).ToArray();
            productsRepository.Setup(x => x.AllByTenant(It.IsAny<TenantId>())).Returns(enumerable);

            var rankedProducts = sut.GetRankedProducts(tenantId).ToArray();
            Assert.Equal(enumerable, rankedProducts);
        }
        
        [Theory, AutoMoqData]
        public void GetRankedProducts_MultipleProducts_ReturnsOrderedByRank([Frozen] Mock<IProductsRepository> productsRepository, ProductDefectRankingService sut, Generator<Product> products, TenantId tenantId, int numberOfProducts)
        {
            var enumerable = products.Take(numberOfProducts).ToArray();
            productsRepository.Setup(x => x.AllByTenant(It.IsAny<TenantId>())).Returns(enumerable);

            var rankedProducts = sut.GetRankedProducts(tenantId).ToArray();

            Assert.Equal(enumerable.OrderByDescending(x => x.WeightedTotal(ProductDefectRankingService.SeverityWeights)).ToArray(), rankedProducts);
        }

        [Theory, AutoMoqData]
        public void GetMostDefectiveProduct_MultipleProducts_ReturnsTheHighestRanked([Frozen] Mock<IProductsRepository> productsRepository, ProductDefectRankingService sut, Generator<Product> products, TenantId tenantId, int numberOfProducts)
        {
            var enumerable = products.Take(numberOfProducts).ToArray();
            productsRepository.Setup(x => x.AllByTenant(It.IsAny<TenantId>())).Returns(enumerable);

            var mostDefectiveProduct = sut.GetMostDefectiveProduct(tenantId);

            var max = enumerable.Max(x => x.WeightedTotal(ProductDefectRankingService.SeverityWeights));
            Assert.Equal(max, mostDefectiveProduct.WeightedTotal(ProductDefectRankingService.SeverityWeights));
        }

    }
}