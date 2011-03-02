using System.Linq;
using Raven.Client;
using Vela.RM.Domain.Ehr.EhrPackage;
using Vela.RM.Domain.Entities;
using Vela.RM.Domain.Repositories;

namespace Vela.RM.Dal.Domain.Repositories
{
	public class EhrAccessVersionRepository : GenericVersionRepository<EhrAccessVersion, EhrAccess>, IEhrAccessVersionRepository
	{
		public EhrAccessVersionRepository(IDocumentSession session, IQueryable<EhrAccessVersion> collection)
			: base(session, collection)
		{
		}
	}
}
