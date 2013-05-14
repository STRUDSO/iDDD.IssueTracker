﻿using System.Collections.Generic;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.Xunit;
using SaasOvation.IssueTrack.Domain.Model;
using SaasOvation.IssueTrack.Domain.Model.Products;
using Xunit;
using Xunit.Extensions;
using System.Linq;

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

        [Theory, AutoMoqData]
        public void Ctor_IsDefect_PublishesDefectCreatedEvent(Generator<Issue> issues)
        {
            var events = new List<object>();
            DomainEventPublisher.Thunk = events.Add;
            Issue sut = issues.First(x => x.Type == IssueType.Defect);

            DefectCreated defectCreated = Assert.Single(events.OfType<DefectCreated>());

            Assert.Equal(sut.Id, defectCreated.IssueId);
        }

        [Theory, AutoMoqData]
        public void ChangeSeverity_IsDefect_PublishesDefectCreatedEvent(Generator<Issue> issues)
        {
            var events = new List<object>();
            DomainEventPublisher.Thunk = events.Add;
            
            Issue sut = issues.First(x => x.Type == IssueType.Defect);
            sut.ChangeSeverity();

            DefectSeverityChanged defectCreated = Assert.Single(events.OfType<DefectSeverityChanged>());

            Assert.Equal(sut.Id, defectCreated.IssueId);
        }
    }
}