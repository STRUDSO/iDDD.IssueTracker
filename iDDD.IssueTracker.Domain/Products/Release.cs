using System;

namespace SaasOvation.IssueTrack.Domain.Model.Products
{
    public class Release
    {
        private readonly SeverityTotals _severityTotals;

        public Release(SeverityTotals severityTotals)
        {
            if (severityTotals == null) throw new ArgumentNullException("severityTotals");
            _severityTotals = severityTotals;
        }

        public DefectStatisticsCalculator GetCalculator()
        {
            return new DefectStatisticsCalculator(_severityTotals);
        }
    }

    public class DefectStatisticsCalculator
    {
        public DefectStatisticsCalculator(SeverityTotals severityTotals)
        {
            if (severityTotals == null) throw new ArgumentNullException("severityTotals");
            SeverityTotals = severityTotals;
        }

        public SeverityTotals SeverityTotals { get; private set; }

        public DefectDensity DefectDensity(Metric metric, SeverityWeights severityWeights)
        {
            if (metric == null) throw new ArgumentNullException("metric");
            if (severityWeights == null) throw new ArgumentNullException("severityWeights");
            double weightedOutstandingDefects = SeverityTotals.Weighted(severityWeights);
            double index = metric.Value/weightedOutstandingDefects;
            return new DefectDensity(index);
        }
    }

    public class KlocMetric : Metric
    {
        public KlocMetric(int value)
        {
            Value = value;
        }
    }

    public abstract class Metric
    {
        public double Value { get; set; }
    }

    public class DefectDensity
    {
        public DefectDensity(double index)
        {
            Index = index;
        }

        public double Index { get; set; }
    }

    public class SeverityWeights
    {
        public SeverityWeights(double lowWeight, double medium, double high)
        {
            Low = lowWeight;
            Medium = medium;
            High = high;
        }

        public double Low { get; private set; }
        public double Medium { get; private set; }
        public double High { get; private set; }
    }
}