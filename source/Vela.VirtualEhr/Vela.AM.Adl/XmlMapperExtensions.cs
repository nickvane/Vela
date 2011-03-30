using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using schemas.openehr.org.v1;
using Vela.AM.Aom.Assertions;
using Vela.AM.Aom.ConstraintModel;
using Vela.AM.Aom.Ontologies;
using Vela.AM.Aom.Primitives;
using Vela.AM.Ap.DataTypes.Quantity;
using Vela.AM.Ap.DataTypes.Text;
using Vela.AM.Templates;
using Vela.RM.Core.Common.ResourcePackage;
using Vela.RM.Core.DataTypes.BasicPackage;
using Vela.RM.Core.DataTypes.DateTimePackage;
using Vela.RM.Core.DataTypes.QuantityPackage;
using Vela.RM.Core.DataTypes.TextPackage;
using Vela.RM.Core.Support.IdentificationPackage;
using Xml.Schema.Linq;
using Boolean = Vela.RM.Core.DataTypes.BasicPackage.Boolean;
using DateTime = Vela.RM.Core.DataTypes.DateTimePackage.DateTime;
using Uri = Vela.RM.Core.DataTypes.UriPackage.Uri;

namespace Vela.AM.Adl
{
	// TODO: check if automapper can vastly reduce the amount of code
	public static class XmlMapperExtensions
	{
		#region Map Archetype

