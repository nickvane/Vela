using System;
using Vela.RM.Core.Support;
using Vela.RM.Core.Support.IdentificationPackage;

namespace Vela.RM.Core.Common.ArchetypedPackage
{
	/// <summary>
	/// Archetypes act as the configuration basis for the particular structures of instances defined by the reference model. To enable archetypes to be used to create valid data, key classes in the reference model act as “root” points for archetyping; accordingly, these classes have the archetype_details attribute set. An instance of the class ARCHETYPED contains the relevant archetype identification information,allowing generating archetypes to be matched up with data instances
	/// </summary>
	[Serializable]
	[OpenEhrName("ARCHETYPED")]
	public class Archetyped
	{
		///<summary>
		/// Globally unique archetype identifier.
		///</summary>
		[OpenEhrName("archetype_id")]
		public ArchetypeId ArchetypeId { get; set; }

		///<summary>
		/// Globally unique template identifier, if a template was active at this point in the structure. Normally, a template would only be used at the top of a top-level structure, but the possibility exists for templates at lower levels.
		///</summary>
		[OpenEhrName("template_id")]
		public TemplateId TemplateId { get; set; }

		///<summary>
		/// Version of the openEHR reference model used to create this object. Expressed in terms of the release version string, e.g. “1.0”, “1.2.4”.
		///</summary>
		[OpenEhrName("rm_version")]
		public string Version { get; set; }
	}
}
