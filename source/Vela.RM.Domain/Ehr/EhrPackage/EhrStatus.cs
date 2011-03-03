using System;
using Vela.RM.Core.Common.ArchetypedPackage;
using Vela.RM.Core.Common.GenericPackage;
using Vela.RM.Core.DataStructures.ItemStructurePackage;
using Vela.RM.Core.Support;

namespace Vela.RM.Domain.Ehr.EhrPackage
{
	/// <summary>
	/// Single object per EHR giving various EHR-wide information.
	/// </summary>
	[Serializable]
	[OpenEhrName("EHR_STATUS")]
	public class EhrStatus : Locatable
	{
		/// <summary>
		/// The subject of this EHR. The external_ref attribute can be used to contain a direct reference to the subject in a demographic or identity service. Alternatively, the association between patients and their records may be done elsewhere for security reasons.
		/// </summary>
		[OpenEhrName("subject")]
		public PartySelf Subject { get; set; }

		/// <summary>
		/// True if this EHR should be included in population queries, i.e. if this EHR is considered active in the population.
		/// </summary>
		[OpenEhrName("is_queryable")]
		public bool IsQueryable { get; set; }

		/// <summary>
		/// True if this EHR is allowed to be written to.
		/// </summary>
		[OpenEhrName("is_modifiable")]
		public bool IsModifiable { get; set; }

		/// <summary>
		/// Any other details of the EHR summary object, in the form of an archetyped Item_structure.
		/// </summary>
		[OpenEhrName("other_details")]
		public ItemStructure OtherDetails { get; set; }
	}
}
