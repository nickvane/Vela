using System;

namespace Vela.AM.Primitives
{
    /// <summary>
    /// Constraint on instances of Boolean.
    /// Both attributes cannot be set to False, since this would mean that the Boolean value being constrained cannot be True or False.
    /// </summary>
    public class CBoolean : CPrimitive
    {
        /// <summary>
        /// 
        /// </summary>
        public bool IsTrueValid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsFalseValid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public new bool DefaultValue { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public override bool HasAssumedValue { get; set; }

        /// <summary>
        /// The value to assume if this item is not included in data, due to being part of an optional structure.
        /// </summary>
        public new bool AssumedValue { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool IsValidValue(bool value)
        {
            throw new NotImplementedException();
        }
    }
}
