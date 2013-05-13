using System;
using Moq;
using Ploeh.AutoFixture.Xunit;
using Xunit;
using Xunit.Extensions;

namespace iDDD.IssueTracker.Test
{
    public class ProductTest
    {
        [Fact]
        public void Fact()
        {
            
        }
        [Theory, AutoMoqData]
        public void Foo([Frozen]Mock<IDisposable> disposable, asdasd bla)
        {
            disposable.Verify(x => x.Dispose());
        }
    }
    public class asdasd
    {
        public asdasd(IDisposable disposable)
        {
            disposable.Dispose();
        }
    }
}
