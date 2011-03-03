using System.Linq;
using Raven.Client;
using Vela.Common.Dal.RavenDB;
using Vela.RM.Domain.Ehr.EhrPackage;
using Vela.RM.Domain.Repositories;

namespace Vela.RM.Dal.Repositories
{
	public class EhrRootRepository : RavenRepository<EhrRoot>, IEhrRootRepository
	{
		public EhrRootRepository(IDocumentSession session, IQueryable<EhrRoot> collection) : base(session, collection)
		{
		}
	}
}
