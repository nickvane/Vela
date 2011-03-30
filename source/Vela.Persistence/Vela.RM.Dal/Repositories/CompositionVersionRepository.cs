//-----------------------------------------------------------------------
// <copyright file="CompositionVersionRepository.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System.Linq;
using Vela.RM.Domain.Compositions.CompositionPackage;
using Vela.RM.Domain.Entities;
using Vela.RM.Domain.Repositories;

namespace Vela.RM.Dal.Repositories
{
	public class CompositionVersionRepository : GenericVersionRepository<CompositionVersion, Composition>, ICompositionVersionRepository
	{
		public CompositionVersionRepository(IQueryable<CompositionVersion> collection = null) : base(collection)
		{
		}
	}
}