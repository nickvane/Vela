//-----------------------------------------------------------------------
// <copyright file="ContentItem.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System;
using Vela.RM.Core.Common.ArchetypedPackage;
using Vela.RM.Core.Support;

namespace Vela.RM.Domain.Compositions.CompositionPackage.ContentPackage
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