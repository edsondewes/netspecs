using System.Linq;
using netspecs.EF.Tests.Fixtures;
using Xunit;

namespace netspecs.EF.Tests
{
    public class MultipleOperatorsTest : TestBase
    {
        [Fact]
        public void AndPlusOr()
        {
            var spec1 = new GenericSpecification<User>(user => user.IsMale);
            var spec2 = new GenericSpecification<User>(user => user.FavoriteNumber == 3);
            var spec3 = new GenericSpecification<User>(user => !user.IsMale);
            var spec4 = new GenericSpecification<User>(user => user.FavoriteNumber == 2);

            var result = this.Context.Users.Where((spec1 & spec2) | (spec3 & spec4)).ToList();

            Assert.Collection(result,
                user => Assert.Equal("Maria Lucia", user.Name),
                user => Assert.Equal("Johny Pericles", user.Name));
        }

        [Fact]
        public void AndPlusNegate()
        {
            var spec1 = new GenericSpecification<User>(user => user.IsMale);
            var spec2 = new GenericSpecification<User>(user => user.FavoriteNumber == 3);

            var result = this.Context.Users.Where(!(spec1 & spec2)).ToList();

            Assert.Collection(result,
                user => Assert.Equal("Jorge Mario", user.Name),
                user => Assert.Equal("Maria Lucia", user.Name),
                user => Assert.Equal("John Lister", user.Name));
        }

        [Fact]
        public void OrPlusNegate()
        {
            var spec1 = new GenericSpecification<User>(user => !user.IsMale);
            var spec2 = new GenericSpecification<User>(user => user.Name == "John Lister");

            var result = this.Context.Users.Where(!(spec1 | spec2)).ToList();

            Assert.Collection(result,
                user => Assert.Equal("Jorge Mario", user.Name),
                user => Assert.Equal("Johny Pericles", user.Name));
        }

        [Fact]
        public void AllOperators()
        {
            var spec1 = new GenericSpecification<User>(user => user.FavoriteNumber == 1);
            var spec2 = new GenericSpecification<User>(user => user.Name == "John Lister");

            var spec3 = new GenericSpecification<User>(user => user.IsMale);

            var result = this.Context.Users.Where(!((spec1 & spec2) | !spec3)).ToList();

            Assert.Collection(result,
                user => Assert.Equal("Jorge Mario", user.Name),
                user => Assert.Equal("Johny Pericles", user.Name));
        }
    }
}
