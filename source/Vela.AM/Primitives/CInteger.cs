using System;
using System.Collections.Generic;
using Vela.RM.Core.DataTypes.QuantityPackage;

namespace Vela.AM.Primitives
{
	public class CInteger : CPrimitiveBase<int>
    {
		private HashSet<int> _list;

		/// <summary>
        /// Set of Integers specifying constraint
        /// </summary>
        public HashSet<int> List { get { return _list ?? (_list = new HashSet<int>()); } }

        /// <summary>
        /// Range of Integers specifying constraint
        /// </summary>
        public Interval<int> Range { get; set; }

        /// <summary>
        /// Generate a default value from this constraint object
        /// </summary>
		public override int DefaultValue
		{
			get;
			set;
		}

        /// <summary>
        /// True if there is an assumed value
        /// </summary>
        public override bool HasAssumedValue { get; set; }

        /// <summary>
        /// Value to be assumed if none sent in data
        /// </summary>
		public override int AssumedValue
		{
			get;
			set;
		}

        /// <summary>
        /// True if a_value is valid with respect to constraint expressed in concrete instance of this type.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
		public override bool IsValidValue(int value)
        {
            throw new NotImplementedException();
        }
    }
}
