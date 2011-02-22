using Vela.RM.Core.DataTypes.TextPackage;
using Vela.RM.Core.Support;

namespace Vela.RM.Patterns.Common.GenericPackage
{
	/// <summary>
	/// Proxy type for identifying a party and its relationship to the subject of the record.
	/// Use where the relationship between the party and the subject of the record must be known.
	/// </summary>
	[OpenEhrName("PARTY_RELATED")]
	public class PartyRelated
	{
		/// <summary>
		/// Relationship of subject of this ENTRY to the subject of the record. May be coded. If it is the patient, coded as “self”.
		/// </summary>
		[OpenEhrName("relationship")]
		public CodedText Relationship { get; set; }
	}
}
