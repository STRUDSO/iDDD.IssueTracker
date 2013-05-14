using Ploeh.AutoFixture.Xunit;
using SaasOvation.IssueTrack.Domain.Model.Products;
using Xunit;
using Xunit.Extensions;

namespace iDDD.IssueTracker.Test.Domain.Model.Products
{
    public class ProductManagerTests
    {
        [Theory, AutoMoqData]
        public void Ctor_Id_IsAssigned([Frozen] ProductManagerId id, ProductManager sut)
        {
            Assert.Equal(id, sut.Id);
        }
    }
}