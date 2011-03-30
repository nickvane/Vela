//-----------------------------------------------------------------------
// <copyright file="PartySelf.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System;
using Vela.RM.Core.Support;

namespace Vela.RM.Core.Common.GenericPackage
{
	/// <summary>
	/// Party proxy representing the subject of the record.
	/// Used to indicate that the party is the owner of the record. May or may not have external_ref set.
	/// </summary>
	[Serializable]
	[OpenEhrName("PARTY_SELF")]
	public class PartySelf : PartyProxy
	{
		
	}
}