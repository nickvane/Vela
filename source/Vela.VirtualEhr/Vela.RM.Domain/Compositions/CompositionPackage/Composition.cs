//-----------------------------------------------------------------------
// <copyright file="Composition.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Vela.RM.Core.Common.ArchetypedPackage;
using Vela.RM.Core.Common.GenericPackage;
using Vela.RM.Core.DataTypes.TextPackage;
using Vela.RM.Core.Support;
using Vela.RM.Domain.Compositions.CompositionPackage.ContentPackage;

namespace Vela.RM.Domain.Compositions.CompositionPackage
{
	/// <summary>
	/// One version in a VersionedComposition. A composition is considered the unit of modification of the record, the unit of transmission in record extracts, and the unit of attestation by authorising clinicians. In this latter sense, it may be considered equivalent to a signed document.
	/// </summary>
	[Serializable]
	[OpenEhrName("COMPOSITION")]
	public class Composition : Locatable
	{
		private IList<ContentItem> _content;

		/// <summary>
		/// The content of this Composition.
		/// </summary>
		[OpenEhrName("content")]
		public IList<ContentItem> Content
		{
			get { return _content ?? (_content = new List<ContentItem>()); }
		}

		/// <summary>
		/// The clinical session context of this Composition, i.e. the contextual attributes of the clinical session.
		/// </summary>
		[OpenEhrName("context")]
		public EventContext Context { get; set; }

		/// <summary>
		/// The person primarily responsible for the content of the Composition (but not necessarily its committal into the EHR system). This is the identifier which should appear on the screen. It may or may not be the person who entered the data. When it is the patient, the special “self” instance of PARTY_PROXY will be used.
		/// </summary>
		[OpenEhrName("composer")]
		public PartyProxy Composer { get; set; }

		/// <summary>
		/// Indicates what broad category this Composition belongs to, e.g. “persistent” - of longitudinal validity, “event”, “process” etc.
		/// </summary>
		[OpenEhrName("category")]
		public CodedText Category { get; set; }

		/// <summary>
		/// Mandatory indicator of the localised language in which this Composition is written. Coded from openEHR Code Set “languages”. The language of an Entry if different from the Composition is indicated in ENTRY.language.
		/// </summary>
		[OpenEhrName("language")]
		public CodePhrase Language { get; set; }

		/// <summary>
		/// Name of territory in which this Composition was written. Coded from openEHR “countries” code set, which is an expression of the ISO 3166 standard.
		/// </summary>
		[OpenEhrName("territory")]
		public CodePhrase Territory { get; set; }

		/// <summary>
		/// True if category is a “persistent” type, False otherwise. Useful for finding Compositions in an EHR which are guaranteed to be of interest to most users.
		/// </summary>
		[OpenEhrName("is_persistent")]
		public bool IsPersistent()
		{
			throw new NotImplementedException();
		}
	}
}