using SaasOvation.IssueTrack.Domain.Model.Products;
using Xunit;
using Xunit.Extensions;

namespace iDDD.IssueTracker.Test.Domain.Model.Products
{
    public class SeverityTotalsTests
    {
        [Theory, AutoMoqData]
        public void Weighted_Low_Returns(SeverityWeights severityWeights, int low)
        {
            var weighted = new SeverityTotals(low, 0, 0).Weighted(severityWeights);
            Assert.Equal(low * severityWeights.Low, weighted);
        }

        [Theory, AutoMoqData]
        public void Weighted_Medium_Returns(SeverityWeights severityWeights, int medium)
        {
            var weighted = new SeverityTotals(0, medium, 0).Weighted(severityWeights);
            Assert.Equal(medium * severityWeights.Medium, weighted);
        }

        [Theory, AutoMoqData]
        public void Weighted_High_Returns(SeverityWeights severityWeights, int high)
        {
            var weighted = new SeverityTotals(0, 0, high).Weighted(severityWeights);
            Assert.Equal(high * severityWeights.High, weighted);
        }

        [Theory, AutoMoqData]
        public void Weighted_AllValues_Returns(SeverityTotals sut, SeverityWeights severityWeights, int low, int medium, int high)
        {
            var weighted = new SeverityTotals(low, medium, high).Weighted(severityWeights);
            Assert.Equal(low*severityWeights.Low + medium*severityWeights.Medium + high*severityWeights.High, weighted);
        }
    }
}