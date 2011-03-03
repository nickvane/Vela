using System;
using Vela.RM.Core.DataStructures.ItemStructurePackage;
using Vela.RM.Core.Support;
using Vela.RM.Core.Support.IdentificationPackage;

namespace Vela.RM.Domain.Compositions.CompositionPackage.ContentPackage.EntryPackage
{
	/// <summary>
	/// The abstract parent of all clinical <see cref="CareEntry"/> subtypes. A <see cref="Entry"/> defines protocol and guideline attributes for all clinical Entry subtypes.
	/// </summary>
	[Serializable]
	[OpenEhrName("CARE_ENTRY")]
	public abstract class CareEntry : Entry
	{
		/// <summary>
		/// Description of the method (i.e. how) the information in this entry was arrived at. For <see cref="Observation"/>"s, this is a description of the method or instrument used. For <see cref="Instruction"/>s, how the evaluation was arrived at. For <see cref="Evaluation"/>s, how to execute the Instruction. This may take the form of references to guidelines, including manually followed and executable; knowledge references such as a paper in Medline; clinical reasons within a largercare process.
		/// </summary>
		[OpenEhrName("protocol")]
		public ItemStructure Protocol { get; set; }

		/// <summary>
		/// Optional external identifier of guideline creating this action if relevant
		/// </summary>
		[OpenEhrName("guideline_id")]
		public ObjectRef GuidelineId { get; set; }
	}
}
