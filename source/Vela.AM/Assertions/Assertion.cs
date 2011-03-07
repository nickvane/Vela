using System.Collections.Generic;
using Vela.RM.Core.Support;

namespace Vela.AM.Assertions
{
	/// <summary>
	/// Structural model of a typed first order predicate logic assertion, in the form of an expression tree, including optional variable definitions.
	/// </summary>
	[OpenEhrName("ASSERTION")]
	public class Assertion
	{
		/// <summary>
		/// Expression tag, used for differentiating multiple assertions
		/// </summary>
		[OpenEhrName("tag")]
		public string Tag { get; set; }

		/// <summary>
		/// Root of expression tree.
		/// </summary>
		[OpenEhrName("expression")]
		public ExprItem Expression { get; set; }

		/// <summary>
		/// String form of expression, in case an expression evaluator taking String expressions is used for evaluation.
		/// </summary>
		[OpenEhrName("string_expression")]
		public string ExpressionString { get; set; }

		/// <summary>
		/// Definitions of variables used in the assertion expression.
		/// </summary>
		[OpenEhrName("variables")]
		public IList<AssertionVariable> Variables { get; set; }
	}
}
