using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using netspecs.Tests.Fixtures;
using Xunit;

namespace netspecs.Tests
{
    public class AndOperatorTest
    {
        [Fact]
        public void ShouldMergeExpressions()
        {
            var isMaleSpec = new GenericSpecification<User>(user => user.IsMale);
            var favoriteNumberSpec = new GenericSpecification<User>(user => user.FavoriteNumber == 1);

            var result = new UserRepository().Where(isMaleSpec & favoriteNumberSpec).ToList();

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

            var result = new UserRepository().Single(spec1 & spec2 & spec3);

            Assert.Equal("Maria Lucia", result.Name);
        }
    }
}
