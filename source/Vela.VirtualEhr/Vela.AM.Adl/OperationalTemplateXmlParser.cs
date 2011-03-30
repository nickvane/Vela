using System.IO;
using schemas.openehr.org.v1;
using Vela.AM.Templates;
using Vela.RM.Core.Support.IdentificationPackage;

namespace Vela.AM.Adl
{
	public class OperationalTemplateXmlParser : IOperationalTemplateParser
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="operationalTemplate"></param>
		/// <returns></returns>
		public OperationalTemplate Parse(string operationalTemplate)
		{
			return OperationalTemplateXmlParserInternal.Parse(operationalTemplate);
		}
	}

	internal static class OperationalTemplateXmlParserInternal
	{
		public static OperationalTemplate Parse(string operationalTemplateXmlString)
		{
			var ot = new OperationalTemplate();
			using (var textReader = new StringReader(operationalTemplateXmlString))
			{
				var templateModel = template.Load(textReader);

				if (templateModel.Content.uid != null)
					ot.Uid = new HierObjectId(templateModel.Content.uid.value);
				if (templateModel.Content.template_id != null)
					ot.TemplateId = new TemplateId(templateModel.Content.template_id.value);
				ot.Concept = templateModel.Content.concept;
				if (templateModel.Content.is_controlled.HasValue)
					ot.IsControlled = templateModel.Content.is_controlled.Value;
				if (templateModel.Content.language != null)
					ot.Language = templateModel.Content.language.Map();
				if (templateModel.Content.description != null)
					ot.Description = templateModel.Content.description.Map();
				// TODO: parse revisionhistory
				//ot.RevisionHistory = templateModel.Content.revision_history.Map();
				if (templateModel.Content.definition != null)
					ot.Definition = templateModel.Content.definition.Map();
				if (templateModel.Content.constraints != null)
					ot.Constraints = templateModel.Content.constraints.Map();
				if (templateModel.Content.view != null)
					ot.View = templateModel.Content.view.Map();
				if (templateModel.Content.annotations != null)
				{
					foreach (var annotation in templateModel.Content.annotations)
					{
						ot.Annotations.Add(annotation.Map());
					}
				}
				if (templateModel.Content.ontology != null)
					ot.Ontology = templateModel.Content.ontology.Map();
				if (templateModel.Content.component_ontologies != null)
				{
					foreach (var ontology in templateModel.Content.component_ontologies)
					{
						ot.ComponentOntologies.Add(ontology.Map());
					}
				}

			}
			return ot;
		}
	}
}
