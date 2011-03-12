//-----------------------------------------------------------------------
// <copyright file="IEhrRootRepository.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using Vela.Common;
using Vela.RM.Domain.Ehr.EhrPackage;

namespace Vela.RM.Domain.Repositories
{
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1040:AvoidEmptyInterfaces")]
	public interface IEhrRootRepository : IBaseRepository<EhrRoot>
	{
	}
}