//-----------------------------------------------------------------------
// <copyright file="ExprUnaryOperator.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using Vela.RM.Core.Support;

namespace Vela.AM.Assertions
{
	/// <summary>
	/// Unary operator expression node.
	/// </summary>
	[OpenEhrName("EXPR_UNARY_OPERATOR")]
	public class ExprUnaryOperator : ExprOperator
	{
		/// <summary>
		/// Operand node.
		/// </summary>
		[OpenEhrName("operand")]
		public ExprItem Operand { get; set; }
	}
}