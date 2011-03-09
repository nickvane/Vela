//-----------------------------------------------------------------------
// <copyright file="UuId.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System;
using System.Text.RegularExpressions;
using Vela.RM.Core.Properties;

namespace Vela.RM.Core.Support.IdentificationPackage
{
	/// <summary>
	/// Model of the DCE Universal Unique Identifier or UUID which takes the form of hexadecimal integers separated by hyphens, following the pattern 8-4-4-4-12 as defined by the Open Group, CDE 1.1 Remote Procedure Call specification, Appendix A. Also known as a GUID.
	/// </summary>
	[Serializable, OpenEhrName("UUID")]
	public class UUId : Uid
	{
		private string _value;

		private const string RegEx = @"^[A-Za-z0-9]{8}-[A-Za-z0-9]{4}-[A-Za-z0-9]{4}-[A-Za-z0-9]{4}-[A-Za-z0-9]{12}$";

		/// <summary>
		/// 
		/// </summary>
		/// <param name="value">Value must be of form Guid.</param>
		public UUId(string value)
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
					throw new ArgumentException(string.Format(Resources.InvalidGuid, value));
				}
			}
		}

		public Guid ToGuid()
		{
			return new Guid(Value);
		}
	}
}