using System;
using System.Text.RegularExpressions;
using Vela.RM.Properties;

namespace Vela.RM.Core.Support.IdentificationPackage
{
	/// <summary>
	/// Model of a reverse internet domain, as used to uniquely identify an internet domain. In the form of a dot-separated string in the reverse order of a domain name, specified by IETF RFC 1034 (http://www.ietf.org/rfc/rfc1034.txt).
	/// </summary>
	[Serializable, OpenEhrName("INTERNET_ID")]
	public class InternetId : Uid
	{
		private string _value;

		private const string RegEx = @"^([a-zA-Z0-9]([a-zA-Z0-9\-]{0,61}[a-zA-Z0-9])?\.)*[a-zA-Z0-9]([a-zA-Z0-9\-]{0,61}[a-zA-Z0-9])?$";

		public InternetId(string value)
			: base(value)
		{
		}

		[OpenEhrName("value")]
		public override string Value
		{
			get
			{
				return _value;
			}
			set
			{
				if (Regex.IsMatch(value, RegEx, RegexOptions.IgnoreCase))
				{
					_value = value;
				}
				else
				{
					throw new ArgumentException(string.Format(Resources.InvalidDomainName, value));
				}
			}
		}

		public override string ToString()
		{
			return Value;
		}
	}
}
