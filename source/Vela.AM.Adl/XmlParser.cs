using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using schemas.openehr.org.v1;
using Vela.AM.Archetypes;
using Vela.AM.Assertions;
using Vela.AM.ConstraintModel;
using Vela.AM.Ontologies;
using Vela.RM.Core.Common.ResourcePackage;
using Vela.RM.Core.DataTypes.QuantityPackage;
using Vela.RM.Core.DataTypes.TextPackage;
using Vela.RM.Core.Support.IdentificationPackage;
using Uri = Vela.RM.Core.DataTypes.UriPackage.Uri;

namespace Vela.AM.Adl
{
	public static class XmlParser
	{
		public static Archetype Parse(string archetypeXmlString)
		{
			var archetypeInstance = new Archetype();
			using (var textReader = new StringReader(archetypeXmlString))
			{
				archetype archetypeModel = archetype.Load(textReader);

				if (archetypeModel.Content != null)
				{
					if (archetypeModel.Content.uid != null)
						archetypeInstance.Uid = new HierObjectId(archetypeModel.Content.uid.value);

					archetypeInstance.AdlVersion = archetypeModel.Content.adl_version;
					archetypeInstance.ArchetypeId = new ArchetypeId(archetypeModel.Content.archetype_id.value);
					if (archetypeModel.Content.parent_archetype_id != null)
						archetypeInstance.ParentArchetypeId = new ArchetypeId(archetypeModel.Content.parent_archetype_id.value);

					archetypeInstance.Concept = archetypeModel.Content.concept;
					if (archetypeModel.Content.original_language != null)
					{
						archetypeInstance.OriginalLanguage = archetypeModel.Content.original_language.Parse();
					}
					if (archetypeModel.Content.translations != null)
					{
						foreach (TRANSLATION_DETAILS translation in archetypeModel.Content.translations)
						{
							archetypeInstance.Translations.Add(translation.language.code_string, translation.Parse());
						}
					}
					if (archetypeModel.Content.is_controlled.HasValue)
						archetypeInstance.IsControlled = archetypeModel.Content.is_controlled.Value;

					archetypeInstance.Description = archetypeModel.Content.description.Parse();

					archetypeInstance.Definition = archetypeModel.Content.definition.Parse();

					if (archetypeModel.Content.invariants != null)
					{
						foreach (ASSERTION assertion in archetypeModel.Content.invariants)
						{
							archetypeInstance.Invariants.Add(assertion.Parse());
						}
					}

					archetypeInstance.Ontology = archetypeModel.Content.ontology.Parse();
				}
				else
				{
					throw new ParseException("Unable to parse content from archetype");
				}
			}

			return archetypeInstance;
		}

		#region Parse Archetype

		private static TranslationDetails Parse(this TRANSLATION_DETAILS translationDetailsModel)
		{
			var detail = new TranslationDetails
			             	{
			             		Language = translationDetailsModel.language.Parse(),
			             		Accreditation = translationDetailsModel.accreditation
			             	};
			foreach (StringDictionaryItem item in translationDetailsModel.author)
			{
				detail.Author.Add(item.id, item.TypedValue);
			}
			foreach (StringDictionaryItem item in translationDetailsModel.other_details)
			{
				detail.OtherDetails.Add(item.id, item.TypedValue);
			}

			return detail;
		}

		private static ResourceDescription Parse(this RESOURCE_DESCRIPTION resourceDescriptionModel)
		{
			var resourceDescription = new ResourceDescription
			                          	{
			                          		LifecycleState = resourceDescriptionModel.lifecycle_state,
			                          		ResourcePackageUri = resourceDescriptionModel.resource_package_uri
			                          	};
			if (resourceDescriptionModel.original_author != null)
			{
				foreach (StringDictionaryItem item in resourceDescriptionModel.original_author)
				{
					resourceDescription.OriginalAuthor.Add(item.id, item.TypedValue);
				}
			}
			if (resourceDescriptionModel.other_contributors != null)
			{
				foreach (string item in resourceDescriptionModel.other_contributors)
				{
					resourceDescription.OtherContributors.Add(item);
				}
			}
			if (resourceDescriptionModel.other_details != null)
			{
				foreach (StringDictionaryItem item in resourceDescriptionModel.other_details)
				{
					resourceDescription.OtherDetails.Add(item.id, item.TypedValue);
				}
			}
			if (resourceDescriptionModel.details != null)
			{
				foreach (RESOURCE_DESCRIPTION_ITEM item in resourceDescriptionModel.details)
				{
					var resourceDescriptionItem = new ResourceDescriptionItem
					                              	{
					                              		Copyright = item.copyright,
					                              		Misuse = item.misuse,
					                              		Purpose = item.purpose,
					                              		Use = item.use,
					                              		Language = item.language.Parse()
					                              	};
					if (item.keywords != null)
					{
						foreach (string keyword in item.keywords)
						{
							resourceDescriptionItem.Keywords.Add(keyword);
						}
					}
					if (item.other_details != null)
					{
						foreach (StringDictionaryItem item2 in item.other_details)
						{
							resourceDescriptionItem.OtherDetails.Add(item2.id, item2.TypedValue);
						}
					}
					resourceDescription.Details.Add(item.language.code_string, resourceDescriptionItem);
				}
			}

			return resourceDescription;
		}

