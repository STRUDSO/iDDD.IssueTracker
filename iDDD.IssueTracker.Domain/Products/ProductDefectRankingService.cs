using System.Collections.Generic;
using SaasOvation.IssueTrack.Domain.Model.Tenants;
using System.Linq;

namespace SaasOvation.IssueTrack.Domain.Model.Products
{
    public class ProductDefectRankingService
    {
        private readonly IProductsRepository _productsRepository;
        public static readonly SeverityWeights SeverityWeights = new SeverityWeights(0.1);

        public ProductDefectRankingService(IProductsRepository productsRepository)
        {
            _productsRepository= productsRepository;
        }

        public Product GetMostDefectiveProduct(TenantId tenantId)
        {
            var rankedProducts = GetRankedProducts(tenantId);
            return rankedProducts.FirstOrDefault();
        }

        public IEnumerable<Product> GetRankedProducts(TenantId tenantId)
        {
            return _productsRepository
                .AllByTenant(tenantId)
                .OrderByDescending(x => x.WeightedTotal(SeverityWeights));
        }
    }
}