		public static TranslationDetails Map(this TRANSLATION_DETAILS model)
		{
			var detail = new TranslationDetails
			             	{
			             		Language = model.language.Map(),
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

		public static ResourceDescription Map(this RESOURCE_DESCRIPTION resourceDescriptionModel)
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
					                              		Language = item.language.Map()
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

		public static Assertion Map(this ASSERTION model)
		{
			var assertion = new Assertion
			                	{
			                		ExpressionString = model.string_expression,
			                		Tag = model.tag,
			                		Expression = model.expression.Map()
			                	};
			if (model.variables != null)
			{
				foreach (ASSERTION_VARIABLE variable in model.variables)
				{
					assertion.Variables.Add(new AssertionVariable
					                        	{
					                        		Definition = variable.definition,
					                        		Name = variable.name
					                        	});
				}
			}

			return assertion;
		}

		private static ExprItem Map(this EXPR_ITEM model)
		{
			ExprItem exprItem;
			if (model is EXPR_LEAF)
			{
				exprItem = ((EXPR_LEAF) model).Map();
			}
			else if (model is EXPR_BINARY_OPERATOR)
			{
				exprItem = ((EXPR_BINARY_OPERATOR) model).Map();
			}
			else if (model is EXPR_UNARY_OPERATOR)
			{
				exprItem = ((EXPR_UNARY_OPERATOR) model).Map();
			}
			else
			{
				throw new ParseException(string.Format("'{0}' is not a valid expritem type.", model.GetType()));
			}
			exprItem.Type = model.type;
			return exprItem;
		}

		private static ExprLeaf Map(this EXPR_LEAF model)
		{
			return new ExprLeaf
			       	{
			       		ReferenceType = model.reference_type,
			       		Item = ParseExpressionItem(model.item)
			       	};
		}

		private static ExprBinaryOperator Map(this EXPR_BINARY_OPERATOR model)
		{
			var binary = new ExprBinaryOperator
			             	{
			             		IsPrecedenceOverriden = model.precedence_overridden,
			             		Operator = (OperatorKind) ((int) model.@operator),
			             		LeftOperand = model.left_operand.Map(),
			             		RightOperand = model.right_operand.Map()
			             	};
			return binary;
		}

		private static ExprUnaryOperator Map(this EXPR_UNARY_OPERATOR model)
		{
			var unary = new ExprUnaryOperator
			            	{
			            		IsPrecedenceOverriden = model.precedence_overridden,
			            		Operand = model.operand.Map(),
			            		Operator = (OperatorKind) ((int) model.@operator)
			            	};
			return unary;
		}

		private static object ParseExpressionItem(XTypedElement model)
		{
			object item;
			string typeValue =
				(from a in model.Untyped.Attributes().ToList()
				 where a.Name.LocalName == "type"
				 select a.Value).SingleOrDefault();

			if (typeValue == "xsd:string")
			{
				item = model.Untyped.Value;
			}
			else if (typeValue == "C_STRING")
			{
				XElement element =
					(from e in model.Untyped.Elements()
					 where e.Name.LocalName == "pattern"
					 select e).SingleOrDefault();
				var cstring = new CString
				              	{
				              		Pattern = element.Value
				              	};
				item = cstring;
			}
			else
			{
				throw new ParseException(string.Format("'{0}' is not a valid item type for expression.item.", model.GetType()));
			}
			return item;
		}

		public static ArchetypeOntology Map(this ARCHETYPE_ONTOLOGY model)
		{
			var ontology = new ArchetypeOntology();

			//TermDefinitions
			if (model.term_definitions != null)
			{
				foreach (CodeDefinitionSet definition in model.term_definitions)
				{
					var itemlist = new List<ArchetypeTerminology>();
					foreach (ARCHETYPE_TERM item in definition.items)
					{
						var archetypeTerminology = new ArchetypeTerminology
						                           	{
						                           		Code = item.code
						                           	};
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
			if (model.term_bindings != null)
			{
				foreach (TermBindingSet bindingSet in model.term_bindings)
				{
					Dictionary<string, CodePhrase> items = bindingSet.items.ToDictionary(item => item.code,
					                                                                     item => item.value.Map());
					ontology.TerminologyBindings.Add(bindingSet.terminology, items);
				}
			}

			//ConstraintDefinitions
			if (model.constraint_definitions != null)
			{
				foreach (CodeDefinitionSet definition in model.constraint_definitions)
				{
					var itemlist = new List<ArchetypeTerminology>();
					foreach (ARCHETYPE_TERM item in definition.items)
					{
						var archetypeTerminology = new ArchetypeTerminology
						                           	{
						                           		Code = item.code
						                           	};
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

		#region Map Definition

		public static CComplexObject Map(this C_COMPLEX_OBJECT model)
		{
			var complexObject = new CComplexObject();

			foreach (C_ATTRIBUTE attribute in model.attributes)
			{
				complexObject.Attributes.Add(attribute.Map());
			}
			complexObject.NodeId = model.node_id;
			complexObject.ReferenceModelTypeName = model.rm_type_name;
			complexObject.Occurences = model.occurrences.Map();
			complexObject.AnyAllowed = model.any_allowed;

			return complexObject;
		}

		public static CArchetypeRoot Map(this C_ARCHETYPE_ROOT model)
		{
			var cArchetypeRoot = (CArchetypeRoot) ((C_COMPLEX_OBJECT) model).Map();
			cArchetypeRoot.ArchetypeId = new ArchetypeId(model.archetype_id.value);
			cArchetypeRoot.TemplateId = new TemplateId(model.template_id.value);
			foreach (TermBindingSet bindingSet in model.term_bindings)
			{
				Dictionary<string, CodePhrase> items = bindingSet.items.ToDictionary(item => item.code,
				                                                                     item => item.value.Map());
				cArchetypeRoot.TerminologyBindings.Add(bindingSet.terminology, items);
			}

			if (model.term_definitions != null)
			{
				foreach (ARCHETYPE_TERM item in model.term_definitions)
				{
					var archetypeTerminology = new ArchetypeTerminology
					                           	{
					                           		Code = item.code
					                           	};
					foreach (StringDictionaryItem item2 in item.items)
					{
						archetypeTerminology.Items.Add(item2.id, item2.TypedValue);
					}
					cArchetypeRoot.TerminologyDefinitions.Add(item.code, archetypeTerminology);
				}
			}

			return cArchetypeRoot;
		}

		public static TConstraint Map(this T_CONSTRAINT model)
		{
			var tConstraint = new TConstraint();
			foreach (var attribute in model.attributes)
			{
				tConstraint.Attributes.Add(attribute.Map());
			}
			return tConstraint;
		}

		public static TView Map(this T_VIEW model)
		{
			//TODO:
			return null;
		}

		public static Annotation Map(this ANNOTATION model)
		{
			//TODO:
			return null;
		}

		public static FlatArchetypeOntology Map(this FLAT_ARCHETYPE_ONTOLOGY model)
		{
			//TODO:
			return null;
		}

		private static CPrimitiveObject Map(this C_PRIMITIVE_OBJECT model)
		{
			var primitiveObject = new CPrimitiveObject
			                      	{
			                      		AnyAllowed = model.any_allowed,
			                      		NodeId = model.node_id,
			                      		Item = model.item.Map(),
			                      		ReferenceModelTypeName = model.rm_type_name,
			                      		Occurences = model.occurrences.Map()
			                      	};
			return primitiveObject;
		}

		private static TAttribute Map(this T_ATTRIBUTE model)
		{
			var attribute = new TAttribute
			                	{
			                		DifferentialPath = model.differential_path,
			                		ReferenceModelAttributeName = model.rm_attribute_name
			                	};
			foreach (var child in model.children)
			{
				attribute.Children.Add(child.Map());
			}
			return attribute;
		}

		private static TComplexObject Map(this T_COMPLEX_OBJECT model)
		{
			var complexObject = new TComplexObject
			                    	{
			                    		NodeId = model.node_id,
			                    		ReferenceModelTypeName = model.rm_type_name,
			                    		Occurences = model.occurrences.Map(),
			                    		AnyAllowed = model.any_allowed,
			                    		DefaultValue = model.default_value.Map()
			                    	};
			foreach (var attribute in model.attributes)
			{
				complexObject.Attributes.Add(attribute.Map());
			}
			return complexObject;
		}

		private static object Map(this DATA_VALUE model)
		{
			// the order of the if clauses is important!
			if (model is DV_BOOLEAN)
			{
				return ((DV_BOOLEAN)model).Map();
			}
			if (model is DV_IDENTIFIER)
			{
				return ((DV_IDENTIFIER)model).Map();
			}
			if (model is DV_STATE)
			{
				return ((DV_STATE)model).Map();
			}
			if (model is DV_COUNT)
			{
				return ((DV_COUNT)model).Map();
			}
			if (model is DV_QUANTITY)
			{
				return ((DV_QUANTITY)model).Map();
			}
			if (model is DV_PROPORTION)
			{
				return ((DV_PROPORTION)model).Map();
			}
			if (model is DV_DURATION)
			{
				return ((DV_DURATION)model).Map();
			}
			if (model is DV_AMOUNT)
			{
				return ((DV_AMOUNT)model).Map();
			}
			if (model is DV_TIME)
			{
				return ((DV_TIME)model).Map();
			}
			if (model is DV_DATE)
			{
				return ((DV_DATE)model).Map();
			}
			if (model is DV_DATE_TIME)
			{
				return ((DV_DATE_TIME)model).Map();
			}
			if (model is DV_TEMPORAL)
			{
				return ((DV_TEMPORAL)model).Map();
			}
			if (model is DV_ORDINAL)
			{
				return ((DV_ORDINAL)model).Map();
			}
			if (model is DV_INTERVAL)
			{
				return ((DV_INTERVAL)model).Map();
			}
			if (model is DV_PARAGRAPH)
			{
				return ((DV_PARAGRAPH)model).Map();
			}
			if (model is DV_CODED_TEXT)
			{
				return ((DV_CODED_TEXT)model).Map();
			}
			if (model is DV_TEXT)
			{
				return ((DV_TEXT)model).Map();
			}
			if (model is DV_PERIODIC_TIME_SPECIFICATION)
			{
				return ((DV_PERIODIC_TIME_SPECIFICATION)model).Map();
			}
			if (model is DV_GENERAL_TIME_SPECIFICATION)
			{
				return ((DV_GENERAL_TIME_SPECIFICATION)model).Map();
			}
			if (model is DV_MULTIMEDIA)
			{
				return ((DV_MULTIMEDIA)model).Map();
			}
			if (model is DV_PARSABLE)
			{
				return ((DV_PARSABLE)model).Map();
			}
			if (model is DV_EHR_URI)
			{
				return ((DV_EHR_URI)model).Map();
			}
			if (model is DV_URI)
			{
				return ((DV_URI)model).Map();
			}
			throw new ParseException(string.Format("'{0}' is not a valid datavalue type.", model.GetType()));
		}

		private static CAttribute Map(this C_ATTRIBUTE model)
		{
			CAttribute attribute;
			if (model is C_SINGLE_ATTRIBUTE)
			{
				attribute = new CSingleAttribute();
			}
			else if (model is C_MULTIPLE_ATTRIBUTE)
			{
				attribute = new CMultipleAttribute();
				((CMultipleAttribute) attribute).Cardinality = ((C_MULTIPLE_ATTRIBUTE) model).cardinality.Map();
			}
			else
			{
				throw new ParseException(string.Format("'{0}' is not a valid attribute type.", model.GetType()));
			}

			attribute.Existence = model.existence.Map();
			attribute.ReferenceModelAttributeName = model.rm_attribute_name;
			if (model.children != null)
			{
				foreach (C_OBJECT child in model.children)
				{
					attribute.Children.Add(child.Map(attribute));
				}
			}
			return attribute;
		}

		private static Cardinality Map(this CARDINALITY model)
		{
			var cardinality = new Cardinality
			                  	{
			                  		IsOrdered = model.is_ordered,
			                  		IsUnique = model.is_unique,
			                  		Interval = model.interval.Map()
			                  	};
			return cardinality;
		}

		private static CObject Map(this C_OBJECT model, CAttribute parent)
		{
			CObject constraintObject;

			if (model is C_COMPLEX_OBJECT)
			{
				constraintObject = ((C_COMPLEX_OBJECT) model).Map();
			}
			else if (model is C_PRIMITIVE_OBJECT)
			{
				constraintObject = ((C_PRIMITIVE_OBJECT) model).Map();
			}
			else if (model is ARCHETYPE_SLOT)
			{
				constraintObject = ((ARCHETYPE_SLOT) model).Map();
			}
			else if (model is ARCHETYPE_INTERNAL_REF)
			{
				constraintObject = ((ARCHETYPE_INTERNAL_REF) model).Map();
			}
			else if (model is CONSTRAINT_REF)
			{
				constraintObject = ((CONSTRAINT_REF) model).Map();
			}
			else if (model is C_CODE_PHRASE)
			{
				constraintObject = ((C_CODE_PHRASE) model).Map();
			}
			else if (model is C_DV_QUANTITY)
			{
				constraintObject = ((C_DV_QUANTITY) model).Map();
			}
			else if (model is C_DV_ORDINAL)
			{
				constraintObject = ((C_DV_ORDINAL) model).Map();
			}
			else
			{
				throw new ParseException(string.Format("'{0}' is not a valid object type.", model.GetType()));
			}
			if (constraintObject != null)
				constraintObject.Parent = parent;
			return constraintObject;
		}

		private static CCodePhrase Map(this C_CODE_PHRASE model)
		{
			var codePhrase = new CCodePhrase
			                 	{
			                 		Occurences = model.occurrences.Map(),
			                 		NodeId = model.node_id,
			                 		TerminologyId = new TerminologyId(model.terminology_id.value),
			                 		ReferenceModelTypeName = model.rm_type_name
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

		private static ArchetypeSlot Map(this ARCHETYPE_SLOT model)
		{
			var archetypeSlot = new ArchetypeSlot
			                    	{
			                    		Occurences = model.occurrences.Map(),
			                    		NodeId = model.node_id,
			                    		ReferenceModelTypeName = model.rm_type_name
			                    	};
			if (model.includes != null)
			{
				foreach (ASSERTION assertion in model.includes)
				{
					archetypeSlot.Includes.Add(assertion.Map());
				}
			}
			if (model.excludes != null)
			{
				foreach (ASSERTION assertion in model.excludes)
				{
					archetypeSlot.Excludes.Add(assertion.Map());
				}
			}
			return archetypeSlot;
		}

		private static ArchetypeInternalRef Map(this ARCHETYPE_INTERNAL_REF model)
		{
			var archetypeInternalRef = new ArchetypeInternalRef
			                           	{
			                           		Occurences = model.occurrences.Map(),
			                           		NodeId = model.node_id,
			                           		ReferenceModelTypeName = model.rm_type_name,
			                           		TargetPath = model.target_path
			                           	};
			return archetypeInternalRef;
		}

		private static ConstraintRef Map(this CONSTRAINT_REF model)
		{
			var constraintRef = new ConstraintRef
			                    	{
			                    		NodeId = model.node_id,
			                    		Occurences = model.occurrences.Map(),
			                    		Reference = model.reference,
			                    		ReferenceModelTypeName = model.rm_type_name
			                    	};
			return constraintRef;
		}

		private static CQuantity Map(this C_DV_QUANTITY model)
		{
			var quantity = new CQuantity
			               	{
			               		ReferenceModelTypeName = model.rm_type_name,
			               		NodeId = model.node_id
			               	};
			if (model.property != null)
				quantity.Property = model.property.Map();
			if (model.occurrences != null)
				quantity.Occurences = model.occurrences.Map();
			foreach (C_QUANTITY_ITEM unit in model.list)
			{
				quantity.QuantityConstraints.Add(new CQuantityItem
				                                 	{
				                                 		Units = unit.units,
				                                 		Magnitude = unit.magnitude.Map()
				                                 	});
			}
			return quantity;
		}

		private static COrdinal Map(this C_DV_ORDINAL model)
		{
			var ordinal = new COrdinal
			              	{
			              		ReferenceModelTypeName = model.rm_type_name,
			              		NodeId = model.node_id,
			              		Occurences = model.occurrences.Map()
			              	};

			foreach (DV_ORDINAL dvOrdinal in model.list)
			{
				ordinal.Ordinals.Add(dvOrdinal.Map());
			}

			return ordinal;
		}

		private static CodedText Map(this DV_CODED_TEXT model)
		{
			var codedText = new CodedText(model.value)
			                	{
			                		DefiningCode = model.defining_code.Map(),
			                		Formatting = model.formatting
			                	};
			if (model.language != null)
				codedText.Language = model.language.Map();
			if (model.encoding != null)
				codedText.Encoding = model.encoding.Map();
			if (model.hyperlink != null)
				codedText.Hyperlink = new Uri(model.hyperlink.value.ToString());
			foreach (TERM_MAPPING mapping in model.mappings)
			{
				codedText.Mappings.Add(mapping.Map());
			}
			return codedText;
		}

		public static CodePhrase Map(this CODE_PHRASE model)
		{
			if (model == null) return null;
			var codePhrase = new CodePhrase(model.code_string);
			if (model.terminology_id != null)
				codePhrase.TerminologyId = new TerminologyId(model.terminology_id.value);
			return codePhrase;
		}

		private static TerminologyMapping Map(this TERM_MAPPING model)
		{
			var termMapping = new TerminologyMapping
			                  	{
			                  		Purpose = model.purpose.Map(),
			                  		Target = model.target.Map()
			                  	};
			Match match;
			Enum.TryParse(model.match, true, out match);
			termMapping.Match = match;
			return termMapping;
		}

		private static ReferenceRange<T> Map<T>(this REFERENCE_RANGE model) where T : Ordered<T>
		{
			var referenceRange = new ReferenceRange<T>
			                     	{
			                     		Meaning = new Text(model.meaning.value)
			                     		          	{
			                     		          		Formatting = model.meaning.formatting,
			                     		          		Encoding = model.meaning.encoding.Map(),
			                     		          		Language = model.meaning.language.Map(),
			                     		          		Hyperlink = new Uri(model.meaning.hyperlink.value.ToString())
			                     		          	}
			                     	};

			foreach (TERM_MAPPING mapping in model.meaning.mappings)
			{
				referenceRange.Meaning.Mappings.Add(mapping.Map());
			}
			referenceRange.Range = model.range.Map<T>();

			return referenceRange;
		}

		private static CPrimitive Map(this C_PRIMITIVE model)
		{
			CPrimitive primitive;

			if (model is C_BOOLEAN)
			{
				primitive = ((C_BOOLEAN) model).Map();
			}
			else if (model is C_INTEGER)
			{
				primitive = ((C_INTEGER) model).Map();
			}
			else if (model is C_STRING)
			{
				primitive = ((C_STRING) model).Map();
			}
			else if (model is C_DURATION)
			{
				primitive = ((C_DURATION) model).Map();
			}
			else if (model is C_DATE)
			{
				primitive = ((C_DATE) model).Map();
			}
			else if (model is C_DATE_TIME)
			{
				primitive = ((C_DATE_TIME) model).Map();
			}
			else if (model is C_REAL)
			{
				primitive = ((C_REAL) model).Map();
			}
			else
			{
				throw new ParseException(string.Format("'{0}' is not a valid primitive type.", model.GetType()));
			}
			return primitive;
		}

		private static CBoolean Map(this C_BOOLEAN model)
		{
			var primitive = new CBoolean
			                	{
			                		IsFalseValid = model.false_valid,
			                		IsTrueValid = model.true_valid
			                	};
			if (model.assumed_value.HasValue)
				primitive.AssumedValue = model.assumed_value.Value;
			return primitive;
		}

		private static CInteger Map(this C_INTEGER model)
		{
			var primitive = new CInteger
			                	{
			                		Range = model.range.Map()
			                	};
			if (model.assumed_value.HasValue)
				primitive.AssumedValue = model.assumed_value.Value;
			foreach (int i in model.list)
			{
				primitive.List.Add(i);
			}
			return primitive;
		}

		private static CReal Map(this C_REAL model)
		{
			var primitive = new CReal
			                	{
			                		Range = model.range.Map()
			                	};
			if (model.assumed_value.HasValue)
				primitive.AssumedValue = model.assumed_value.Value;
			foreach (int i in model.list)
			{
				primitive.List.Add(i);
			}
			return primitive;
		}

		private static CString Map(this C_STRING model)
		{
			var primitive = new CString
			                	{
			                		Pattern = model.pattern,
			                		AssumedValue = model.assumed_value
			                	};
			if (model.list_open.HasValue)
				primitive.IsListOpen = model.list_open.Value;
			foreach (string s in model.list)
			{
				primitive.List.Add(s);
			}
			return primitive;
		}

		private static CDuration Map(this C_DURATION model)
		{
			var primitive = new CDuration
			                	{
			                		AssumedValue = new Duration(model.assumed_value),
			                		Pattern = model.pattern
			                	};
			if (model.range != null)
				primitive.Range = model.range.Map();
			return primitive;
		}

		private static CDate Map(this C_DATE model)
		{
			var primitive = new CDate
			                	{
			                		AssumedValue = new Date
			                		               	{
			                		               		Value = model.assumed_value
			                		               	},
			                		Pattern = model.pattern
			                	};
			if (model.range != null)
				primitive.Range = model.range.Map();
			return primitive;
		}

		private static CDateTime Map(this C_DATE_TIME model)
		{
			var primitive = new CDateTime
			                	{
			                		AssumedValue = new DateTime
			                		               	{
			                		               		Value = model.assumed_value
			                		               	},
			                		Pattern = model.pattern
			                	};
			if (model.range != null)
				primitive.Range = model.range.Map();
			return primitive;
		}

		private static Interval<int> Map(this IntervalOfInteger model)
		{
			if (model == null) return null;
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

		private static Interval<double> Map(this IntervalOfReal model)
		{
			if (model == null) return null;
			var interval = new Interval<double>();

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

		private static Interval<Date> Map(this IntervalOfDate model)
		{
			if (model == null) return null;
			var interval = new Interval<Date>
			               	{
			               		Lower = new Date
			               		        	{
			               		        		Value = model.lower
			               		        	},
			               		Upper = new Date
			               		        	{
			               		        		Value = model.upper
			               		        	}
			               	};
			if (model.lower_included.HasValue)
				interval.IsLowerIncluded = model.lower_included.Value;
			if (model.upper_included.HasValue)
				interval.IsUpperIncluded = model.upper_included.Value;
			return interval;
		}

		private static Interval<DateTime> Map(this IntervalOfDateTime model)
		{
			if (model == null) return null;
			var interval = new Interval<DateTime>
			               	{
			               		Lower = new DateTime
			               		        	{
			               		        		Value = model.lower
			               		        	},
			               		Upper = new DateTime
			               		        	{
			               		        		Value = model.upper
			               		        	}
			               	};
			if (model.lower_included.HasValue)
				interval.IsLowerIncluded = model.lower_included.Value;
			if (model.upper_included.HasValue)
				interval.IsUpperIncluded = model.upper_included.Value;
			return interval;
		}

		private static Interval<T> Map<T>(this DV_INTERVAL model) where T : Ordered<T>
		{
			if (model == null) return null;
			var interval = new Interval<T>();
			if (model.lower != null)
				interval.Lower = (T)model.lower.Map();
			if (model.lower_included.HasValue)
				interval.IsLowerIncluded = model.lower_included.Value;
			if (model.upper != null)
				interval.Upper = (T)model.upper.Map();
			if (model.upper_included.HasValue)
				interval.IsUpperIncluded = model.upper_included.Value;

			return interval;
		}

		private static Interval<Duration> Map(this IntervalOfDuration model)
		{
			if (model == null) return null;
			var interval = new Interval<Duration>
			               	{
			               		Lower = new Duration(model.lower),
			               		Upper = new Duration(model.upper)
			               	};
			if (model.lower_included.HasValue)
				interval.IsLowerIncluded = model.lower_included.Value;
			if (model.upper_included.HasValue)
				interval.IsUpperIncluded = model.upper_included.Value;
			return interval;
		}

		private static Ordinal Map(this DV_ORDINAL model)
		{
			var ordinal = new Ordinal(model.value);
			if (model.normal_status != null)
			{
				ordinal.NormalStatus = model.normal_status.Map();
			}
			if (model.normal_range != null)
			{
				ordinal.NormalRange = model.normal_range.Map<Ordinal>();
			}
			if (model.symbol != null)
			{
				ordinal.Symbol = model.symbol.Map();
			}

			if (model.other_reference_ranges != null)
			{
				foreach (REFERENCE_RANGE range in model.other_reference_ranges)
				{
					ordinal.OtherReferenceRanges.Add(range.Map<Ordinal>());
				}
			}
			return ordinal;
		}

		private static Boolean Map(this DV_BOOLEAN model)
		{
			return new Boolean
			{
				Value = model.value
			};
		}

		private static Identifier Map(this DV_IDENTIFIER model)
		{
			var identifier = new Identifier
			                 	{
			                 		Assigner = model.assigner,
			                 		Id = model.id,
			                 		Issuer = model.issuer,
			                 		Type = model.type
			                 	};
			return identifier;
		}

		private static State Map(this DV_STATE model)
		{
			var state = new State
			            	{
			            		IsTerminal = model.is_terminal,
			            		Value = model.value.Map()
			            	};
			return state;
		}

		private static Count Map(this DV_COUNT model)
		{
			var count = new Count();
			if (model.accuracy.HasValue) count.Accuracy = model.accuracy.Value;
			if (model.accuracy_is_percent.HasValue) count.IsAccuracyPercent = model.accuracy_is_percent.Value;
			count.Magnitude = model.magnitude;
			count.MagnitudeStatus = model.magnitude_status;
			count.NormalRange = model.normal_range.Map<Count>();
			if (model.other_reference_ranges != null)
			{
				foreach (var range in model.other_reference_ranges)
				{
					count.OtherReferenceRanges.Add(range.Map<Count>());
				}
			}
			return count;
		}

		private static Quantity Map(this DV_QUANTITY model)
		{
			var quantity = new Quantity();
			if (model.accuracy.HasValue) quantity.Accuracy = model.accuracy.Value;
			if (model.accuracy_is_percent.HasValue) quantity.IsAccuracyPercent = model.accuracy_is_percent.Value;
			quantity.Magnitude = model.magnitude;
			quantity.MagnitudeStatus = model.magnitude_status;
			quantity.NormalRange = model.normal_range.Map<Quantity>();
			if (model.other_reference_ranges != null)
			{
				foreach (var range in model.other_reference_ranges)
				{
					quantity.OtherReferenceRanges.Add(range.Map<Quantity>());
				}
			}
			if (model.precision.HasValue) quantity.Precision = model.precision.Value;
			quantity.Units = model.units;
			return quantity;
		}
		
		#endregion
	}
}