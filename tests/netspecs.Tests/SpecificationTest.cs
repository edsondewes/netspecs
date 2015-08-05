using System;
using System.Linq.Expressions;
using netspecs.Tests.Fixtures;
using Xunit;

namespace netspecs.Tests
{
    public class SpecificationTest
    {
        [Fact]
        public void ShoulImplicitConvertToExpression()
        {
            var spec = new GenericSpecification<User>(user => user.IsMale);

            Expression<Func<User, bool>> expression = spec;
            Assert.NotNull(expression);
        }

        [Fact]
        public void ShoulImplicitConvertToFunc()
        {
            var spec = new GenericSpecification<User>(user => user.IsMale);

            Func<User, bool> func = spec;
            Assert.NotNull(func);
        }

        [Fact]
        public void ShouldVerifySpecificItem()
        {
            var spec = new GenericSpecification<User>(u => u.FavoriteNumber > 3);

            var user1 = new User { FavoriteNumber = 4 };
            Assert.True(spec.IsSatisfiedBy(user1));

            var user2 = new User { FavoriteNumber = 1 };
            Assert.False(spec.IsSatisfiedBy(user2));
        }
    }
}
