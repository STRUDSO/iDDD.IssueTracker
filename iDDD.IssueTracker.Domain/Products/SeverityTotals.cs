using System;

namespace SaasOvation.IssueTrack.Domain.Model.Products
{
    public class SeverityTotals
    {
        public SeverityTotals(int low, int medium, int high)
        {
            Low = low;
            Medium = medium;
            High = high;
        }

        private int Low { get; set; }
        private int Medium { get; set; }
        private int High { get; set; }

        public double Weighted(SeverityWeights severityWeights)
        {
            if (severityWeights == null) throw new ArgumentNullException("severityWeights");
            return 
                Low*severityWeights.Low + 
                Medium*severityWeights.Medium + 
                High*severityWeights.High;
        }
    }
}