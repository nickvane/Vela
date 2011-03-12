//-----------------------------------------------------------------------
// <copyright file="GenericId.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System;

namespace Vela.RM.Core.Support.IdentificationPackage
{
	/// <summary>
	/// Generic identifier type for identifiers whose format is  othterwise unknown to openEHR. Includes an attribute for naming the identification scheme (which may well be local).
	/// </summary>
	[Serializable, OpenEhrName("GENERIC_ID")]
	public class GenericId : ObjectId
	{
		public GenericId(string value)
			: base(value)
		{
		}

		///<summary>
		/// Name of the scheme to which this identifier conforms. Ideally this name will be recognisable globally but realistically it may be a local ad hoc scheme whose name is not controlled or standardised in any way.
		///</summary>
		[OpenEhrName("scheme")]
		public string Scheme
		{
			get;
			set;
		}
	}
}