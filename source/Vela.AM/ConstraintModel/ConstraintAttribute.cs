using System.Collections.Generic;
using Vela.RM.Core.Support;

namespace Vela.AM.ConstraintModel
{
	/// <summary>
	/// Abstract model of constraint on any kind of attribute node.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1711:IdentifiersShouldNotHaveIncorrectSuffix"), OpenEhrName("C_ATTRIBUTE")]
	public abstract class ConstraintAttribute : ArchetypeConstraint
	{
		private IList<ConstraintObject> _children;

		/// <summary>
		/// Reference model attribute within the enclosing type represented by a C_OBJECT.
		/// </summary>
		[OpenEhrName("rm_attribute_name")]
		public string ReferenceModelAttributeName { get; set; }

		//TODO: interval with int
		//public Interval<int> Existence { get; set; }

		/// <summary>
		/// Child C_OBJECT nodes. Each such node represents a constraint on the type of this attribute in its reference model. Multiples occur both for multiple items in the case of container attributes, and alternatives in the case of singular attributes.
		/// </summary>
		[OpenEhrName("children")]
		public IList<ConstraintObject> Children
		{
			get
			{
				return _children ?? (_children = new List<ConstraintObject>());
			}
		}
	}
}
