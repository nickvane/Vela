//-----------------------------------------------------------------------
// <copyright file="EhrAccessVersionRepository.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System.Linq;
using Raven.Client;
using Vela.RM.Domain.Ehr.EhrPackage;
using Vela.RM.Domain.Entities;
using Vela.RM.Domain.Repositories;

namespace Vela.RM.Dal.Repositories
{
	public class EhrAccessVersionRepository : GenericVersionRepository<EhrAccessVersion, EhrAccess>, IEhrAccessVersionRepository
	{
		public EhrAccessVersionRepository(IDocumentSession session, IQueryable<EhrAccessVersion> collection = null)
			: base(session, collection)
		{
		}
	}
}