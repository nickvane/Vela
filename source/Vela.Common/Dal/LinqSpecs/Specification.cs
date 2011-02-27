using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Linq;

namespace Vela.Common.Dal.LinqSpecs
{
    /// <summary>
    /// Specification
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Specification<T>
    {
        /// <summary>
        /// Is the specification satisfied?
        /// </summary>
        /// <returns></returns>
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public abstract Expression<Func<T, bool>> IsSatisfiedBy();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="spec1"></param>
        /// <param name="spec2"></param>
        /// <returns></returns>
        public static Specification<T> operator &(Specification<T> spec1, Specification<T> spec2)
        {
            return new AndSpecification<T>(spec1, spec2);
        }

        ///<summary>
        ///</summary>
        ///<param name="spec1"></param>
        ///<returns></returns>
        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", Justification = "This is required!")]
        public static bool operator false(Specification<T> spec1)
        {
            return false; // no-op. & and && do exactly the same thing.
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="spec1"></param>
        /// <returns></returns>
        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", Justification = "This is required!")]
        public static bool operator true(Specification<T> spec1)
        {
            return false; // no - op. & and && do exactly the same thing.
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="spec1"></param>
        /// <param name="spec2"></param>
        /// <returns></returns>
        public static Specification<T> operator |(Specification<T> spec1, Specification<T> spec2)
        {
            return new OrSpecification<T>(spec1, spec2);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="spec1"></param>
        /// <returns></returns>
        public static Specification<T> operator !(Specification<T> spec1)
        {
            return new NegateSpecification<T>(spec1);
        }

        /// <summary>
        /// Parameters
        /// </summary>
        protected virtual object[] Parameters { get { return new object[] {Guid.NewGuid()}; } }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Specification<T> other)
        {
            return Parameters.SequenceEqual(other.Parameters);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Specification<T>)obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return Parameters.GetHashCode();
        }

    }
}