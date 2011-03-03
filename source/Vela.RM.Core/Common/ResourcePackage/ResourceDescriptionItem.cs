using System;
using System.Collections.Generic;
using Vela.RM.Core.DataTypes.TextPackage;
using Vela.RM.Core.Support;

namespace Vela.RM.Core.Common.ResourcePackage
{
	/// <summary>
	/// Language-specific detail of resource description. When a resource is translated for use in another language environment, each  RESOURCE_DESCRIPTION_ITEM needs to be copied and translated into the new language.
	/// </summary>
	[Serializable]
	[OpenEhrName("RESOURCE_DESCRIPTION_ITEM")]
	public class ResourceDescriptionItem
	{
		/// <summary>
		/// The localised language in which the items in this description item are written. Coded from openEHR Code Set “languages”.
		/// </summary>
		[OpenEhrName("language")]
		public CodePhrase Language { get; set; }

		/// <summary>
		/// Purpose of the resource.
		/// </summary>
		[OpenEhrName("purpose")]
		public string Purpose { get; set; }

		/// <summary>
		/// Keywords which characterise this resource, used e.g. for indexing and searching.
		/// </summary>
		[OpenEhrName("keywords")]
		public IList<string> Keywords { get; set; }

		/// <summary>
		/// Description of the uses of the resource, i.e. contexts in which it could be used.
		/// </summary>
		[OpenEhrName("use")]
		public string Use { get; set; }

		/// <summary>
		/// Description of any misuses of the resource, i.e. contexts in which it should not be used.
		/// </summary>
		[OpenEhrName("misuse")]
		public string Misuse { get; set; }

		/// <summary>
		/// Optional copyright statement for the resource as a knowledge resource.
		/// </summary>
		[OpenEhrName("copyright")]
		public string Copyright { get; set; }

		/// <summary>
		/// URIs of original clinical document(s) or description of which resource is a formalisation, in the language of this description item; keyed by meaning.
		/// </summary>
		[OpenEhrName("original_resource_uri")]
		public IDictionary<string, string> OriginalResourceUri { get; set; }

		/// <summary>
		/// Additional language-senstive resource metadata, as a list of name/value pairs.
		/// </summary>
		[OpenEhrName("other_details")]
		public IDictionary<string, string> OtherDetails { get; set; }
	}
}