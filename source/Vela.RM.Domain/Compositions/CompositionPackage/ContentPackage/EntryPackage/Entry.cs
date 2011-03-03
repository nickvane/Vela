using System;
using System.Collections.Generic;
using Vela.RM.Core.Common.GenericPackage;
using Vela.RM.Core.DataTypes.TextPackage;
using Vela.RM.Core.Support;
using Vela.RM.Core.Support.IdentificationPackage;

namespace Vela.RM.Domain.Compositions.CompositionPackage.ContentPackage.EntryPackage
{
	/// <summary>
	/// The abstract parent of all <see cref="Entry"/> subtypes. An <see cref="Entry"/> is the root of a logical item of “hard” clinical information created in the “clinical statement” context, within a clinical session. There can be numerous such contexts in a clinical session. Observations and other Entry types only ever document information captured/created in the event documented by the enclosing Composition. 
	/// An <see cref="Entry"/> is also the minimal unit of information any query should return, since a whole <see cref="Entry"/> (including sub-parts) records spatial structure, timing information, and contextual information, as well as the subject and generator of the information.
	/// </summary>
	[Serializable]
	[OpenEhrName("ENTRY")]
	public abstract class Entry : ContentItem
	{
		private IList<Participation> _otherParticipations;

		/// <summary>
		/// Mandatory indicator of the localised language in which this Entry is written. Coded from openEHR Code Set “languages”.
		/// </summary>
		[OpenEhrName("language")]
		public CodePhrase Language { get; set; }

		/// <summary>
		/// Name of character set in which text values in this Entry are encoded. Coded from openEHR Code Set “character sets”.
		/// </summary>
		[OpenEhrName("encoding")]
		public CodePhrase Encoding { get; set; }

		/// <summary>
		/// Id of human subject of this <see cref="Entry"/>, e.g.:
		/// • organ donor
		/// • foetus
		/// • a family member
		/// • another clinically relevant person.
		/// </summary>
		[OpenEhrName("subject")]
		public PartyProxy Subject { get; set; }

		/// <summary>
		/// Optional identification of provider of the information in this <see cref="Entry"/>, which might be:
		/// • the patient
		/// • a patient agent, e.g. parent, guardian
		/// • the clinician
		/// • a device or software
		/// Generally only used when the recorder needs to make it explicit. Otherwise, Composition composer and other participants are assumed.
		/// </summary>
		[OpenEhrName("provider")]
		public PartyProxy Provider { get; set; }

		/// <summary>
		/// Other participations at <see cref="Entry"/> level.
		/// </summary>
		[OpenEhrName("other_participations")]
		public IList<Participation> OtherParticipations
		{
			get { return _otherParticipations ?? (_otherParticipations = new List<Participation>()); }
		}

		/// <summary>
		/// Identifier of externally held workflow engine data for this workflow execution, for this subject of care.
		/// </summary>
		[OpenEhrName("workflow_id")]
		public ObjectRef WorkflowId { get; set; }

		/// <summary>
		/// Returns True if this Entry is about the subject of the EHR, in which case the subject attribute is of type <see cref="PartySelf"/>.
		/// </summary>
		[OpenEhrName("subject_is_self")]
		public bool IsSubjectSelf()
		{
			throw new NotImplementedException();
		}
	}
}