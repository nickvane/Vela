using System.Collections.Generic;
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
	/// <remarks>
	/// This class is not part of the 1.0.2 specifications. It is still a work in progress, see http://www.openehr.org/wiki/display/spec/openEHR+Templates+and+Specialised+Archetypes
	/// </remarks>
	[OpenEhrName("OPERATIONAL_TEMPLATE")]
	public class OperationalTemplate
	{
		private IList<Annotation> _annotations;
		private IList<FlatArchetypeOntology> _componentOntologies;

		public CodePhrase Language { get; set; }
		public HierObjectId Uid { get; set; }
		public TemplateId TemplateId { get; set; }
		public string Concept { get; set; }
		public CArchetypeRoot Definition { get; set; }
		public bool IsControlled { get; set; }
		public ResourceDescription Description { get; set; }
		public RevisionHistory RevisionHistory { get; set; }

		public IList<Annotation> Annotations
		{
			get { return _annotations ?? (_annotations = new List<Annotation>()); }
		}

		public TConstraint Constraints { get; set; }
		public TView View { get; set; }
		public FlatArchetypeOntology Ontology { get; set; }

		public IList<FlatArchetypeOntology> ComponentOntologies
		{
			get { return _componentOntologies ?? (_componentOntologies = new List<FlatArchetypeOntology>()); }
			private set { _componentOntologies = value; }
		}
	}
}