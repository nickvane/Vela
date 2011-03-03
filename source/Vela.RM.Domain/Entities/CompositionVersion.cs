using System;
using Vela.RM.Core.Support;
using Vela.RM.Domain.Compositions.CompositionPackage;

namespace Vela.RM.Domain.Entities
{
	/// <summary>
	/// Container object that holds 1 specific version and the information about the VersionedComposition the version belongs to.
	/// </summary>
	public class CompositionVersion : GenericVersion<Composition>
	{
		/// <summary>
		/// Indicates whether this composition set is persistent; derived from first version.
		/// </summary>
		[OpenEhrName("is_persistent")]
		public bool IsPersistent()
		{
			throw new NotImplementedException();
		}
	}
}