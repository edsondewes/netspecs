﻿using System;
using System.Linq.Expressions;

namespace netspecs
{
    public abstract class Specification<T>
    {
        public static implicit operator Expression<Func<T, bool>>(Specification<T> spec)
        {
            return spec.IsSatisfiedBy();
        }

        public static implicit operator Func<T, bool>(Specification<T> spec)
        {
            return spec.IsSatisfiedBy().Compile();
        }

        public static Specification<T> operator &(Specification<T> left, Specification<T> right)
        {
            var leftExpression = left.IsSatisfiedBy();
            var rightExpression = right.IsSatisfiedBy();

            var parameter = leftExpression.Parameters[0];

            var visitor = new ParameterVisitor(rightExpression.Parameters[0], parameter);
            var rightBody = visitor.Visit(rightExpression.Body);

            var merged = Expression.Lambda<Func<T, bool>>(Expression.AndAlso(leftExpression.Body, rightBody), parameter);

            return new GenericSpecification<T>(merged);
        }

        public static Specification<T> operator |(Specification<T> left, Specification<T> right)
        {
            var leftExpression = left.IsSatisfiedBy();
            var rightExpression = right.IsSatisfiedBy();

            var parameter = leftExpression.Parameters[0];

            var visitor = new ParameterVisitor(rightExpression.Parameters[0], parameter);
            var rightBody = visitor.Visit(rightExpression.Body);

            var merged = Expression.Lambda<Func<T, bool>>(Expression.OrElse(leftExpression.Body, rightBody), parameter);

            return new GenericSpecification<T>(merged);
        }

        public static Specification<T> operator !(Specification<T> spec)
        {
            var expression = spec.IsSatisfiedBy();
            return new GenericSpecification<T>(Expression.Lambda<Func<T, bool>>(Expression.Not(expression.Body), expression.Parameters));
        }

        public abstract Expression<Func<T, bool>> IsSatisfiedBy();
    }
}
