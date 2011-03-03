using System;
using Vela.RM.Core.Properties;
using Vela.RM.Core.Support;

namespace Vela.RM.Core.DataTypes.UriPackage
{
	/// <summary>
	/// A EhrUri is a <see cref="Uri" /> which has the scheme name “ehr”, and which can only reference elements in EHRs. The syntax is described below.
	// /USE: Used to reference elements in an EHR, which may be the current one, or another.
	/// </summary>
	[Serializable, OpenEhrName("DV_EHR_URI")]
	public class EhrUri : Uri
	{
		public EhrUri(string value)
			: base(value)
		{
		}

		public override string Value
		{
			get
			{
				return base.Value;
			}
			set
			{
				if (!value.StartsWith("ehr://"))
				{
					throw new ArgumentException(string.Format(Resources.InvalidEhrUri, value), "value");
				}
				base.Value = value;
			}
		}
	}
}
