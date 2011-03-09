﻿//-----------------------------------------------------------------------
// <copyright file="Link.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System;
using Vela.RM.Core.DataTypes.TextPackage;
using Vela.RM.Core.DataTypes.UriPackage;
using Vela.RM.Core.Support;

namespace Vela.RM.Core.Common.ArchetypedPackage
{
	/// <summary>
	/// The LINK type defines a logical relationship between two items, such as two ENTRYs or an ENTRY and a COMPOSITION. Links can be used across compositions, and across EHRs. Links can potentially be used between interior (i.e. non archetype root) nodes, although this probably should be prevented in archetypes. Multiple LINKs can be attached to the root object of any archetyped structure to give the effect of a 1->N link
	/// USE: 1:1 and 1:N relationships between  archetyped content elements (e.g. ENTRYs) can be expressed by using one, or more than one, respectively,  DV_LINKs. Chains of links can be used to see “problem threads” or other logical groupings of items.
	/// MISUSE: Links should be between archetyped structures only, i.e. between objects representing complete domain concepts because relationships between sub-elements of whole concepts are not necessarily meaningful, and may be downright confusing. Sensible links only exist between whole ENTRYs,  SECTIONs, COMPOSITIONs and so on.
	/// </summary>
	[Serializable]
	[OpenEhrName("LINK")]
	public class Link
	{
		/// <summary>
		/// Used to describe the relationship, usually in clinical terms, such  as “in response to” (the relationship between test results and an order), “follow-up to” and so on. Such relationships can represent any clinically meaningful connection between pieces of information. 
		/// Values for meaning include those described in Annex C, ENV 13606 pt 2 [11] under the categories of “generic”, “documenting and reporting”, “organisational”, “clinical”, “circumstancial”, and “view management”.
		/// </summary>
		[OpenEhrName("meaning")]
		public Text Meaning { get; set; }

		/// <summary>
		/// The  type attribute is used to indicate a clinical or domain-level meaning for the kind of link, for example “problem” or “issue”. If type values are designed appropriately, they can be used by the requestor of EHR extracts to categorise links which must be followed and which can be broken when the extract is created.
		/// </summary>
		[OpenEhrName("type")]
		public Text MeaningType { get; set; }

		/// <summary>
		/// The logical “to” object  in the link relation, as per the linguistic sense of the meaning attribute.
		/// </summary>
		[OpenEhrName("target")]
		public EhrUri Target { get; set; }
	}
}