using System;
using System.Collections.Generic;
using System.Linq;
using Headspring;
using Ploeh.AutoFixture.Idioms;
using SaasOvation.IssueTrack.Domain.Model;
using Xunit.Extensions;

namespace iDDD.IssueTracker.Test.Domain.Model.Products
{
    public class IdiomsTests {
        [Theory, AutoMoqData]
        public void Idioms_Guard(GuardClauseAssertion guardClauseAssertion)
        {
            guardClauseAssertion.Verify(MemberInfos());
        }

        private static IEnumerable<Type> MemberInfos()
        {
            return SaasOvationIssueTrackDomain.Assembly.GetExportedTypes().Where(x => !x.IsAbstract && !x.IsEnum && !typeof(IEnumeration).IsAssignableFrom(x));
        }

        [Theory, AutoMoqData]
        public void Idioms_Bla(WritablePropertyAssertion writablePropertyAssertion)
        {
            writablePropertyAssertion.Verify(MemberInfos());
        }

    }
}