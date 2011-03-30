//-----------------------------------------------------------------------
// <copyright file="Assertion.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System.Collections.Generic;
using Vela.RM.Core.Support;

namespace Vela.AM.Aom.Assertions
{
	/// <summary>
	/// Structural model of a typed first order predicate logic assertion, in the form of an expression tree, including optional variable definitions.
	/// </summary>
	[OpenEhrName("ASSERTION")]
	public class Assertion
	{
		private IList<AssertionVariable> _variables;

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
		public IList<AssertionVariable> Variables
		{
			get
			{
				return _variables ?? (_variables = new List<AssertionVariable>());
			}
			private set
			{
				_variables = value;
			}
		}
	}
}