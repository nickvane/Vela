//-----------------------------------------------------------------------
// <copyright file="CCodePhrase.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using Vela.AM.Aom.ConstraintModel;
using Vela.RM.Core.DataTypes.TextPackage;
using Vela.RM.Core.Support;
using Vela.RM.Core.Support.IdentificationPackage;

namespace Vela.AM.Ap.DataTypes.Text
{
	/// <summary>
	/// Express constraints on instances of CODE_PHRASE. The terminology_id attribute may be specified on its own to indicate any term from a specified terminology; the code_list attribute may be used to limit the codes to a specific list.
	/// </summary>
	[OpenEhrName("C_CODE_PHRASE")]
	public class CCodePhrase : CDomainType<CodePhrase>
	{
		private IList<string> _codeList;

		/// <summary>
		/// List of allowed codes; may be empty, meaning any code in the terminology may be used.
		/// </summary>
		[OpenEhrName("code_list")]
		public IList<string> CodeList
		{
			get
			{
				return _codeList ?? (_codeList = new List<string>());
			}
		}

		/// <summary>
		/// Syntax string expressing constraint on allowed primary terms
		/// </summary>
		[OpenEhrName("terminology_id")]
		public TerminologyId TerminologyId { get; set; }

		/// <summary>
		/// True if constraints represented by other are narrower than this node. Note: not easily evaluatable for CONSTRAINT_REF nodes.
		/// </summary>
		/// <param name="other"></param>
		/// <returns></returns>
		public override bool IsSubsetOf(ArchetypeConstraint other)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Generate a default value from this constraint object
		/// </summary>
		/// <returns></returns>
		public override CodePhrase DefaultValue()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// True if a_value is valid with respect to constraint expressed in concrete instance of this type.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public override bool IsValidValue(CodePhrase value)
		{
			throw new NotImplementedException();
		}
	}
}