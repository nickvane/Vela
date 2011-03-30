using Vela.RM.Core.Common.GenericPackage;
using Vela.RM.Core.Common.ResourcePackage;
using Vela.RM.Core.DataTypes.TextPackage;
using Vela.RM.Core.Support;
using Vela.RM.Core.Support.IdentificationPackage;

namespace Vela.AM.Templates
{
	/// <summary>
	/// Root object of an operational template. An operational template is derived from a template definition and the archetypes mentioned by that template by a process of flattening, and potentially removal of unneeded languages and terminologies.
	/// </summary>
	[OpenEhrName("OPERATIONAL_TEMPLATE")]
	public class OperationalTemplate
	{

		public CodePhrase Language { get; set; }
		public HierObjectId Uid { get; set; }
		public TemplateId TemplateId { get; set; }
		public string Concept { get; set; }
		public CArchetypeRoot Definition { get; set; }
		public bool IsControlled { get; set; }
		public ResourceDescription Description { get; set; }
		public RevisionHistory RevisionHistory { get; set; }

	}
}
