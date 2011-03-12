//-----------------------------------------------------------------------
// <copyright file="IFolderVersionRepository.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using Vela.RM.Domain.Entities;

namespace Vela.RM.Domain.Repositories
{
	public interface IFolderVersionRepository : IGenericVersionRepository<FolderVersion>
	{
	}
}