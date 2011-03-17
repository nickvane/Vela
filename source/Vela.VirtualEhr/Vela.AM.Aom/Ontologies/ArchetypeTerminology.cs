//-----------------------------------------------------------------------
// <copyright file="ArchetypeTerminology.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System.Collections.Generic;
using Vela.RM.Core.Support;

namespace Vela.AM.Aom.Ontologies
{
	/// <summary>
	/// Representation of any coded entity (term or constraint) in the archetype ontology.
	/// </summary>
	[OpenEhrName("ARCHETYPE_TERM")]
	public class ArchetypeTerminology
	{
		private IDictionary<string, string> _items;

		/// <summary>
		/// Code of this term
		/// </summary>
		[OpenEhrName("code")]
		public string Code { get; set; }

		/// <summary>
		/// Hash of keys (“text”, “description” etc) and corresponding values.
		/// </summary>
		[OpenEhrName("items")]
		public IDictionary<string, string> Items
		{
			get
			{
				return _items ?? (_items = new Dictionary<string, string>());
			}
			private set
			{
				_items = value;
			}
		}
	}
}