		private static Assertion Parse(this ASSERTION archetypeModelAssertion)
		{
			throw new NotImplementedException("ASSERTION.Parse");
		}

		private static ArchetypeOntology Parse(this ARCHETYPE_ONTOLOGY ontologyModel)
		{
			var ontology = new ArchetypeOntology();

			//TermDefinitions
			if (ontologyModel.term_definitions != null && ontologyModel.term_definitions.Count > 0)
			{
				foreach (CodeDefinitionSet definition in ontologyModel.term_definitions)
				{
					var itemlist = new List<ArchetypeTerminology>();
					foreach (ARCHETYPE_TERM item in definition.items)
					{
						var archetypeTerminology = new ArchetypeTerminology {Code = item.code};
						foreach (StringDictionaryItem item2 in item.items)
						{
							archetypeTerminology.Items.Add(item2.id, item2.TypedValue);
						}
						itemlist.Add(archetypeTerminology);
					}
					ontology.TerminologyDefinitions.Add(definition.language, itemlist);
				}
			}

			//TermBindings
			if (ontologyModel.term_bindings != null && ontologyModel.term_bindings.Count > 0)
			{
				foreach (TermBindingSet bindingSet in ontologyModel.term_bindings)
				{
					Dictionary<string, CodePhrase> items = bindingSet.items.ToDictionary(item => item.code,
					                                                                     item => item.value.Parse());
					ontology.TerminologyBindings.Add(bindingSet.terminology, items);
				}
			}

			//ConstraintDefinitions
			if (ontologyModel.constraint_definitions != null && ontologyModel.constraint_definitions.Count > 0)
			{
				foreach (CodeDefinitionSet definition in ontologyModel.constraint_definitions)
				{
					var itemlist = new List<ArchetypeTerminology>();
					foreach (ARCHETYPE_TERM item in definition.items)
					{
						var archetypeTerminology = new ArchetypeTerminology {Code = item.code};
						foreach (StringDictionaryItem item2 in item.items)
						{
							archetypeTerminology.Items.Add(item2.id, item2.TypedValue);
						}
						itemlist.Add(archetypeTerminology);
					}
					ontology.ConstraintDefinitions.Add(definition.language, itemlist);
				}
			}

			//ConstraintBindings
			if (ontologyModel.constraint_bindings != null && ontologyModel.constraint_bindings.Count > 0)
			{
				throw new NotImplementedException();
			}

			return ontology;
		}

		#endregion

		#region Parse Definition

		private static CComplexObject Parse(this C_COMPLEX_OBJECT complexObjectModel)
		{
			var complexObject = new CComplexObject();

			foreach (C_ATTRIBUTE attribute in complexObjectModel.attributes)
			{
				complexObject.Attributes.Add(attribute.Parse());
			}
			complexObject.NodeId = complexObjectModel.node_id;
			complexObject.ReferenceModelTypeName = complexObjectModel.rm_type_name;
			complexObject.Occurences = complexObjectModel.occurrences.Parse();

			return complexObject;
		}

		private static Interval<int> Parse(this IntervalOfInteger intervalModel)
		{
			var interval = new Interval<int>();

			if (intervalModel.lower_included.HasValue)
				interval.IsLowerIncluded = intervalModel.lower_included.Value;
			if (intervalModel.upper_included.HasValue)
				interval.IsUpperIncluded = intervalModel.upper_included.Value;
			if (intervalModel.lower.HasValue)
				interval.Lower = intervalModel.lower.Value;
			if (intervalModel.upper.HasValue)
				interval.Upper = intervalModel.upper.Value;

			return interval;
		}

