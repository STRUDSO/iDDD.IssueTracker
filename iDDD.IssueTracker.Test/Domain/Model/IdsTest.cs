﻿using System.Collections.Generic;
using System.Linq;
using Ploeh.AutoFixture;
using SaasOvation.IssueTrack.Domain.Model;
using Xunit;
using Xunit.Extensions;

namespace iDDD.IssueTracker.Test.Domain.Model
{
    public abstract class IdsTest<TId> where TId : IAmId
    {
        [Theory, AutoMoqData]
        public void New_Can_CreateId(Generator<TId> productIds)
        {
            IEnumerable<TId> enumerable = productIds.Take(2);

            Assert.NotEqual(enumerable.First(), enumerable.Last());
        }

        [Theory, AutoMoqData]
        public void New_DefaultCtor_GeneratesUniqueId(TId productId)
        {
            Assert.NotNull(productId.Id);
        }
    }
}