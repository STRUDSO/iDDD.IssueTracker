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

        protected bool Equals(SeverityTotals other)
        {
            return Low == other.Low && Medium == other.Medium && High == other.High;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((SeverityTotals) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = Low;
                hashCode = (hashCode*397) ^ Medium;
                hashCode = (hashCode*397) ^ High;
                return hashCode;
            }
        }

        public static bool operator ==(SeverityTotals left, SeverityTotals right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SeverityTotals left, SeverityTotals right)
        {
            return !Equals(left, right);
        }

        public double Weighted(SeverityWeights severityWeights)
        {
            return 
                Low*severityWeights.Low + 
                Medium*severityWeights.Medium + 
                High*severityWeights.High;
        }
    }
}