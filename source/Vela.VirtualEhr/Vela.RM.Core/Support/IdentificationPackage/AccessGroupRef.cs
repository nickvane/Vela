//-----------------------------------------------------------------------
// <copyright file="AccessGroupRef.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System;
using Vela.RM.Core.Properties;

namespace Vela.RM.Core.Support.IdentificationPackage
{
	/// <summary>
	/// Reference to access group in an access control service.
	/// </summary>
	[Serializable, OpenEhrName("ACCESS_GROUP_REF")]
	public class AccessGroupRef : ObjectRef
	{
		public override string Type
		{
			get
			{
				return base.Type;
			}
			set
			{
				if (value.ToUpperInvariant() != RefType.ACCESS_GROUP.ToString()) throw new ArgumentException(string.Format(Resources.InvalidType, value, this.GetType().Name), "value");
				base.Type = value;
			}
		}
	}
}