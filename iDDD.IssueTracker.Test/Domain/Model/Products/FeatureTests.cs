using Ploeh.AutoFixture;
using SaasOvation.IssueTrack.Domain.Model.Products.Issues;
using Xunit;
using Xunit.Extensions;

namespace iDDD.IssueTracker.Test.Domain.Model.Products
{
    public class FeatureTests
    {
        [Theory, AutoMoqData]
        public void Ctor_WhenCreated_DoesNotThrow(IFixture fixture)
        {
            Assert.DoesNotThrow(() => fixture.Create<Feature>());
        }
    }
}