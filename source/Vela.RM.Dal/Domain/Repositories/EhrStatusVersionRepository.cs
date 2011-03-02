using System.Linq;
using Raven.Client;
using Vela.RM.Domain.Ehr.EhrPackage;
using Vela.RM.Domain.Entities;
using Vela.RM.Domain.Repositories;

namespace Vela.RM.Dal.Domain.Repositories
{
	public class EhrStatusVersionRepository : GenericVersionRepository<EhrStatusVersion, EhrStatus>, IEhrStatusVersionRepository
	{
		public EhrStatusVersionRepository(IDocumentSession session, IQueryable<EhrStatusVersion> collection)
			: base(session, collection)
		{
		}
	}
}
