using System.Collections.Generic;
using Vela.AM.Aom.ConstraintModel;
using Vela.AM.Aom.Ontologies;
using Vela.RM.Core.DataTypes.TextPackage;
using Vela.RM.Core.Support;
using Vela.RM.Core.Support.IdentificationPackage;

namespace Vela.AM.Templates
{
	/// <summary>
	/// 
	/// </summary>
	/// <remarks>
	/// This class is not part of the 1.0.2 specifications. It is still a work in progress, see http://www.openehr.org/wiki/display/spec/openEHR+Templates+and+Specialised+Archetypes
	/// </remarks>
	[OpenEhrName("")]
	public class CArchetypeRoot : CComplexObject
	{
		private IDictionary<string, IDictionary<string, CodePhrase>> _terminologyBindings;
		private IDictionary<string, ArchetypeTerminology> _terminologyDefinitions;

		public ArchetypeId ArchetypeId { get; set; }
		public TemplateId TemplateId { get; set; }

		public IDictionary<string, ArchetypeTerminology> TerminologyDefinitions
		{
			get { return _terminologyDefinitions ?? (_terminologyDefinitions = new Dictionary<string, ArchetypeTerminology>()); }
			private set { _terminologyDefinitions = value; }
		}

		/// <summary>
		/// 
		/// </summary>
		public IDictionary<string, IDictionary<string, CodePhrase>> TerminologyBindings
		{
			get { return _terminologyBindings ?? (_terminologyBindings = new Dictionary<string, IDictionary<string, CodePhrase>>()); }
			private set { _terminologyBindings = value; }
		}
	}
}
