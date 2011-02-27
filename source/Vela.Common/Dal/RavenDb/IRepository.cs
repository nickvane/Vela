using System.Collections.Generic;

namespace Vela.Common.Dal.RavenDb
{
	public interface IRepository<T> : ICollection<T> where T : IDocument
	{
	}
}
