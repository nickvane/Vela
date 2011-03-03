using System.Collections.Generic;

namespace Vela.AM.Assertions
{
	/// <summary>
	/// Structural model of a typed first order predicate logic assertion, in the form of an expression tree, including optional variable definitions.
	/// </summary>
	public class Assertion
	{
		/// <summary>
		/// Expression tag, used for differentiating multiple assertions
		/// </summary>
		public string Tag { get; set; }
		/// <summary>
		/// Root of expression tree.
		/// </summary>
		public ExprItem Expression { get; set; }
		/// <summary>
		/// String form of expression, in case an expression evaluator taking String expressions is used for evaluation.
		/// </summary>
		public string ExpressionString { get; set; }
		/// <summary>
		/// Definitions of variables used in the assertion expression.
		/// </summary>
		public IList<AssertionVariable> Variables { get; set; }
	}
}
