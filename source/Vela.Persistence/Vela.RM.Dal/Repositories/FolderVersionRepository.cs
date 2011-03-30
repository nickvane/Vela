//-----------------------------------------------------------------------
// <copyright file="FolderVersionRepository.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System.Linq;
using Vela.RM.Core.Common.DirectoryPackage;
using Vela.RM.Domain.Entities;
using Vela.RM.Domain.Repositories;

namespace Vela.RM.Dal.Repositories
{
	public class FolderVersionRepository : GenericVersionRepository<FolderVersion, Folder>, IFolderVersionRepository
	{
		public FolderVersionRepository(IQueryable<FolderVersion> collection = null)
			: base(collection)
		{
		}
	}
}