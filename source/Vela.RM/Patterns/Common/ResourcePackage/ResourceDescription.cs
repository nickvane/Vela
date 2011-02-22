using System.Collections.Generic;
using Vela.RM.Core.Support;

namespace Vela.RM.Patterns.Common.ResourcePackage
{
	///<summary>
	/// Defines the descriptive meta-data of a resource.
	///</summary>
	[OpenEhrName("RESOURCE_DESCRIPTION")]
	public class ResourceDescription
	{
		/// <summary>
		/// Original author of this resource, with all relevant details, including organisation.
		/// </summary>
		[OpenEhrName("original_author")]
		public IDictionary<string, string> OriginalAuthor { get; set; }

		/// <summary>
		/// Other contributors to the resource, probably listed in “name email” form.
		/// </summary>
		[OpenEhrName("other_contributors")]
		public IList<string> OtherContributors { get; set; }

		/// <summary>
		/// Lifecycle state of the resource, typically including states such as: initial, submitted, experimental, awaiting_approval, approved, superseded, obsolete.
		/// </summary>
		[OpenEhrName("lifecycle_state")]
		public string LifecycleState { get; set; }

		/// <summary>
		/// Details of all parts of resource description that are natural language-dependent, keyed by language code.
		/// </summary>
		[OpenEhrName("details")]
		public IDictionary<string, ResourceDescriptionItem> Details { get; set; }

		/// <summary>
		/// URI of package to which this resource belongs.
		/// </summary>
		[OpenEhrName("resource_package_uri")]
		public string ResourcePackageUri { get; set; }

		/// <summary>
		/// Additional non language-senstive resource meta-data, as a list of name/value pairs.
		/// </summary>
		[OpenEhrName("other_details")]
		public IDictionary<string, string> OtherDetails { get; set; }

		/// <summary>
		/// Reference to owning resource.
		/// </summary>
		[OpenEhrName("parent_resource")]
		public AuthoredResource ParentResource { get; set; }
	}
}