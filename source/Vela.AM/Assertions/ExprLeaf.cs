//-----------------------------------------------------------------------
// <copyright file="ExprLeaf.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

namespace Vela.AM.Assertions
{
    /// <summary>
    /// Expression tree leaf item. This can represent one of:
    ///• a manifest constant of  any primitive type (Integer, Real, Boolean, String,  Character, Date, Time, Date_time, Duration), or (in future) of any complex reference model type, e.g. a DV_CODED_TEXT;
    ///• a path referring to a value in the archetype (paths with a leading ‘/’ are in the definition section; paths with no leading ‘/’ are in the outer part of the archetype, e.g. “archetype_id/value” refers to the String value of the archetype_id attribute of the enclosing archetype;
    ///• a constraint, expressed in the form of concrete subtype of C_OBJECT; most often this will be a C_PRIMITIVE_OBJECT
    /// </summary>
    public class ExprLeaf : ExprItem
    {
        /// <summary>
        /// The value referred to; a manifest constant, an attribute path (in the form of a String), or for the right-hand side of a ‘matches’ node, a constraint, often a C_PRIMITIVE_OBJECT. [Future: paths including function names as well, even if not constrained in the archetype - as long as they are in the reference model].
        /// </summary>
        public object Item { get; set; }

        /// <summary>
        /// Type of reference: “constant”, “attribute”, “function”, “constraint”. The first three are used to indicate the referencing mechanism for an operand. The last is used to indicate a constraint operand, as happens in the case of the right-hand operand of the ‘matches’ operator.
        /// </summary>
        public string ReferenceType { get; set; }
    }
}