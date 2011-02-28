using System;
using Vela.RM.Core.DataStructures.ItemStructurePackage;
using Vela.RM.Core.Support;

namespace Vela.RM.Domain.Compositions.CompositionPackage.ContentPackage.EntryPackage
{
	/// <summary>
	/// Entry subtype for administrative information, i.e. information about setting up the clinical process, but not itself clinically relevant. Archetypes will define contained information.
	/// Used for admistrative details of admission, episode, ward location, discharge, appointment (if not stored in a practice management or appointments system).
	/// Not used for any clinically significant information.
	/// </summary>
	[Serializable]
	[OpenEhrName("ADMIN_ENTRY")]
	public class AdminEntry : Entry
	{
		/// <summary>
		/// The data of the Entry; modelled in archetypes.
		/// </summary>
		[OpenEhrName("data")]
		public ItemStructure Data { get; set; }
	}
}
