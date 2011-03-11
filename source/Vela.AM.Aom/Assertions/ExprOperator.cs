//-----------------------------------------------------------------------
// <copyright file="ExprOperator.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

namespace Vela.AM.Aom.Assertions
{
    /// <summary>
    /// Abstract parent of operator types.
    /// </summary>
    public abstract class ExprOperator : ExprItem
    {
        /// <summary>
        /// Code of operator.
        /// </summary>
        public OperatorKind Operator { get; set; }
        /// <summary>
        /// True if the natural precedence of operators is overridden in the expression represented by this node of the expression tree. If True, parentheses should be introduced around the totality of the syntax expression corresponding to this operator node and its operands.
        /// </summary>
        public bool IsPrecedenceOverriden { get; set; }
    }
}