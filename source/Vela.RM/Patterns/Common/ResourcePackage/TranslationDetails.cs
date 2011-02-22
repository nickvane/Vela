using System.Collections.Generic;
using Vela.RM.Core.DataTypes.TextPackage;
using Vela.RM.Core.Support;

namespace Vela.RM.Patterns.Common.ResourcePackage
{
	/// <summary>
	/// Class providing details of a natural language translation.
	/// </summary>
	[OpenEhrName("TRANSLATION_DETAILS")]
	public class TranslationDetails
	{
		///<summary>
		/// Language of translation
		///</summary>
		[OpenEhrName("language")]
		public CodePhrase Language { get; set; }

		///<summary>
		/// Translator name and other demographic details
		///</summary>
		[OpenEhrName("author")]
		public IDictionary<string, string> Author { get; set; }

		///<summary>
		/// Accreditation of translator, usually a national translator’s association id
		///</summary>
		[OpenEhrName("accreditation")]
		public string Accreditation { get; set; }

		///<summary>
		/// Any other meta-data
		///</summary>
		[OpenEhrName("other_details")]
		public IDictionary<string, string> OtherDetails { get; set; }
	}
}