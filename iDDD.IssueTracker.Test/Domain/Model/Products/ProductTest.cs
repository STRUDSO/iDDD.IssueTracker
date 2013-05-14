using System.Linq;
using Ploeh.AutoFixture.Xunit;
using SaasOvation.IssueTrack.Domain.Model.Products;
using SaasOvation.IssueTrack.Domain.Model.Tenants;
using Xunit;
using Xunit.Extensions;

namespace iDDD.IssueTracker.Test.Domain.Model.Products
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

        [Theory, AutoMoqData]
        public void Create_Product_WillSetProductManagerIdIdentity([Frozen] ProductManager productManager,
                                                                   Product product)
        {
            Assert.Equal(productManager, product.ProductManager);
        }

        [Theory, AutoMoqData]
        public void Create_Name_IsSet([Frozen] string name, Product product)
        {
            Assert.Equal(name, product.Name);
        }

        [Theory, AutoMoqData]
        public void Create_Description_IsSet([Frozen] string description, Product product)
        {
            Assert.Equal(description, product.Description);
        }

        [Theory, AutoMoqData]
        public void Create_IssueAssigner_IsSet([Frozen] IssueAssigner assigner, Product product)
        {
            Assert.Equal(assigner, product.IssueAssigner);
        }

        [Theory, AutoMoqData]
        public void ReportDefect__IssueAssigned(Product product, string summary, string description)
        {
            product.ReportDefect(summary, description);

            Issue single = Assert.Single(product.Issues.Where(x => x.Summary == summary && x.Description == description));
            Assert.Equal(IssueType.Defect, single.Type);
        }

        [Theory, AutoMoqData]
        public void Ctor_Issues_NotNull(Product product)
        {
            Assert.NotNull(product.Issues);
        }

        [Theory, AutoMoqData]
        public void ReportFeature__IssueAssigned(Product product, string summary, string description)
        {
            product.ReportFeature(summary, description);

            Issue single = Assert.Single(product.Issues.Where(x => x.Summary == summary && x.Description == description));
            Assert.Equal(IssueType.Feature, single.Type);
        }
    }
}