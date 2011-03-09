//-----------------------------------------------------------------------
// <copyright file="IsoOId.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System;

namespace Vela.RM.Core.Support.IdentificationPackage
{
	/// <summary>
	/// Model of ISO’s Object Identifier (oid) as defined by the standard ISO/IEC 8824. Oids are formed from integers separated by dots. Each non-leaf node in an Oid starting from the left corresponds to an  assigning authority,  and identifies that authority’s namespace, inside which the remaining part of the identifier is locally unique.
	/// </summary>
	[Serializable, OpenEhrName("ISO_OID")]
	public class IsoOId : Uid
	{
		public IsoOId(string value)
			: base(value)
		{
		}

		[OpenEhrName("value")]
		public override string Value
		{
			get;
			set;
		}
	}
}