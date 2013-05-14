namespace SaasOvation.IssueTrack.Domain.Model.Products
{
    public class SeverityTotals
    {
        public SeverityTotals(int lowCount)
        {
            LowCount = lowCount;
        }

        protected int LowCount { get; private set; }

        protected bool Equals(SeverityTotals other)
        {
            return LowCount == other.LowCount;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((SeverityTotals) obj);
        }

        public override int GetHashCode()
        {
            return LowCount;
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
            return LowCount*severityWeights.LowWeight;
        }
    }
}