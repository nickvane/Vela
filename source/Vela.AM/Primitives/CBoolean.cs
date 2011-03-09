using System;

namespace Vela.AM.Primitives
{
    /// <summary>
    /// Constraint on instances of Boolean.
    /// Both attributes cannot be set to False, since this would mean that the Boolean value being constrained cannot be True or False.
    /// </summary>
	public class CBoolean : CPrimitiveBase<bool>
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
    	/// Generate a default value from this constraint object
    	/// </summary>
    	public override bool DefaultValue { get; set; }

    	/// <summary>
        /// 
        /// </summary>
        public override bool HasAssumedValue { get; set; }

    	/// <summary>
    	/// Value to be assumed if none sent in data
    	/// </summary>
    	public override bool AssumedValue { get; set; }

    	/// <summary>
    	/// True if a_value is valid with respect to constraint expressed in concrete instance of this type.
    	/// </summary>
    	/// <param name="value"></param>
    	/// <returns></returns>
    	public override bool IsValidValue(bool value)
    	{
    		throw new NotImplementedException();
    	}
    }
}
