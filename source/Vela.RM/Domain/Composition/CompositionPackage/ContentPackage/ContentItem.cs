using System;
using Vela.RM.Core.Support;
using Vela.RM.Patterns.Common.ArchetypedPackage;

namespace Vela.RM.Domain.Composition.CompositionPackage.ContentPackage
{
	/// <summary>
	/// Abstract ancestor of all concrete content types.
	/// </summary>
	[Serializable]
	[OpenEhrName("CONTENT_ITEM")]
	public abstract class ContentItem : Locatable
	{
	}
}
