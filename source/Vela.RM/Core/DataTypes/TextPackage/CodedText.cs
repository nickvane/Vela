using System;
using Vela.RM.Core.Support;

namespace Vela.RM.Core.DataTypes.TextPackage
{
	/// <summary>
	/// A text item whose value must be the rubric from a controlled terminology, the key (i.e. the ‘code’) of which is the  defining_code attribute. In other words: a CodedText is a combination of a CODE_PHRASE (effectively a code) and the rubric of that term, from a terminology service, in the language in which the data was authored.
	/// USE: Since CodedText is a subtype of Text, it can be used in place of it, effectively allowing the type Text to mean “a text item, which may optionally be coded”.
	/// MISUSE: If the intention is to represent a term code attached in some way to a fragment of plain text, DV_CODED_TEXT should not be used; instead use a DV_TEXT and a TERM_MAPPING to a CODE_PHRASE.
	/// </summary>
	[Serializable, OpenEhrName("DV_CODED_TEXT")]
	public class CodedText : Text
	{
		public CodedText(string value) : base(value)
		{
			
		}

		///<summary>
		/// The term which the ‘value’ attribute is the textual rendition (i.e. rubric) of.
		///</summary>
		[OpenEhrName("defining_code")]
		public CodePhrase DefiningCode
		{
			get;
			set;
		}
	}
}
