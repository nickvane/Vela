//-----------------------------------------------------------------------
// <copyright file="Folder.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System.Collections.Generic;
using Vela.RM.Core.Common.ArchetypedPackage;
using Vela.RM.Core.Support;
using Vela.RM.Core.Support.IdentificationPackage;

namespace Vela.RM.Core.Common.DirectoryPackage
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