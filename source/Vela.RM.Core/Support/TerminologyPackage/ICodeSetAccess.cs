using System.Collections.Generic;
using Vela.RM.Core.DataTypes.TextPackage;

namespace Vela.RM.Core.Support.TerminologyPackage
{
	/// <summary>
	/// Defines an object providing proxy access to a code_set.
	/// </summary>
	[OpenEhrName("CODE_SET_ACCESS")]
	public interface ICodeSetAccess
	{
		/// <summary>
		/// External identifier of this code set
		/// </summary>
		[OpenEhrName("id")]
		string Id
		{
			get;
		}

		/// <summary>
		/// Return all codes known in this code set
		/// </summary>
		[OpenEhrName("all_codes")]
		HashSet<CodePhrase> GetAllCodes();

		/// <summary>
		/// True if code set knows about ‘a_lang’
		/// </summary>
		/// <param name="language"></param>
		/// <returns></returns>
		[OpenEhrName("has_lang")]
		bool HasLanguage(CodePhrase language);

		/// <summary>
		/// True if code set knows about ‘a_code’
		/// </summary>
		/// <param name="code"></param>
		/// <returns></returns>
		[OpenEhrName("has_code")]
		bool HasCode(CodePhrase code);
	}
}