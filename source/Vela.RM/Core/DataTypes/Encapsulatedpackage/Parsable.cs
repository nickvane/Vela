using System;
using Vela.RM.Core.Support;

namespace Vela.RM.Core.DataTypes.Encapsulatedpackage
{
	/// <summary>
	/// Encapsulated data expressed as a parsable String. The internal model of the data item is not described in the openEHR model in common with other encapsulated types, but in this case, the form of the data is assumed to be plaintext, rather than compressed or other types of large binary data.
	/// USE: Used for representing values which are formal textual representations, e.g. guidelines.
	/// </summary>
	[Serializable, OpenEhrName("DV_PARSABLE")]
	public class Parsable : Encapsulated
	{
		/// <summary>
		/// The string, which may validly be empty in some syntaxes
		/// </summary>
		[OpenEhrName("value")]
		public string Value
		{
			get;
			set;
		}

		/// <summary>
		/// name of the formalism, e.g. “GLIF 1.0”, “proforma” etc.
		/// </summary>
		[OpenEhrName("formalism")]
		public string Formalism
		{
			get;
			set;
		}

		/// <summary>
		/// Size in bytes of value.
		/// </summary>
		[OpenEhrName("size")]
		public override int Size
		{
			get;
			set;
		}
	}
}
