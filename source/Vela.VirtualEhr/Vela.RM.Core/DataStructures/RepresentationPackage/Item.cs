//-----------------------------------------------------------------------
// <copyright file="Item.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System;
using Vela.RM.Core.Common.ArchetypedPackage;
using Vela.RM.Core.Support;

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