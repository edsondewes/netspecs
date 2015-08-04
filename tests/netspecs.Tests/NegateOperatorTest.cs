using System.Linq;
using netspecs.Tests.Fixtures;
using Xunit;

namespace netspecs.Tests
{
    public class NegateOperatorTest
    {
        [Fact]
        public void ShouldNegateExpression()
        {
            var spec = new GenericSpecification<User>(user => user.IsMale);
            var result = new UserRepository().Where(!spec).Single();

            Assert.Equal("Maria Lucia", result.Name);
        }
    }
}
