using System;
using Vela.RM.Core.Support;

namespace Vela.RM.Core.DataTypes.BasicPackage
{
	/// <summary>
	/// Items which are truly boolean data, such as true/false or yes/no answers.
	/// USE: For such data, it is important to devise the meanings (usually questions in subjective data) carefully, so that the only allowed results are in fact true or false.
	/// MISUSE: The Boolean class should not be used as a replacement for naively modelled enumerated types such as male/female etc. Such values should be coded, and in any case the enumeration often has more than two values.
	/// </summary>
	[Serializable, OpenEhrName("DV_BOOLEAN")]
	public class Boolean : DataValue
	{
		/// <summary>
		/// Boolean value of this item.
		/// </summary>
		[OpenEhrName("value")]
		public bool Value
		{
			get;
			set;
		}
	}
}
