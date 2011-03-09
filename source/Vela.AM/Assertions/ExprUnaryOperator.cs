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
