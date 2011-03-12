//-----------------------------------------------------------------------
// <copyright file="CompositionVersionRepository.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System.Linq;
using Raven.Client;
using Vela.RM.Domain.Compositions.CompositionPackage;
using Vela.RM.Domain.Entities;
using Vela.RM.Domain.Repositories;

namespace Vela.RM.Dal.Repositories
{
	public class CompositionVersionRepository : GenericVersionRepository<CompositionVersion, Composition>, ICompositionVersionRepository
	{
		public CompositionVersionRepository(IDocumentSession session, IQueryable<CompositionVersion> collection) : base(session, collection)
		{
		}
	}
}