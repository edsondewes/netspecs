using System.Linq;
using netspecs.EF.Tests.Fixtures;
using Xunit;

namespace netspecs.EF.Tests
{
    public class AndOperatorTest : TestBase
    {
        [Fact]
        public void ShouldMergeExpressions()
        {
            var isMaleSpec = new GenericSpecification<User>(user => user.IsMale);
            var favoriteNumberSpec = new GenericSpecification<User>(user => user.FavoriteNumber == 1);

            var result = this.Context.Users.Where(isMaleSpec & favoriteNumberSpec).ToList();

            Assert.Collection(result,
                user => Assert.Equal("Jorge Mario", user.Name),
                user => Assert.Equal("John Lister", user.Name));
        }

        [Fact]
        public void ShouldAcceptMultipleExpressions()
        {
            var spec1 = new GenericSpecification<User>(user => user.FavoriteNumber == 2);
            var spec2 = new GenericSpecification<User>(user => !user.IsMale);
            var spec3 = new GenericSpecification<User>(user => user.Name == "Maria Lucia");

            var result = this.Context.Users.Single(spec1 & spec2 & spec3);

            Assert.Equal("Maria Lucia", result.Name);
        }
    }
}
