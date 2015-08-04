using System;
using System.Linq.Expressions;

namespace netspecs
{
    public class GenericSpecification<T> : Specification<T>
    {
        Expression<Func<T, bool>> expression;

        public GenericSpecification(Expression<Func<T, bool>> expression)
        {
            this.expression = expression;
        }

        public override Expression<Func<T, bool>> IsSatisfiedBy()
        {
            return expression;
        }
    }
}
