//-----------------------------------------------------------------------
// <copyright file="TemplateId.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System;

namespace Vela.RM.Core.Support.IdentificationPackage
{
	///<summary>
	/// Identifier for templates. Lexical form to be determined.
	///</summary>
	[Serializable, OpenEhrName("TEMPLATE_ID")]
	public class TemplateId : ObjectId
	{
		public TemplateId(string value)
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