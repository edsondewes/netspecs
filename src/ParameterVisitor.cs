using System.Linq.Expressions;

namespace netspecs
{
    public class ParameterVisitor : ExpressionVisitor
    {
        private ParameterExpression oldParameter;
        private ParameterExpression newParameter;

        public ParameterVisitor(ParameterExpression oldParameter, ParameterExpression newParameter)
        {
            this.oldParameter = oldParameter;
            this.newParameter = newParameter;
        }

        protected override Expression VisitParameter(ParameterExpression node)
        {
            if (object.ReferenceEquals(node, oldParameter))
            {
                return newParameter;
            }

            return base.VisitParameter(node);
        }
    }
}
