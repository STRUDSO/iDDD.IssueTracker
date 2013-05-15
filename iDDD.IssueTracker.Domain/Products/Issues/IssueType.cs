using Headspring;

namespace SaasOvation.IssueTrack.Domain.Model.Products.Issues
{
    public class IssueType : Enumeration<IssueType>
    {
        private IssueType(int value, string displayName) : base(value, displayName)
        {
        }

        public static readonly IssueType Defect  = new IssueType(0, "Defect");
        public static readonly IssueType Feature = new IssueType(1, "Feature");
    }
}