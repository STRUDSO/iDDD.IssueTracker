using SaasOvation.IssueTrack.Domain.Model.Products;
using Xunit;

namespace iDDD.IssueTracker.Test.Domain.Products
{
    public class ProductTest
    {
        [Fact]
        public void Fact()
        {
            Assert.DoesNotThrow(() => new Product());
        }
    }
}
