using Vela.RM.Core.Support;

namespace Vela.AM.ConstraintModel
{
	/// <summary>
	/// Abstract parent type of domain-specific constrainer types, to be defined in external packages.
	/// </summary>
	[OpenEhrName("C_DOMAIN_TYPE")]
	public abstract class CDomainType : CDefinedObject
	{
		/// <summary>
		/// Standard (i.e. C_OBJECT) form of constraint.
		/// </summary>
		[OpenEhrName("standard_equivalent")]
		public CComplexObject StandardEquivalent { get; set; }
	}
}