		private static CAttribute Parse(this C_ATTRIBUTE attributeModel)
		{
			CAttribute attribute;
			if (attributeModel.GetType() == typeof (C_SINGLE_ATTRIBUTE))
			{
				attribute = new CSingleAttribute();
			}
			else if (attributeModel.GetType() == typeof (C_MULTIPLE_ATTRIBUTE))
			{
				attribute = new CMultipleAttribute();
				((CMultipleAttribute) attribute).Cardinality = ((C_MULTIPLE_ATTRIBUTE) attributeModel).cardinality.Parse();
			}
			else
			{
				throw new ParseException(string.Format("'{0}' is not a valid attribute type.", attributeModel.GetType()));
			}

			attribute.Existence = attributeModel.existence.Parse();
			attribute.ReferenceModelAttributeName = attributeModel.rm_attribute_name;
			if (attributeModel.children != null)
			{
				foreach (C_OBJECT child in attributeModel.children)
				{
					attribute.Children.Add(child.Parse());
				}
			}
			return attribute;
		}

		private static Cardinality Parse(this CARDINALITY cardinalityModel)
		{
			//TODO
			return null;
		}

		private static CObject Parse(this C_OBJECT objectModel)
		{
			CObject constraintObject;

			if (objectModel.GetType() == typeof (C_COMPLEX_OBJECT))
			{
				constraintObject = ((C_COMPLEX_OBJECT) objectModel).Parse();
			}
			else if (objectModel.GetType() == typeof (C_PRIMITIVE_OBJECT))
			{
				constraintObject = ((C_PRIMITIVE_OBJECT) objectModel).Parse();
			}
			else if (objectModel.GetType() == typeof (ARCHETYPE_SLOT))
			{
				constraintObject = ((ARCHETYPE_SLOT) objectModel).Parse();
			}
			else if (objectModel.GetType() == typeof (ARCHETYPE_INTERNAL_REF))
			{
				constraintObject = ((ARCHETYPE_INTERNAL_REF) objectModel).Parse();
			}
			else if (objectModel.GetType() == typeof (CONSTRAINT_REF))
			{
				constraintObject = ((CONSTRAINT_REF) objectModel).Parse();
			}
			else if (objectModel.GetType() == typeof (C_CODE_PHRASE))
			{
				constraintObject = ((C_CODE_PHRASE) objectModel).Parse();
			}
			else if (objectModel.GetType() == typeof (C_DV_QUANTITY))
			{
				constraintObject = ((C_DV_QUANTITY) objectModel).Parse();
			}
			else if (objectModel.GetType() == typeof (C_DV_ORDINAL))
			{
				constraintObject = ((C_DV_ORDINAL) objectModel).Parse();
			}
			else
			{
				throw new ParseException(string.Format("'{0}' is not a valid object type.", objectModel.GetType()));
			}

			return constraintObject;
		}

		private static CPrimitiveObject Parse(this C_PRIMITIVE_OBJECT primitiveObjectModel)
		{
			//TODO
			return null;
		}

		private static CCodePhrase Parse(this C_CODE_PHRASE codePhraseModel)
		{
			var codePhrase = new CCodePhrase
			                 	{
			                 		CodeString = codePhraseModel.code_string,
			                 		TerminologyId = new TerminologyId(codePhraseModel.terminology_id.value)
			                 	};
			if (codePhraseModel.code_list != null)
			{
				foreach (string item in codePhraseModel.code_list)
				{
					codePhrase.CodeList.Add(item);
				}
			}

			return codePhrase;
		}

		private static ArchetypeSlot Parse(this ARCHETYPE_SLOT archetypeSlotModel)
		{
			//TODO
			return null;
		}

		private static ArchetypeInternalRef Parse(this ARCHETYPE_INTERNAL_REF archetypeInternalRefModel)
		{
			//TODO
			return null;
		}

		private static ConstraintRef Parse(this CONSTRAINT_REF constraintRefModel)
		{
			//TODO
			return null;
		}

		private static CQuantity Parse(this C_DV_QUANTITY quantityModel)
		{
			var quantity = new CQuantity
			               	{
			               		ReferenceModelTypeName = quantityModel.rm_type_name,
			               		NodeId = quantityModel.node_id
			               	};
			if (quantityModel.property != null)
				quantity.CodePhrase = quantityModel.property.Parse();
			if (quantityModel.occurrences != null)
				quantity.Occurences = quantityModel.occurrences.Parse();
			return quantity;
		}

