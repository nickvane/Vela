using System.Collections.Generic;
using Vela.RM.Core.DataTypes.QuantityPackage;
using Vela.RM.Core.Support;

namespace Vela.AM.ConstraintModel
{
	/// <summary>
	/// Abstract model of constraint on any kind of attribute node.
	/// </summary>
	[OpenEhrName("C_ATTRIBUTE")]
	public abstract class CAttribute : ArchetypeConstraint
	{
		/// <summary>
		/// Reference model attribute within the enclosing type represented by a C_OBJECT.
		/// </summary>
		[OpenEhrName("rm_attribute_name")]
		public string ReferenceModelAttributeName { get; set; }

		/// <summary>
		/// Constraint on every attribute, regardless of whether it is singular or of a container type, which indicates whether its target object exists or not (i.e. is mandatory or not).
		/// </summary>
		[OpenEhrName("existence")]
		public Interval<int> Existence { get; set; }

		/// <summary>
		/// Child C_OBJECT nodes. Each such node represents a constraint on the type of this attribute in its reference model. Multiples occur both for multiple items in the case of container attributes, and alternatives in the case of singular attributes.
		/// </summary>
		[OpenEhrName("children")]
		public List<CObject> Children { get; set; }
	}
}