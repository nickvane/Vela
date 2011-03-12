//-----------------------------------------------------------------------
// <copyright file="EhrAccess.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System;
using Vela.RM.Core.Common.ArchetypedPackage;
using Vela.RM.Core.Security.AccessControlPackage;
using Vela.RM.Core.Support;

namespace Vela.RM.Domain.Ehr.EhrPackage
{
	/// <summary>
	/// EHR-wide access contol object. All access decisions to data in the EHR must be made in accordance with the policies and rules in this object.
	/// </summary>
	[Serializable]
	[OpenEhrName("EHR_ACCESS")]
	public class EhrAccess : Locatable
	{
		/// <summary>
		/// Access control settings for the EHR. Instance is a subtype of the type <see cref="AccessControlSettings"/>, allowing for the use of different access control schemes.
		/// </summary>
		[OpenEhrName("settings")]
		public AccessControlSettings Settings { get; set; }

		///<summary>
		/// The name of the access control scheme in use; corresponds to the concrete instance of the settings attribute.
		///</summary>
		[OpenEhrName("scheme")]
		public string Scheme
		{
			get
			{
				throw new NotImplementedException();
			}
		}
	}
}