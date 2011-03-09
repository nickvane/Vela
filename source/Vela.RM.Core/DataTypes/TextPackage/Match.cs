//-----------------------------------------------------------------------
// <copyright file="Match.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System;

namespace Vela.RM.Core.DataTypes.TextPackage
{
	/// <summary>
	/// The relative match of the target term with respect to the mapped text item. Result meanings:
	/// • ‘>’: the mapping is to a broader term e.g. orginal text = “arbovirus infection”, target = “viral infection”
	/// • ‘=’: the mapping is to a (supposedly) equivalent to the original item.
	/// • ‘&lt;’: the mapping is to a narrower term. e.g. original text = “diabetes”, mapping = “diabetes mellitus”.
	/// • ‘?’: the kind of mapping is unknown. The first three values are taken from the ISO standards 2788 (“Guide to Establishment and development of monolingual thesauri”) and 5964 (“Guide to Establishment and development of multilingual thesauri”).
	/// </summary>
	[Serializable]
	public enum Match
	{
		/// <summary>
		/// The mapping is to a broader term e.g. orginal text = “arbovirus infection”, target = “viral infection”
		/// </summary>
		IsBroader,
		/// <summary>
		/// The mapping is to a (supposedly) equivalent to the original item.
		/// </summary>
		IsEqual,
		/// <summary>
		/// The mapping is to a narrower term. e.g. original text = “diabetes”, mapping = “diabetes mellitus”.
		/// </summary>
		IsNarrower,
		/// <summary>
		/// The kind of mapping is unknown.
		/// </summary>
		Unknown
	}
}