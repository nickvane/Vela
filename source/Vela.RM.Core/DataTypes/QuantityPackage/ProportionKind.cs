//-----------------------------------------------------------------------
// <copyright file="ProportionKind.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System;

namespace Vela.RM.Core.DataTypes.QuantityPackage
{
	///<summary>
	///</summary>
	[Serializable]
	public enum ProportionKind
	{
		Ratio = 0,
		Unitary = 1,
		Percent = 2,
		Fraction = 3,
		IntegerFraction = 4
	}
}