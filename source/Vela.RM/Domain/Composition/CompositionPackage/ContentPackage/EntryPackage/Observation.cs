using System;
using Vela.RM.Core.DataStructures.HistoryPackage;
using Vela.RM.Core.DataStructures.ItemStructurePackage;
using Vela.RM.Core.Support;

namespace Vela.RM.Domain.Composition.CompositionPackage.ContentPackage.EntryPackage
{
	/// <summary>
	/// Entry subtype for all clinical data in the past or present, i.e. which (by the time it is recorded) has already occurred. OBSERVATION data is expressed using the class <see cref="History{T}"/>, which guarantees that it is situated in time.
	/// Observation is used for all notionally objective (i.e. measured in some way) observations of phenomena, and patient-reported phenomena, e.g. pain.
	/// Not used for recording opinion or future statements of any kind, including instructions, intentions, plans etc.
	/// </summary>
	[Serializable]
	[OpenEhrName("OBSERVATION")]
	public class Observation : CareEntry
	{
		/// <summary>
		/// The data of this observation, in the form of a history of values which may be of any complexity.
		/// </summary>
		[OpenEhrName("data")]
		public History<ItemStructure> Data { get; set; }

		/// <summary>
		/// Optional recording of the state of subject of this observation during the observation process, in the form of a separate history of values which may be of any complexity. State may also be recorded within the History of the data attribute.
		/// </summary>
		[OpenEhrName("state")]
		public History<ItemStructure> State { get; set; }
	}
}
