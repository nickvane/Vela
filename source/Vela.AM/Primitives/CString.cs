using System;
using System.Collections.Generic;

namespace Vela.AM.Primitives
{
    /// <summary>
    /// Constraint on instances of STRING.
    /// </summary>
    public class CString : CPrimitive
    {
        /// <summary>
        /// Regular expression pattern for proposed instances of String to match.
        /// </summary>
        public string Pattern { get; set; }

        /// <summary>
        /// Set of Strings specifying constraint
        /// </summary>
        public HashSet<string> List { get; set; }

        /// <summary>
        /// True if the list is being used to specify the constraint but is not considered exhaustive
        /// </summary>
        public bool IsListOpen { get; set; }

        /// <summary>
        /// Generate a default value from this constraint object
        /// </summary>
        public new string DefaultValue { get; set; }

        /// <summary>
        /// True if there is an assumed value
        /// </summary>
        public override bool HasAssumedValue { get; set; }

        /// <summary>
        /// The value to assume if this item is not included in data, due to being part of an optional structure.
        /// </summary>
        public new string AssumedValue { get; set; }

        /// <summary>
        /// True if a_value is valid with respect to constraint expressed in concrete instance of this type.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool IsValidValue(string value)
        {
            throw new NotImplementedException();
        }
    }
}
