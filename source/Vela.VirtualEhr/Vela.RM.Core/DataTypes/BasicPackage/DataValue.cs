//-----------------------------------------------------------------------
// <copyright file="DataValue.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System;
using Vela.RM.Core.Support;

namespace Vela.RM.Core.DataTypes.BasicPackage
{
	/// <summary>
	/// Serves as a common ancestor of all data value types in openEHR models.
	/// </summary>
	[Serializable, OpenEhrName("DATA_VALUE")]
	public abstract class DataValue
	{
	}
}