using System.Collections.Generic;
using Vela.RM.Core.Support;
using Vela.RM.Core.Support.IdentificationPackage;
using Vela.RM.Patterns.Common.ArchetypedPackage;

namespace Vela.RM.Patterns.Common.DirectoryPackage
{
	/// <summary>
	/// The concept of a named folder.
	/// </summary>
	[OpenEhrName("folder")]
	public class Folder : Locatable
	{
		/// <summary>
		/// Sub-folders of this FOLDER.
		/// </summary>
		[OpenEhrName("folders")]
		public IList<Folder> Folders { get; set; }

		/// <summary>
		/// The list of references to other (usually) versioned objects logically in this folder.
		/// </summary>
		[OpenEhrName("items")]
		public IList<ObjectRef> Items { get; set; }
	}
}
