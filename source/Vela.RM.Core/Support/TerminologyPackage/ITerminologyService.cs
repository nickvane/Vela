using System.Collections.Generic;

namespace Vela.RM.Core.Support.TerminologyPackage
{
	/// <summary>
	/// Defines an object providing proxy access to a terminology service.
	/// </summary>
	[OpenEhrName("TERMINOLOGY_SERVICE")]
	public interface ITerminologyService
	{
		/// <summary>
		/// Return an interface to the terminology named name. Allowable names include
		/// • “openehr”
		/// • “centc251”
		/// • any name from are taken from the US NLM UMLS meta-data list at http://www.nlm.nih.gov/research/umls/metaa1.html
		/// </summary>
		[OpenEhrName("terminology")]
		ITerminologyAccess GetTerminology(string name);

		/// <summary>
		/// Return an interface to the code_set identified by the external identifier name (e.g. “ISO_639-1”).
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		[OpenEhrName("code_set")]
		ICodeSetAccess GetCodeSet(string name);

		/// <summary>
		/// Return an interface to the code_set identified internally in openEHR by id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[OpenEhrName("code_set_for_id")]
		ICodeSetAccess GetCodeSetForId(string id);

		/// <summary>
		/// True if terminology named name known by this service. Allowable names include
		/// • “openehr”
		/// • “centc251”
		/// • any name from are taken from the US NLM UMLS meta-data list at http://www.nlm.nih.gov/research/umls/metaa1.html
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		[OpenEhrName("has_terminology")]
		bool HasTerminology(string name);

		/// <summary>
		/// True if code_set linked to internal name (e.g. “languages”) is available.
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		[OpenEhrName("has_code_set")]
		bool HasCodeSet(string name);

		/// <summary>
		/// Set of all terminology identifiers known in the terminology service. Values from the US NLM UMLS meta-data list at http://www.nlm.nih.gov/research/umls/metaa1.html
		/// </summary>
		/// <returns></returns>
		[OpenEhrName("terminology_identifiers")]
		IList<string> GetTerminologyIdentifiers();

		/// <summary>
		/// Set of all code set identifiers known in the terminology service.
		/// </summary>
		/// <returns></returns>
		[OpenEhrName("code_set_identifiers")]
		IList<string> GetCodeSetIdentifiers();

		/// <summary>
		/// Set of all code sets identifiers for which there is an internal openEHR name; returned as a Hash of ids keyed by internal name.
		/// </summary>
		/// <returns></returns>
		[OpenEhrName("openehr_code_sets")]
		IDictionary<string, string> GetOpenEhrCodeSets();
	}
}
