using System;
using Vela.RM.Core.Support;
using Vela.RM.Patterns.Common.ArchetypedPackage;

namespace Vela.RM.Core.DataStructures.RepresentationPackage
{
	/// <summary>
	/// The abstract parent of <see cref="Element"/> and <see cref="Cluster"/> representation classes.
	/// </summary>
	[Serializable]
	[OpenEhrName("item")]
	public abstract class Item : Locatable
	{
	}
}
