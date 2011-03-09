//-----------------------------------------------------------------------
// <copyright file="ExprItem.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using Vela.RM.Core.Support;

namespace Vela.AM.Assertions
{
	/// <summary>
	/// Abstract parent of all expression tree items.
	/// </summary>
	[OpenEhrName("EXPR_ITEM")]
	public abstract class ExprItem
	{
		/// <summary>
		/// Type name of this item in the mathematical sense. For leaf nodes, must be the name of a primitive type, or else a reference model type. The type for any relational or boolean operator will be “Boolean”, while the type for any arithmetic operator, will be “Real” or “Integer”.
		/// </summary>
		[OpenEhrName("type")]
		public string Type { get; set; }
	}
}