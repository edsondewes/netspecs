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
    }
}
