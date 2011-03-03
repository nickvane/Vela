using Vela.Common.Dal.RavenDB;
using Vela.RM.Domain.Ehr.EhrPackage;

namespace Vela.RM.Domain.Repositories
{
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1040:AvoidEmptyInterfaces")]
	public interface IEhrRootRepository : IRavenRepository<EhrRoot>
	{
	}
}
