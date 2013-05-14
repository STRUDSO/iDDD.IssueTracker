using System;
using System.Collections.Generic;
using SaasOvation.IssueTrack.Domain.Model.Tenants;
using System.Linq;

namespace SaasOvation.IssueTrack.Domain.Model.Products
{
    public class ProductDefectRankingService
    {
        private readonly IProductsRepository _productsRepository;
        public static readonly SeverityWeights SeverityWeights = new SeverityWeights(0.0, 0.25, 1);

        public ProductDefectRankingService(IProductsRepository productsRepository)
        {
            if (productsRepository == null) throw new ArgumentNullException("productsRepository");
            _productsRepository= productsRepository;
        }

        public Product GetMostDefectiveProduct(TenantId tenantId)
        {
            if (tenantId == null) throw new ArgumentNullException("tenantId");
            var rankedProducts = GetRankedProducts(tenantId);
            return rankedProducts.FirstOrDefault();
        }

        public IEnumerable<Product> GetRankedProducts(TenantId tenantId)
        {
            if (tenantId == null) throw new ArgumentNullException("tenantId");
            return _productsRepository
                .AllByTenant(tenantId)
                .OrderByDescending(x => x.WeightedTotal(SeverityWeights));
        }
    }
}