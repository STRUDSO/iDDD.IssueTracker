using Ploeh.AutoFixture.Xunit;
using SaasOvation.IssueTrack.Domain.Model.Products;
using Xunit;
using Xunit.Extensions;

namespace iDDD.IssueTracker.Test.Domain.Model.Products
{
    public class IssueTests
    {
        [Theory, AutoMoqData]
        public void Ctor_Id_IsSet([Frozen]IssueId id, Issue issue)
        {
            Assert.Equal(id, issue.Id);
        }

        [Theory, AutoMoqData]
        public void Ctor_Summary_IsSet([Frozen]string summary, Issue issue)
        {
            Assert.Equal(summary, issue.Summary);
        }

        [Theory, AutoMoqData]
        public void Ctor_Description_IsSet([Frozen]string description, Issue issue)
        {
            Assert.Equal(description, issue.Description);
        }

        [Theory, AutoMoqData]
        public void Ctor_IssueType_IsSet([Frozen]IssueType type, Issue issue)
        {
            Assert.Equal(type, issue.Type);
        }

        [Theory, AutoMoqData]
        public void Ctor_InitialStatus_Open(Issue issue)
        {
            Assert.Equal(IssueStatus.Open, issue.Status);
        }
    }
}