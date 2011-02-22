using System;
using Vela.RM.Core.Support;
using Vela.RM.Patterns.Common.ChangeControlPackage;

namespace Vela.RM.Domain.Ehr.EhrPackage
{
	/// <summary>
	/// Version container for EHR_ACCESS instance.
	/// </summary>
	[Serializable]
	[OpenEhrName("VERSIONED_EHR_ACCESS")]
	public class VersionedEhrAccess : VersionedObject<EhrAccess>
	{
		
	}
}
