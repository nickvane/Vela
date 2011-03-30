//-----------------------------------------------------------------------
// <copyright file="EhrStatusVersionRepository.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System.Linq;
using Vela.RM.Domain.Ehr.EhrPackage;
using Vela.RM.Domain.Entities;
using Vela.RM.Domain.Repositories;

namespace Vela.RM.Dal.Repositories
{
	public class EhrStatusVersionRepository : GenericVersionRepository<EhrStatusVersion, EhrStatus>, IEhrStatusVersionRepository
	{
		public EhrStatusVersionRepository(IQueryable<EhrStatusVersion> collection = null)
			: base(collection)
		{
		}
	}
}