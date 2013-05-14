using System.Collections.Generic;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.Idioms;
using Ploeh.AutoFixture.Xunit;
using SaasOvation.IssueTrack.Domain.Model;
using SaasOvation.IssueTrack.Domain.Model.Products;
using SubSpec;
using Xunit;
using Xunit.Extensions;
using System.Linq;

namespace iDDD.IssueTracker.Test.Domain.Model.Products
{
    public class IssueTests
    {
        [Theory, AutoMoqData]
        public void Ctor_Id_IsSet([Frozen] IssueId id, Issue issue)
        {
            Assert.Equal(id, issue.Id);
        }

        [Theory, AutoMoqData]
        public void Ctor_Summary_IsSet([Frozen] string summary, Issue issue)
        {
            Assert.Equal(summary, issue.Summary);
        }

        [Theory, AutoMoqData]
        public void Ctor_Description_IsSet([Frozen] string description, Issue issue)
        {
            Assert.Equal(description, issue.Description);
        }

        [Theory, AutoMoqData]
        public void Ctor_IssueType_IsSet([Frozen] IssueType type, Issue issue)
        {
            Assert.Equal(type, issue.Type);
        }

        [Theory, AutoMoqData]
        public void Ctor_InitialStatus_Open(Issue issue)
        {
            Assert.Equal(IssueStatus.Open, issue.Status);
        }

        [Theory, AutoMoqData]
        public void Ctor_IsDefect_PublishesDefectCreatedEvent(Generator<Issue> issues)
        {
            var events = new List<object>();
            DomainEventPublisher.Thunk = events.Add;
            Issue sut = issues.First(x => x.Type == IssueType.Defect);

            DefectCreated defectCreated = Assert.Single(events.OfType<DefectCreated>());

            Assert.Equal(sut.Id, defectCreated.IssueId);
        }

        [Thesis, AutoMoqData]
        public void ChangeSeverity_IsDefect_PublishesDefectCreatedEvent(IssueStatus newStatus, Generator<Issue> issues)
        {
            Issue sut = null;
            var events = new List<object>();
            "Given Issue".Context(
                () =>
                    {
                        events.Clear();
                        DomainEventPublisher.Thunk = events.Add;

                        sut = issues.First(x => x.Type == IssueType.Defect);
                    });

            "ChangeSeverity".Do(() => sut.ChangeSeverity(newStatus));

            var defectSeverityChangeds = events.OfType<DefectSeverityChanged>();
            "Event Published".Assert(() => Assert.Single(defectSeverityChangeds));
            "Id set".Assert(() => Assert.Equal(sut.Id, Assert.Single(defectSeverityChangeds).IssueId));
            "Status set".Assert(() => Assert.Equal(sut.Status, Assert.Single(defectSeverityChangeds).Status));
            "NewStatus set".Assert(() => Assert.Equal(newStatus, Assert.Single(defectSeverityChangeds).Status));
        }
    }

    public class MyAssert : IdiomaticAssertion
    {
        private readonly IFixture _fixture;

        public MyAssert(IFixture fixture)
        {
            _fixture = fixture;
        }

        public override void Verify(System.Reflection.ConstructorInfo constructorInfo)
        {
            base.Verify(constructorInfo);
        }
        public override void Verify(System.Reflection.MethodInfo methodInfo)
        {
            base.Verify(methodInfo);
        }
        public override void Verify(System.Reflection.PropertyInfo propertyInfo)
        {
            base.Verify(propertyInfo);
        }
    }
}