using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using schemas.openehr.org.v1;
using Vela.AM.Archetypes;
using Vela.AM.Assertions;
using Vela.AM.ConstraintModel;
using Vela.AM.Ontologies;
using Vela.AM.Primitives;
using Vela.RM.Core.Common.ResourcePackage;
using Vela.RM.Core.DataTypes.DateTimePackage;
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

		private static TranslationDetails Parse(this TRANSLATION_DETAILS model)
		{
			var detail = new TranslationDetails
			             	{
			             		Language = model.language.Parse(),
			             		Accreditation = model.accreditation
			             	};
			foreach (StringDictionaryItem item in model.author)
			{
				detail.Author.Add(item.id, item.TypedValue);
			}
			foreach (StringDictionaryItem item in model.other_details)
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

		private static Assertion Parse(this ASSERTION model)
		{
			throw new NotImplementedException("ASSERTION.Parse");
		}

		private static ArchetypeOntology Parse(this ARCHETYPE_ONTOLOGY model)
		{
			var ontology = new ArchetypeOntology();

			//TermDefinitions
			if (model.term_definitions != null && model.term_definitions.Count > 0)
			{
				foreach (CodeDefinitionSet definition in model.term_definitions)
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
			if (model.term_bindings != null && model.term_bindings.Count > 0)
			{
				foreach (TermBindingSet bindingSet in model.term_bindings)
				{
					Dictionary<string, CodePhrase> items = bindingSet.items.ToDictionary(item => item.code,
					                                                                     item => item.value.Parse());
					ontology.TerminologyBindings.Add(bindingSet.terminology, items);
				}
			}

			//ConstraintDefinitions
			if (model.constraint_definitions != null && model.constraint_definitions.Count > 0)
			{
				foreach (CodeDefinitionSet definition in model.constraint_definitions)
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
			if (model.constraint_bindings != null && model.constraint_bindings.Count > 0)
			{
				throw new NotImplementedException();
			}

			return ontology;
		}

		#endregion

		#region Parse Definition

		private static CComplexObject Parse(this C_COMPLEX_OBJECT model)
		{
			var complexObject = new CComplexObject();

			foreach (C_ATTRIBUTE attribute in model.attributes)
			{
				complexObject.Attributes.Add(attribute.Parse());
			}
			complexObject.NodeId = model.node_id;
			complexObject.ReferenceModelTypeName = model.rm_type_name;
			complexObject.Occurences = model.occurrences.Parse();
			complexObject.AnyAllowed = model.any_allowed;

			return complexObject;
		}

		private static Interval<int> Parse(this IntervalOfInteger model)
		{
			var interval = new Interval<int>();

			if (model.lower_included.HasValue)
				interval.IsLowerIncluded = model.lower_included.Value;
			if (model.upper_included.HasValue)
				interval.IsUpperIncluded = model.upper_included.Value;
			if (model.lower.HasValue)
				interval.Lower = model.lower.Value;
			if (model.upper.HasValue)
				interval.Upper = model.upper.Value;

			return interval;
		}

		private static CAttribute Parse(this C_ATTRIBUTE model)
		{
			CAttribute attribute;
			if (model.GetType() == typeof (C_SINGLE_ATTRIBUTE))
			{
				attribute = new CSingleAttribute();
			}
			else if (model.GetType() == typeof (C_MULTIPLE_ATTRIBUTE))
			{
				attribute = new CMultipleAttribute();
				((CMultipleAttribute) attribute).Cardinality = ((C_MULTIPLE_ATTRIBUTE) model).cardinality.Parse();
			}
			else
			{
				throw new ParseException(string.Format("'{0}' is not a valid attribute type.", model.GetType()));
			}

			attribute.Existence = model.existence.Parse();
			attribute.ReferenceModelAttributeName = model.rm_attribute_name;
			if (model.children != null)
			{
				foreach (C_OBJECT child in model.children)
				{
					attribute.Children.Add(child.Parse(attribute));
				}
			}
			return attribute;
		}

		private static Cardinality Parse(this CARDINALITY model)
		{
			var cardinality = new Cardinality
			                  	{
			                  		IsOrdered = model.is_ordered,
			                  		IsUnique = model.is_unique,
			                  		Interval = model.interval.Parse()
			                  	};
			return cardinality;
		}

		private static CObject Parse(this C_OBJECT model, CAttribute parent)
		{
			CObject constraintObject;

			if (model.GetType() == typeof (C_COMPLEX_OBJECT))
			{
				constraintObject = ((C_COMPLEX_OBJECT) model).Parse();
			}
			else if (model.GetType() == typeof (C_PRIMITIVE_OBJECT))
			{
				constraintObject = ((C_PRIMITIVE_OBJECT) model).Parse();
			}
			else if (model.GetType() == typeof (ARCHETYPE_SLOT))
			{
				constraintObject = ((ARCHETYPE_SLOT) model).Parse();
			}
			else if (model.GetType() == typeof (ARCHETYPE_INTERNAL_REF))
			{
				constraintObject = ((ARCHETYPE_INTERNAL_REF) model).Parse();
			}
			else if (model.GetType() == typeof (CONSTRAINT_REF))
			{
				constraintObject = ((CONSTRAINT_REF) model).Parse();
			}
			else if (model.GetType() == typeof (C_CODE_PHRASE))
			{
				constraintObject = ((C_CODE_PHRASE) model).Parse();
			}
			else if (model.GetType() == typeof (C_DV_QUANTITY))
			{
				constraintObject = ((C_DV_QUANTITY) model).Parse();
			}
			else if (model.GetType() == typeof (C_DV_ORDINAL))
			{
				constraintObject = ((C_DV_ORDINAL) model).Parse();
			}
			else
			{
				throw new ParseException(string.Format("'{0}' is not a valid object type.", model.GetType()));
			}
			if (constraintObject != null)
				constraintObject.Parent = parent;
			return constraintObject;
		}

		private static CPrimitiveObject Parse(this C_PRIMITIVE_OBJECT model)
		{
			var primitiveObject = new CPrimitiveObject
			                      	{
			                      		AnyAllowed = model.any_allowed,
			                      		NodeId = model.node_id,
			                      		Item = model.item.Parse(),
			                      		ReferenceModelTypeName = model.rm_type_name,
			                      		Occurences = model.occurrences.Parse()
			                      	};
			return primitiveObject;
		}

		private static CCodePhrase Parse(this C_CODE_PHRASE model)
		{
			var codePhrase = new CCodePhrase
			                 	{
			                 		CodeString = model.code_string,
			                 		TerminologyId = new TerminologyId(model.terminology_id.value)
			                 	};
			if (model.code_list != null)
			{
				foreach (string item in model.code_list)
				{
					codePhrase.CodeList.Add(item);
				}
			}

			return codePhrase;
		}

		private static ArchetypeSlot Parse(this ARCHETYPE_SLOT model)
		{
			//TODO
			return null;
		}

		private static ArchetypeInternalRef Parse(this ARCHETYPE_INTERNAL_REF model)
		{
			//TODO
			return null;
		}

		private static ConstraintRef Parse(this CONSTRAINT_REF model)
		{
			var constraintRef = new ConstraintRef
			                    	{
			                    		NodeId = model.node_id,
			                    		Occurences = model.occurrences.Parse(),
			                    		Reference = model.reference,
			                    		ReferenceModelTypeName = model.rm_type_name
			                    	};
			return constraintRef;
		}

		private static CQuantity Parse(this C_DV_QUANTITY model)
		{
			var quantity = new CQuantity
			               	{
			               		ReferenceModelTypeName = model.rm_type_name,
			               		NodeId = model.node_id
			               	};
			if (model.property != null)
				quantity.CodePhrase = model.property.Parse();
			if (model.occurrences != null)
				quantity.Occurences = model.occurrences.Parse();
			return quantity;
		}

		private static COrdinal Parse(this C_DV_ORDINAL model)
		{
			var ordinal = new COrdinal
			              	{
			              		ReferenceModelTypeName = model.rm_type_name,
			              		NodeId = model.node_id,
			              		Occurences = model.occurrences.Parse()
			              	};

			foreach (DV_ORDINAL dvOrdinal in model.list)
			{
				ordinal.Ordinals.Add(dvOrdinal.Parse());
			}

			return ordinal;
		}

		private static Interval<Ordinal> Parse(this DV_INTERVAL model)
		{
			var interval = new Interval<Ordinal>();
			if (model.lower != null)
				interval.Lower = ((DV_ORDINAL) model.lower).Parse();
			if (model.lower_included.HasValue)
				interval.IsLowerIncluded = model.lower_included.Value;
			if (model.upper != null)
				interval.Upper = ((DV_ORDINAL) model.upper).Parse();
			if (model.upper_included.HasValue)
				interval.IsUpperIncluded = model.upper_included.Value;

			return interval;
		}

		private static ReferenceRange<Ordinal> Parse(this REFERENCE_RANGE model)
		{
			var referenceRange = new ReferenceRange<Ordinal>
			                     	{
			                     		Meaning = new Text(model.meaning.value)
			                     		          	{
			                     		          		Formatting = model.meaning.formatting,
			                     		          		Encoding = model.meaning.encoding.Parse(),
			                     		          		Language = model.meaning.language.Parse(),
			                     		          		Hyperlink = new Uri(model.meaning.hyperlink.value.ToString())
			                     		          	}
			                     	};

			foreach (TERM_MAPPING mapping in model.meaning.mappings)
			{
				referenceRange.Meaning.Mappings.Add(mapping.Parse());
			}
			referenceRange.Range = model.range.Parse();

			return referenceRange;
		}

		private static Ordinal Parse(this DV_ORDINAL model)
		{
			var ordinal = new Ordinal(model.value);
			if (model.normal_status != null)
			{
				ordinal.NormalStatus = model.normal_status.Parse();
			}
			if (model.normal_range != null)
			{
				ordinal.NormalRange = model.normal_range.Parse();
			}
			if (model.symbol != null)
			{
				ordinal.Symbol = model.symbol.Parse();
			}

			if (model.other_reference_ranges != null)
			{
				foreach (REFERENCE_RANGE range in model.other_reference_ranges)
				{
					ordinal.OtherReferenceRanges.Add(range.Parse());
				}
			}
			return ordinal;
		}

		private static CodedText Parse(this DV_CODED_TEXT model)
		{
			var codedText = new CodedText(model.value)
			                	{
			                		DefiningCode = model.defining_code.Parse(),
			                		Formatting = model.formatting
			                	};
			if (model.language != null)
				codedText.Language = model.language.Parse();
			if (model.encoding != null)
				codedText.Encoding = model.encoding.Parse();
			if (model.hyperlink != null)
				codedText.Hyperlink = new Uri(model.hyperlink.value.ToString());
			foreach (TERM_MAPPING mapping in model.mappings)
			{
				codedText.Mappings.Add(mapping.Parse());
			}
			return codedText;
		}

		private static CodePhrase Parse(this CODE_PHRASE model)
		{
			if (model == null) return null;
			var codePhrase = new CodePhrase(model.code_string)
			                 	{
			                 		TerminologyId = new TerminologyId(model.terminology_id.value)
			                 	};
			return codePhrase;
		}

		private static TerminologyMapping Parse(this TERM_MAPPING model)
		{
			var termMapping = new TerminologyMapping
			                  	{
			                  		Purpose = model.purpose.Parse(),
			                  		Target = model.target.Parse()
			                  	};
			Match match;
			Enum.TryParse(model.match, true, out match);
			termMapping.Match = match;
			return termMapping;
		}

		private static CPrimitive Parse(this C_PRIMITIVE model)
		{
			CPrimitive primitive;

			if (model.GetType() == typeof (C_BOOLEAN))
			{
				primitive = ((C_BOOLEAN) model).Parse();
			}
			else if (model.GetType() == typeof (C_INTEGER))
			{
				primitive = ((C_INTEGER) model).Parse();
			}
			else if (model.GetType() == typeof (C_STRING))
			{
				primitive = ((C_STRING) model).Parse();
			}
			else if (model.GetType() == typeof (C_DURATION))
			{
				primitive = ((C_DURATION) model).Parse();
			}
			else if (model.GetType() == typeof (C_DATE))
			{
				//primitive = ((C_DATE)model).Parse();
				primitive = null;
			}
			else
			{
				throw new ParseException(string.Format("'{0}' is not a valid primitive type.", model.GetType()));
			}
			return primitive;
		}

		private static CBoolean Parse(this C_BOOLEAN model)
		{
			var primitive = new CBoolean {IsFalseValid = model.false_valid, IsTrueValid = model.true_valid};
			if (model.assumed_value.HasValue)
				primitive.AssumedValue = model.assumed_value.Value;
			return primitive;
		}

		private static CInteger Parse(this C_INTEGER model)
		{
			var primitive = new CInteger {Range = model.range.Parse()};
			if (model.assumed_value.HasValue)
				primitive.AssumedValue = model.assumed_value.Value;
			foreach (int i in model.list)
			{
				primitive.List.Add(i);
			}
			return primitive;
		}

		private static CString Parse(this C_STRING model)
		{
			var primitive = new CString {Pattern = model.pattern, AssumedValue = model.assumed_value};
			if (model.list_open.HasValue)
				primitive.IsListOpen = model.list_open.Value;
			foreach (string s in model.list)
			{
				primitive.List.Add(s);
			}
			return primitive;
		}

		private static CDuration Parse(this C_DURATION model)
		{
			var primitive = new CDuration
			                	{
			                		AssumedValue = new Duration(model.assumed_value),
			                		Pattern = model.pattern
			                	};
			if (model.range != null)
				primitive.Range = model.range.Parse();
			return primitive;
		}

		private static Interval<Duration> Parse(this IntervalOfDuration model)
		{
			var interval = new Interval<Duration> {Lower = new Duration(model.lower), Upper = new Duration(model.upper)};
			if (model.lower_included.HasValue)
				interval.IsLowerIncluded = model.lower_included.Value;
			if (model.upper_included.HasValue)
				interval.IsUpperIncluded = model.upper_included.Value;
			return interval;
		}

		#endregion
	}
}