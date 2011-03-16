//-----------------------------------------------------------------------
// <copyright file="EhrRootRepository.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System.Linq;
using Raven.Client;
using Vela.Common.Dal;
using Vela.RM.Domain.Ehr.EhrPackage;
using Vela.RM.Domain.Repositories;

namespace Vela.RM.Dal.Repositories
{
	public class EhrRootRepository : BaseRepository<EhrRoot>, IEhrRootRepository
	{
		public EhrRootRepository(IDocumentSession session, IQueryable<EhrRoot> collection = null)
			: base(session, collection)
		{
		}
	}
}