//-----------------------------------------------------------------------
// <copyright file="OpenEhrCodeSetIdentifiers.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System.Collections.Generic;

namespace Vela.RM.Core.Support.TerminologyPackage
{
	/// <summary>
	/// List of identifiers for code sets in the openEHR terminology.
	/// </summary>
	[OpenEhrName("OPENEHR_CODE_SET_IDENTIFIERS")]
	public static class OpenEhrCodeSetIdentifiers
	{
		private static readonly Dictionary<string, string> CodeSetIdList = new Dictionary<string, string>() { { "Code_set_id_character_sets", "character sets" }, 
				{ "Code_set_id_compression_algorithms", "compression algorithms" } , 
				{ "Code_set_id_countries", "countries" } , 
				{ "Code_set_id_integrity_check_algorithms", "integrity check algorithms" } , 
				{ "Code_set_id_languages", "languages" } , 
				{ "Code_set_id_media_types", "media types" } , 
				{ "Code_set_id_normal_statuses", "normal statuses" }
				};

		[OpenEhrName("Code_set_id_character_sets")]
		public readonly static string CharacterSets = CodeSetIdList["Code_set_id_character_sets"];
		[OpenEhrName("Code_set_id_compression_algorithms")]
		public readonly static string CompressionAlgorithms = CodeSetIdList["Code_set_id_compression_algorithms"];
		[OpenEhrName("Code_set_id_countries")]
		public readonly static string Countries = CodeSetIdList["Code_set_id_countries"];
		[OpenEhrName("Code_set_id_integrity_check_algorithms")]
		public readonly static string IntegrityCheckAlgorithms = CodeSetIdList["Code_set_id_integrity_check_algorithms"];
		[OpenEhrName("Code_set_id_languages")]
		public readonly static string Languages = CodeSetIdList["Code_set_id_languages"];
		[OpenEhrName("Code_set_id_media_types")]
		public readonly static string MediaTypes = CodeSetIdList["Code_set_id_media_types"];
		[OpenEhrName("Code_set_id_normal_statuses")]
		public readonly static string NormalStatuses = CodeSetIdList["Code_set_id_normal_statuses"];

		/// <summary>
		/// Validity function to test if an identifier is in the set defined by this class.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[OpenEhrName("valid_code_set_id")]
		public static bool IsValidCodeSetId(string id)
		{
			return CodeSetIdList.ContainsValue(id);
		}
	}
}