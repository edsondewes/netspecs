using System.Linq;
using netspecs.EF.Tests.Fixtures;
using Xunit;

namespace netspecs.EF.Tests
{
    public class NegateOperatorTest : TestBase
    {
        [Fact]
        public void ShouldNegateExpression()
        {
            var spec = new GenericSpecification<User>(user => user.IsMale);
            var result = this.Context.Users.Where(!spec).Single();

            Assert.Equal("Maria Lucia", result.Name);
        }
    }
}
