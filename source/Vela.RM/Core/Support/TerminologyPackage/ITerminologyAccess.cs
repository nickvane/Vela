using System.Collections.Generic;
using Vela.RM.Core.DataTypes.TextPackage;

namespace Vela.RM.Core.Support.TerminologyPackage
{
	/// <summary>
	/// Defines an object providing proxy access to a terminology.
	/// </summary>
	[OpenEhrName("TERMINOLOGY_ACCESS")]
	public interface ITerminologyAccess
	{
		/// <summary>
		/// Identification of this Terminology
		/// </summary>
		[OpenEhrName("id")]
		string Id
		{
			get;
		}

		/// <summary>
		/// Return all codes known in this terminology
		/// </summary>
		[OpenEhrName("all_codes")]
		HashSet<CodePhrase> GetAllCodes();

		/// <summary>
		/// Return all codes under grouper ‘group_id’ from this terminology
		/// </summary>
		/// <param name="groupId"></param>
		/// <returns></returns>
		[OpenEhrName("all_codes")]
		HashSet<CodePhrase> GetCodesForGroupId(string groupId);

		/// <summary>
		/// True if ‘a_code’ is known in group ‘group_id’ in the openEHR terminology.
		/// </summary>
		/// <param name="groupId"></param>
		/// <param name="code"></param>
		/// <returns></returns>
		[OpenEhrName("all_codes")]
		bool HasCodeForGroupId(string groupId, CodePhrase code);

		/// <summary>
		/// Return all codes under grouper whose name in ‘lang’ is ‘name’ from this terminology
		/// </summary>
		/// <param name="groupName"></param>
		/// <param name="language"></param>
		/// <returns></returns>
		[OpenEhrName("all_codes")]
		HashSet<CodePhrase> GetCodesForGroupName(string groupName, string language);

		/// <summary>
		/// Return all rubric of code ‘code’ in language ‘lang’.
		/// </summary>
		/// <param name="code"></param>
		/// <param name="language"></param>
		/// <returns></returns>
		[OpenEhrName("all_codes")]
		string GetRubricForCode(string code, string language);
	}
}
