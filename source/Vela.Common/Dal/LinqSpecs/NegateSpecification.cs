using System;
using System.Linq.Expressions;

namespace Vela.Common.Dal.LinqSpecs
{
    /// <summary>
    /// The negate specification.
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public class NegateSpecification<T> : Specification<T>
    {
        private readonly Specification<T> _spec;

        /// <summary>
        /// NegateSpecification Constructor
        /// </summary>
        /// <param name="spec"></param>
        public NegateSpecification(Specification<T> spec)
        {
            _spec = spec;
        }

        /// <summary>
        /// Is the specification satisfied?
        /// </summary>
        /// <returns></returns>
        public override Expression<Func<T, bool>> IsSatisfiedBy()
        {
            return Expression.Lambda<Func<T, bool>>(
                Expression.Not(_spec.IsSatisfiedBy().Body), _spec.IsSatisfiedBy().Parameters);
        }

        /// <summary>
        /// Parameters
        /// </summary>
        protected override object[] Parameters
        {
            get
            {
                return new[] {_spec};
            }
        }
    }
}