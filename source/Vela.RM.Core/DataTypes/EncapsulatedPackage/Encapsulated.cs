using System;
using Vela.RM.Core.DataTypes.BasicPackage;
using Vela.RM.Core.DataTypes.TextPackage;
using Vela.RM.Core.Support;

namespace Vela.RM.Core.DataTypes.EncapsulatedPackage
{
	/// <summary>
	/// Abstract class defining the common meta-data of all types of encapsulated data.
	/// </summary>
	[Serializable, OpenEhrName("DV_ENCAPSULATED")]
	public abstract class Encapsulated : DataValue
	{
		/// <summary>
		/// Name of character encoding scheme in which this value is encoded. Coded from openEHR Code Set “character sets”. Unicode is the default assumption in openEHR, with UTF-8 being the assumed encoding. This attribute allows for variations from these assumptions.
		/// </summary>
		[OpenEhrName("charset")]
		public CodePhrase Charset
		{
			get;
			set;
		}

		/// <summary>
		/// Optional indicator of the localised language in which the data is written, if relevant. Coded from openEHR Code Set “languages”.
		/// </summary>
		[OpenEhrName("language")]
		public CodePhrase Language
		{
			get;
			set;
		}

		/// <summary>
		/// Original size in bytes of unencoded encapsulated data. I.e. encodings such as base64, hexadecimal etc do not change the value of this attribute.
		/// </summary>
		[OpenEhrName("size")]
		public abstract int Size
		{
			get;
			set;
		}
	}
}
