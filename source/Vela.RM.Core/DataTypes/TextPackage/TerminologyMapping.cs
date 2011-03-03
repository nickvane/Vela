using System;
using Vela.RM.Core.Support;

namespace Vela.RM.Core.DataTypes.TextPackage
{
	/// <summary>
	/// Represents a coded term mapped to a <see cref="Text"/>, and the relative match of the target term with respect to the mapped item. Plain or coded text items may appear in the EHR for which one or mappings in  alternative terminologies are required. Mappings are only used to enable computer processing, so they can only be instances of <see cref="CodedText"/>.
	/// USE: Used for adding classification terms (e.g. adding ICD classifiers to SNOMED descriptive terms), or mapping into equivalents in other terminologies (e.g. across nursing vocabularies).
	/// </summary>
	[Serializable, OpenEhrName("TERM_MAPPING")]
	public class TerminologyMapping
	{
		public TerminologyMapping()
		{
			Match = TextPackage.Match.Unknown;
		}
		/// <summary>
		/// The target term of the mapping.
		/// </summary>
		[OpenEhrName("target")]
		public CodePhrase Target
		{
			get;
			set;
		}

		/// <summary>
		/// The relative match of the target term with respect to the mapped text item. Result meanings:
		/// • ‘>’: the mapping is to a broader term e.g. orginal text = “arbovirus infection”, target = “viral infection”
		/// • ‘=’: the mapping is to a (supposedly) equivalent to the original item 
		/// • ‘&lt;’: the mapping is to a narrower term. e.g. original text = “diabetes”, mapping = “diabetes mellitus”.
		/// • ‘?’: the kind of mapping is unknown. The first three values are taken from the ISO standards 2788 (“Guide to Establishment and development of monolingual thesauri”) and 5964 (“Guide to Establishment and development of multilingual thesauri”).
		/// </summary>
		[OpenEhrName("match")]
		public Match Match
		{
			get;
			set;
		}

		/// <summary>
		/// Purpose of the mapping e.g. “automated data mining”, “billing”, “interoperability”
		/// </summary>
		[OpenEhrName("purpose")]
		public CodedText Purpose
		{
			get;
			set;
		}

		public bool IsNarrower()
		{
			return this.Match == Match.IsNarrower;
		}

		public bool IsEquivalent()
		{
			return this.Match == Match.IsEqual;
		}

		public bool IsBroader()
		{
			return this.Match == Match.IsBroader;
		}

		public bool IsUnknown()
		{
			return this.Match == Match.Unknown;
		}

		/// <summary>
		/// True if match valid.
		/// </summary>
		[OpenEhrName("is_valid_match_code")]
		public bool IsValidMatchCode()
		{
			return true;
		}
	}
}
