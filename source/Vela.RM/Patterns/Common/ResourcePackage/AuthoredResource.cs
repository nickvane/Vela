using System.Collections.Generic;
using System.Linq;
using Vela.RM.Core.DataTypes.QuantityPackage;
using Vela.RM.Core.DataTypes.TextPackage;
using Vela.RM.Core.Support;
using Vela.RM.Patterns.Common.GenericPackage;

namespace Vela.RM.Patterns.Common.ResourcePackage
{
	/// <summary>
	/// Abstract idea of an online resource created by a human author.
	/// </summary>
	[OpenEhrName("AUTHORED_RESOURCE")]
	public abstract class AuthoredResource
	{
		private IDictionary<string, TranslationDetails> _translations;

		///<summary>
		/// Language in which this resource was initially authored. Although there is no language primacy of resources overall, the language of original authoring is required to ensure natural language translations can preserve quality. 
		/// Language is relevant in both the description and ontology sections.
		///</summary>
		[OpenEhrName("original_language")]
		public CodePhrase OriginalLanguage { get; set; }

		///<summary>
		/// List of details for each natural translation made of this resource, keyed by language. For each translation listed here, there must be corresponding sections in all language-dependent parts of the resource. The original_language does not appear in this list.
		///</summary>
		[OpenEhrName("translations")]
		public IDictionary<string, TranslationDetails> Translations
		{
			get { return _translations ?? (_translations = new Dictionary<string, TranslationDetails>()); }
			set { _translations = value; }
		}

		///<summary>
		/// Description and lifecycle information of the resource.
		///</summary>
		[OpenEhrName("description")]
		public ResourceDescription Description { get; set; }

		///<summary>
		/// The revision history of the resource. Only required if is_controlled = True (avoids large revision histories for informal or private editing situations).
		///</summary>
		[OpenEhrName("revision_history")]
		public RevisionHistory RevisionHistory { get; set; }

		///<summary>
		/// True if this resource is under any kind of change control (even file copying), in which case revision history is created
		///</summary>
		[OpenEhrName("is_controlled")]
		public bool IsControlled { get; set; }

		/// <summary>
		/// Most recent revision in revision_history if is_controlled else “(uncontrolled)”.
		/// </summary>
		/// <returns></returns>
		[OpenEhrName("current_revision")]
		public string GetCurrentRevision()
		{
			if (!IsControlled | RevisionHistory == null) return string.Empty;
			return RevisionHistory.GetMostRecentVersion();
		}

		/// <summary>
		/// Total list of languages available in this resource, derived from original_language and translations.
		/// </summary>
		/// <returns></returns>
		[OpenEhrName("languages_available")]
		public HashSet<string> GetAvailableLanguages()
		{
			var languages = new HashSet<string>();
			if (OriginalLanguage != null) languages.Add(OriginalLanguage.CodeString);
			languages.UnionWith(from t in Translations select t.Key);
			return languages;
		}
	}
}