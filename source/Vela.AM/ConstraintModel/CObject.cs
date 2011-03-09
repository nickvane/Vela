//-----------------------------------------------------------------------
// <copyright file="CObject.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using Vela.RM.Core.DataTypes.QuantityPackage;
using Vela.RM.Core.Support;

namespace Vela.AM.ConstraintModel
{
	/// <summary>
	/// Abstract model of constraint on any kind of object node.
	/// </summary>
	[OpenEhrName("C_OBJECT")]
	public abstract class CObject : ArchetypeConstraint
	{
		/// <summary>
		/// Reference model type that this node corresponds to.
		/// </summary>
		[OpenEhrName("rm_type_name")]
		public string ReferenceModelTypeName { get; set; }

		/// <summary>
		/// Occurrences of this object node in the data, under the owning attribute. Upper limit can only be greater than 1 if owning attribute has a cardinality of more than 1).
		/// </summary>
		[OpenEhrName("occurences")]
		public Interval<int> Occurences { get; set; }

		/// <summary>
		/// Semantic id of this node, used to differentiate sibling nodes of the same type. [Previously called ‘meaning’]. Each node_id must be defined in the archetype ontology as a term code.
		/// </summary>
		[OpenEhrName("node_id")]
		public string NodeId { get; set; }

		/// <summary>
		/// C_ATTRIBUTE that owns this C_OBJECT.
		/// </summary>
		[OpenEhrName("parent")]
		public CAttribute Parent { get; set; }
	}
}