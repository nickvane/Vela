using System;
using System.Collections.Generic;
using Vela.RM.Core.Support;
using Vela.RM.Domain.Composition.CompositionPackage.ContentPackage.EntryPackage;

namespace Vela.RM.Domain.Composition.CompositionPackage.ContentPackage.NavigationPackage
{
	/// <summary>
	/// Represents a heading in a heading structure, or “section tree”.
	/// Created according to archetyped structures for typical headings such as SOAP, physical examination, but also pathology result heading structures.
	/// Should not be used instead of ENTRY hierarchical structures.
	/// </summary>
	[Serializable]
	[OpenEhrName("SECTION")]
	public class Section : ContentItem	
	{
		/// <summary>
		/// Ordered list of content items under this section, which may include:
		/// more <see cref="Section"/>s or <see cref="Entry"/>s
		/// </summary>
		[OpenEhrName("items")]
		public IList<ContentItem> Items { get; set; }
	}
}
