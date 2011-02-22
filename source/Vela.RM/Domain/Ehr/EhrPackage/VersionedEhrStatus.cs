using System;
using Vela.RM.Core.Support;
using Vela.RM.Patterns.Common.ChangeControlPackage;

namespace Vela.RM.Domain.Ehr.EhrPackage
{
	/// <summary>
	/// Version container for <see cref="EhrStatus"/> instance.
	/// </summary>
	[Serializable]
	[OpenEhrName("VERSIONED_EHR_STATUS")]
	public class VersionedEhrStatus : VersionedObject<EhrStatus>
	{
		
	}
}
