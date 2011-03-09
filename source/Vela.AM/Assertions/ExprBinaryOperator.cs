//-----------------------------------------------------------------------
// <copyright file="ExprBinaryOperator.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using Vela.RM.Core.Support;

namespace Vela.AM.Assertions
{
	/// <summary>
	/// Binary operator expression node.
	/// </summary>
	[OpenEhrName("EXPR_BINARY_OPERATOR")]
	public class ExprBinaryOperator : ExprOperator
	{
		/// <summary>
		/// Left operand node
		/// </summary>
		[OpenEhrName("left_operand")]
		public ExprItem LeftOperand { get; set; }

		/// <summary>
		/// Right operand node
		/// </summary>
		[OpenEhrName("right_operand")]
		public ExprItem RightOperand
		{
			get;
			set;
		}
	}
}