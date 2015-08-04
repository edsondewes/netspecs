using System;
using System.Linq.Expressions;
using netspecs.Tests.Fixtures;
using Xunit;

namespace netspecs.Tests
{
    public class ParameterVisitorTest
    {
        [Fact]
        public void ShouldReplaceParameter()
        {
            Expression<Func<User, bool>> expr1 = user => user.Name == "name";
            Expression<Func<User, bool>> expr2 = user => user.IsMale;

            var parm1 = expr1.Parameters[0];
            var parm2 = expr2.Parameters[0];

            var visitor = new ParameterVisitor(parm2, parm1);
            var body = visitor.Visit(expr2);

            var lambda = Expression.Lambda(body, parm1);

            Assert.Equal(parm1, lambda.Parameters[0]);
        }

        [Fact]
        public void ShouldNotReplaceIfParameterIsDifferent()
        {
            Expression<Func<User, bool>> expr1 = user => user.Name == "name";
            Expression<Func<User, bool>> expr2 = user => user.IsMale;
            Expression<Func<User, bool>> expr3 = user => user.FavoriteNumber == 3;

            var parm1 = expr1.Parameters[0];
            var parm2 = expr2.Parameters[0];
            var parm3 = expr3.Parameters[0];

            var visitor = new ParameterVisitor(parm1, parm2);
            var body = visitor.Visit(expr3);

            var lambda = Expression.Lambda(body, parm3);

            Assert.Equal(parm3, lambda.Parameters[0]);
        }
    }
}
