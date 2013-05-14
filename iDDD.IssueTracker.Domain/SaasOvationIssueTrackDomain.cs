using System.Reflection;

namespace SaasOvation.IssueTrack.Domain.Model
{
    public class SaasOvationIssueTrackDomain
    {
        public static Assembly Assembly
        {
            get { return typeof (SaasOvationIssueTrackDomain).Assembly; }
        } 
    }
}