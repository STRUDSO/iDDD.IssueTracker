using Ploeh.AutoFixture.Xunit;
using SaasOvation.IssueTrack.Domain.Model.Products;
using Xunit;
using Xunit.Extensions;

namespace iDDD.IssueTracker.Test.Domain.Model.Products
{
    public class ReleaseTests
    {
        [Theory, AutoMoqData]
        public void GetCalculator([Frozen]SeverityTotals totals, Release sut)
        {
            var defectStatisticsCalculator = sut.GetCalculator();

            Assert.Equal(totals, defectStatisticsCalculator.SeverityTotals);
        }
    }

    public class DefectStatisticsCalculatorTests
    {
        [Theory, AutoMoqData]
        public void DefectDensity_KlocMetric_ReturnsBasedOnKloc([Frozen] SeverityTotals totals, DefectStatisticsCalculator sut, SeverityWeights severityWeights, Release release, KlocMetric metric)
        {
            var expected = metric.Value / totals.Weighted(severityWeights);
            
            var defectDensity = sut.DefectDensity(metric, severityWeights);

            Assert.Equal(expected, defectDensity.Index);
        }
    }
}