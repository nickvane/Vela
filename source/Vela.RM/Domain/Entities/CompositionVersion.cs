using Vela.Common.Dal.RavenDb;
using Vela.RM.Domain.Compositions.CompositionPackage;
using Vela.RM.Domain.Ehr.EhrPackage;
using Vela.RM.Patterns.Common.ChangeControlPackage;

namespace Vela.RM.Domain.Entities
{
	/// <summary>
	/// Container object that holds 1 specific version and the information about the VersionedComposition the version belongs to.
	/// </summary>
	public class CompositionVersion : IDocument
	{
		public VersionedComposition VersionedComposition { get; set; }
		public Version<Composition> Version { get; set; }

		#region IDocument Members

		public string Id
		{
			get { return (Version != null && Version.Uid != null) ? Version.Uid.Value : string.Empty; }
			set { if (Version != null && Version.Uid != null) Version.Uid.Value = value; }
		}

		#endregion
	}
}