using Vela.RM.Core.Support;
using Vela.RM.Patterns.Common.ChangeControlPackage;

namespace Vela.RM.Patterns.Common.DirectoryPackage
{
	/// <summary>
	/// A version-controlled hierarchy of FOLDERs giving the effect of a directory.
	/// </summary>
	[OpenEhrName("VERSIONED_FOLDER")]
	public class VersionedFolder : VersionedObject<Folder>
	{
	}
}