		private static COrdinal Parse(this C_DV_ORDINAL ordinalModel)
		{
			var ordinal = new COrdinal
			              	{
			              		ReferenceModelTypeName = ordinalModel.rm_type_name,
			              		NodeId = ordinalModel.node_id,
			              		Occurences = ordinalModel.occurrences.Parse()
			              	};

			foreach (DV_ORDINAL dvOrdinal in ordinalModel.list)
			{
				ordinal.Ordinals.Add(dvOrdinal.Parse());
			}

			return ordinal;
		}

		private static Interval<Ordinal> Parse(this DV_INTERVAL intervalModel)
		{
			var interval = new Interval<Ordinal>();
			if (intervalModel.lower != null)
				interval.Lower = ((DV_ORDINAL) intervalModel.lower).Parse();
			if (intervalModel.lower_included.HasValue)
				interval.IsLowerIncluded = intervalModel.lower_included.Value;
			if (intervalModel.upper != null)
				interval.Upper = ((DV_ORDINAL) intervalModel.upper).Parse();
			if (intervalModel.upper_included.HasValue)
				interval.IsUpperIncluded = intervalModel.upper_included.Value;

			return interval;
		}

		private static ReferenceRange<Ordinal> Parse(this REFERENCE_RANGE range)
		{
			var referenceRange = new ReferenceRange<Ordinal>
			                     	{
			                     		Meaning = new Text(range.meaning.value)
			                     		          	{
			                     		          		Formatting = range.meaning.formatting,
			                     		          		Encoding = range.meaning.encoding.Parse(),
			                     		          		Language = range.meaning.language.Parse(),
			                     		          		Hyperlink = new Uri(range.meaning.hyperlink.value.ToString())
			                     		          	}
			                     	};

			foreach (var mapping in range.meaning.mappings)
			{
				referenceRange.Meaning.Mappings.Add(mapping.Parse());
			}
			referenceRange.Range = range.range.Parse();

			return referenceRange;
		}

		private static Ordinal Parse(this DV_ORDINAL ordinalModel)
		{
			var ordinal = new Ordinal(ordinalModel.value);
			if (ordinalModel.normal_status != null)
			{
				ordinal.NormalStatus = ordinalModel.normal_status.Parse();
			}
			if (ordinalModel.normal_range != null)
			{
				ordinal.NormalRange = ordinalModel.normal_range.Parse();
			}
			if (ordinalModel.symbol != null)
			{
				ordinal.Symbol = ordinalModel.symbol.Parse(); 
			}

			if (ordinalModel.other_reference_ranges != null)
			{
				foreach (REFERENCE_RANGE range in ordinalModel.other_reference_ranges)
				{
					ordinal.OtherReferenceRanges.Add(range.Parse());
				}
			}
			return ordinal;
		}

		private static CodedText Parse(this DV_CODED_TEXT codedTextModel)
		{
			var codedText = new CodedText(codedTextModel.value)
			                	{
			                		DefiningCode = codedTextModel.defining_code.Parse(),
									Formatting = codedTextModel.formatting
								};
			if (codedTextModel.language != null)
				codedText.Language = codedTextModel.language.Parse();
			if (codedTextModel.encoding != null)
				codedText.Encoding = codedTextModel.encoding.Parse();
			if (codedTextModel.hyperlink != null)
				codedText.Hyperlink = new Uri(codedTextModel.hyperlink.value.ToString());
			foreach (var mapping in codedTextModel.mappings)
			{
				codedText.Mappings.Add(mapping.Parse());
			}
			return codedText;
		}

		private static CodePhrase Parse(this CODE_PHRASE codePhraseModel)
		{
			if (codePhraseModel == null) return null;
			var codePhrase = new CodePhrase(codePhraseModel.code_string)
			{
				TerminologyId = new TerminologyId(codePhraseModel.terminology_id.value)
			};
			return codePhrase;
		}

		private static TerminologyMapping Parse(this TERM_MAPPING termMappingModel)
		{
			var termMapping = new TerminologyMapping
			{
				Purpose = termMappingModel.purpose.Parse(),
				Target = termMappingModel.target.Parse()
			};
			var match = Match.Unknown;
			Enum.TryParse(termMappingModel.match, true, out match);
			termMapping.Match = match;
			return termMapping;
		}

		#endregion
	}
}