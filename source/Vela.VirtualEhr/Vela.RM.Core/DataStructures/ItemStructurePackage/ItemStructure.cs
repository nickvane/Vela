//-----------------------------------------------------------------------
// <copyright file="ItemStructure.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System;
using Vela.RM.Core.Support;

namespace Vela.RM.Core.DataStructures.ItemStructurePackage
{
	/// <summary>
	/// Abstract parent class of all spatial data types.
	/// </summary>
	[Serializable]
	[OpenEhrName("ITEM_STRUCTURE")]
	public abstract class ItemStructure : DataStructure
	{
	}
}