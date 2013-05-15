using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Headspring;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;
using Ploeh.AutoFixture.Kernel;
using Ploeh.AutoFixture.Xunit;
using SaasOvation.IssueTrack.Domain.Model;

namespace iDDD.IssueTracker.Test
{
    public class AutoMoqDataAttribute : AutoDataAttribute
    {
        public AutoMoqDataAttribute()
            : base(Fixture
            )
        {
            DomainEventPublisher.Thunk = o => { };
        }

        public static IFixture Fixture
        {
            get
            {
                return new Fixture()
                    .Customize(new AutoMoqCustomization())
                    .Customize(new Bla())
                    .Customize(new LazyCustomization());
            }
        }
    }

    public class LazyCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customizations.Add(new LazyGenerator());
        }
    }

    public class LazyGenerator : ISpecimenBuilder
    {
        public object Create(object request, ISpecimenContext context)
        {
            var type = request as Type;
            if (type != null && type.IsGenericType && typeof (Lazy<>).IsAssignableFrom(type.GetGenericTypeDefinition()))
            {
                return GetType()
                    .GetMethod("LazyCreator", BindingFlags.NonPublic | BindingFlags.Instance)
                    .MakeGenericMethod(type.GetGenericArguments())
                    .Invoke(this, new[]{context});
            }
            return new NoSpecimen(request);
        }

        private Lazy<T> LazyCreator<T>(ISpecimenContext context)
        {
            return new Lazy<T>(context.Create<T>);
        } 
    }

    public class Bla : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.ResidueCollectors.Add(new EnumerationBuilder());
        }
    }

    public class EnumerationBuilder : ISpecimenBuilder
    {
        public object Create(object request, ISpecimenContext context)
        {
            try
            {
                var type = request as Type;
                if (type != null && typeof (Enumeration<>).MakeGenericType(type).IsAssignableFrom(type))
                {
                    var random = context.CreateAnonymous<int>();
                    var fieldOperators = EnumerationUtility.GetEnumerations(type).ToArray();
                    return fieldOperators.ElementAt(random%fieldOperators.Length);
                }
            }
            catch (ArgumentException)
            {

            }

            return new NoSpecimen(request);
        }
    }

    public class EnumerationUtility
    {
        public static IEnumerable<IEnumeration> GetEnumerations(Type enumerationType)
        {
            return enumerationType
                .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
                .Where(info => enumerationType.IsAssignableFrom(info.FieldType))
                .Select(info => info.GetValue(null))
                .Cast<IEnumeration>();
        }
    }
}