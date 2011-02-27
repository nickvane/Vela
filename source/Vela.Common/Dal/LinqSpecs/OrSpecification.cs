using System;
using System.Linq.Expressions;

namespace Vela.Common.Dal.LinqSpecs
{
    /// <summary>
    /// The or specification.
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public class OrSpecification<T> : Specification<T>
    {
        private readonly Specification<T> _spec1;
        private readonly Specification<T> _spec2;

        /// <summary>
        /// OrSpecification Constructor
        /// </summary>
        /// <param name="spec1"></param>
        /// <param name="spec2"></param>
        public OrSpecification(Specification<T> spec1, Specification<T> spec2)
        {
            _spec1 = spec1;
            _spec2 = spec2;
        }

        /// <summary>
        /// Parameters
        /// </summary>
        protected override object[] Parameters
        {
            get
            {
                return new object[]{_spec1, _spec2};
            }
        }

        /// <summary>
        /// Is the specification satisfied?
        /// </summary>
        /// <returns></returns>
        public override Expression<Func<T, bool>> IsSatisfiedBy()
        {
            
            var expr1 = _spec1.IsSatisfiedBy();
            var expr2 = _spec2.IsSatisfiedBy();

            ParameterExpression param = expr1.Parameters[0];
            if (ReferenceEquals(param, expr2.Parameters[0]))
            {
                return Expression.Lambda<Func<T, bool>>(Expression.OrElse(expr1.Body, expr2.Body), param);
            }
            return Expression.Lambda<Func<T, bool>>(Expression.OrElse(expr1.Body, Expression.Invoke(expr2, param)), param);
        }
        
    }
}