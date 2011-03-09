//-----------------------------------------------------------------------
// <copyright file="XmlParserTests.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System.Diagnostics;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Vela.AM.ConstraintModel;
using Vela.AM.Primitives;

namespace Vela.AM.Adl.UnitTests
{
	[TestFixture]
	public class WhenUsingXmlParserForParsingArchetypes
	{
		[Test]
		public void AllArchetypesShouldBeParsedWithoutErrors()
		{
			foreach (var file in Directory.GetFiles(@"Archetypes\xml\", "*.xml"))
			{
				Debug.WriteLine(file);
				var archetypeString = File.ReadAllText(file);
				var archetype = XmlParser.Parse(archetypeString);
				Assert.IsNotNull(archetype, file);
			}
		}

		[Test]
		[Ignore]
		public void ParseTestArchetype()
		{
			var archetypeString = File.ReadAllText(@"archetypetest.xml");
			var archetype = XmlParser.Parse(archetypeString);
			
			// header
			Assert.AreEqual("1.4", archetype.AdlVersion);
			Assert.AreEqual("Vela-EHR-EVALUATION.test1.v1", archetype.ArchetypeId.Value);
			Assert.AreEqual("CEFA2F4D-6D3F-4172-97FF-B7FD5A063923", archetype.Uid.Value);
			Assert.AreEqual("at0000", archetype.Concept);
			Assert.AreEqual("Vela-EHR-EVALUATION.test1parent.v1", archetype.ParentArchetypeId.Value);
			Assert.AreEqual("en", archetype.OriginalLanguage.CodeString);
			Assert.AreEqual("ISO_639-1", archetype.OriginalLanguage.TerminologyId.Value);
			Assert.IsTrue(archetype.IsControlled);

			// description
			Assert.AreEqual("AuthorDraft", archetype.Description.LifecycleState);
			Assert.AreEqual(string.Empty, archetype.Description.ResourcePackageUri);
			Assert.AreEqual(4, archetype.Description.OriginalAuthor.Count);
			Assert.IsTrue(archetype.Description.OriginalAuthor.ContainsKey("email"));
			Assert.IsTrue(archetype.Description.OriginalAuthor.ContainsKey("date"));
			Assert.IsTrue(archetype.Description.OriginalAuthor.ContainsKey("name"));
			Assert.IsTrue(archetype.Description.OriginalAuthor.ContainsKey("organisation"));
			Assert.AreEqual("john.doe@vela.net", archetype.Description.OriginalAuthor["email"]);
			Assert.AreEqual("08/03/2011", archetype.Description.OriginalAuthor["date"]);
			Assert.AreEqual("John Doe", archetype.Description.OriginalAuthor["name"]);
			Assert.AreEqual("Vela", archetype.Description.OriginalAuthor["organisation"]);
			Assert.AreEqual(3, archetype.Description.OtherContributors.Count);
			Assert.IsTrue(archetype.Description.OtherContributors.Contains("Jane Doe"));
			Assert.IsTrue(archetype.Description.OtherContributors.Contains("Jeff Doe"));
			Assert.IsTrue(archetype.Description.OtherContributors.Contains("Janet Doe"));
			Assert.AreEqual(2, archetype.Description.OtherDetails.Count);
			Assert.IsTrue(archetype.Description.OtherDetails.ContainsKey("MD5-CAM-1.0.1"));
			Assert.IsTrue(archetype.Description.OtherDetails.ContainsKey("references"));
			Assert.AreEqual("md5", archetype.Description.OtherDetails["MD5-CAM-1.0.1"]);
			Assert.AreEqual(string.Empty, archetype.Description.OtherDetails["references"]);
			Assert.AreEqual(2, archetype.Description.Details.Count);
			Assert.IsTrue(archetype.Description.Details.ContainsKey("nl"));
			Assert.AreEqual("copyright-nl", archetype.Description.Details["nl"].Copyright);
			Assert.AreEqual("use-nl", archetype.Description.Details["nl"].Use);
			Assert.AreEqual("misuse-nl", archetype.Description.Details["nl"].Misuse);
			Assert.AreEqual("purpose-nl", archetype.Description.Details["nl"].Purpose);
			Assert.AreEqual("nl", archetype.Description.Details["nl"].Language.CodeString);
			Assert.AreEqual("ISO_639-1", archetype.Description.Details["nl"].Language.TerminologyId.Value);
			Assert.AreEqual(2, archetype.Description.Details["nl"].Keywords.Count);
			Assert.IsTrue(archetype.Description.Details["nl"].Keywords.Contains("keyword-nl-1"));
			Assert.IsTrue(archetype.Description.Details["nl"].Keywords.Contains("keyword-nl-2"));
			Assert.AreEqual(0, archetype.Description.Details["nl"].OtherDetails.Count);
			Assert.AreEqual(0, archetype.Description.Details["nl"].OriginalResourceUri.Count);
			Assert.IsTrue(archetype.Description.Details.ContainsKey("en"));
			Assert.AreEqual("copyright-en", archetype.Description.Details["en"].Copyright);
			Assert.AreEqual("use-en", archetype.Description.Details["en"].Use);
			Assert.AreEqual("misuse-en", archetype.Description.Details["en"].Misuse);
			Assert.AreEqual("purpose-en", archetype.Description.Details["en"].Purpose);
			Assert.AreEqual("en", archetype.Description.Details["en"].Language.CodeString);
			Assert.AreEqual("ISO_639-1", archetype.Description.Details["en"].Language.TerminologyId.Value);
			Assert.AreEqual(4, archetype.Description.Details["en"].Keywords.Count);
			Assert.IsTrue(archetype.Description.Details["en"].Keywords.Contains("keyword-en-1"));
			Assert.IsTrue(archetype.Description.Details["en"].Keywords.Contains("keyword-en-2"));
			Assert.IsTrue(archetype.Description.Details["en"].Keywords.Contains("keyword-en-3"));
			Assert.IsTrue(archetype.Description.Details["en"].Keywords.Contains("keyword-en-4"));
			Assert.AreEqual(0, archetype.Description.Details["en"].OtherDetails.Count);
			Assert.AreEqual(0, archetype.Description.Details["en"].OriginalResourceUri.Count);
			
			// definition
			Assert.AreEqual("EVALUATION", archetype.Definition.ReferenceModelTypeName);
			Assert.AreEqual("at0000", archetype.Definition.NodeId);
			Assert.AreEqual(2, archetype.Definition.Occurences.Upper);
			Assert.AreEqual(0, archetype.Definition.Occurences.Lower);
			Assert.IsFalse(archetype.Definition.Occurences.IsLowerIncluded);
			Assert.IsFalse(archetype.Definition.Occurences.IsUpperIncluded);
			Assert.IsFalse(archetype.Definition.Occurences.IsLowerUnbounded);
			Assert.IsFalse(archetype.Definition.Occurences.IsUpperUnbounded);
			Assert.AreEqual(1, archetype.Definition.Attributes.Count);
			Assert.AreEqual(typeof(CMultipleAttribute), archetype.Definition.Attributes.First().GetType());
			var ma = (CMultipleAttribute)archetype.Definition.Attributes.First();
			Assert.AreEqual("items", ma.ReferenceModelAttributeName);

			Assert.AreEqual(12, ma.Children.Count);

			Assert.IsTrue(ma.Cardinality.IsOrdered);
			Assert.IsTrue(ma.Cardinality.IsUnique);
			Assert.AreEqual(0, ma.Cardinality.Interval.Upper);
			Assert.AreEqual(1, ma.Cardinality.Interval.Lower);
			Assert.IsTrue(ma.Cardinality.Interval.IsLowerIncluded);
			Assert.IsFalse(ma.Cardinality.Interval.IsUpperIncluded);
			Assert.IsFalse(ma.Cardinality.Interval.IsLowerUnbounded);
			Assert.IsTrue(ma.Cardinality.Interval.IsUpperUnbounded);

			Assert.AreEqual(typeof(CComplexObject), ma.Children[0].GetType());
			var co = (CComplexObject) ma.Children[0];
			Assert.AreEqual("ELEMENT", co.ReferenceModelTypeName);
			Assert.AreEqual("at0001", co.NodeId);
			Assert.AreEqual(ma.ReferenceModelAttributeName, co.Parent.ReferenceModelAttributeName);
			Assert.AreEqual(1, co.Occurences.Upper);
			Assert.AreEqual(1, co.Occurences.Lower);
			Assert.IsTrue(co.Occurences.IsLowerIncluded);
			Assert.IsTrue(co.Occurences.IsUpperIncluded);
			Assert.IsFalse(co.Occurences.IsLowerUnbounded);
			Assert.IsFalse(co.Occurences.IsUpperUnbounded);
			Assert.AreEqual(1, co.Attributes.Count);
			Assert.AreEqual(typeof(CSingleAttribute), co.Attributes.First().GetType());
			var sa = (CSingleAttribute)co.Attributes.First();
			Assert.AreEqual(1, sa.Existence.Upper);
			Assert.AreEqual(1, sa.Existence.Lower);
			Assert.IsFalse(sa.Existence.IsLowerIncluded);
			Assert.IsFalse(sa.Existence.IsUpperIncluded);
			Assert.IsFalse(sa.Existence.IsLowerUnbounded);
			Assert.IsFalse(sa.Existence.IsUpperUnbounded);
			Assert.AreEqual("value", sa.ReferenceModelAttributeName);
			Assert.AreEqual(1, sa.Children.Count);
			co = (CComplexObject)sa.Children[0];
			Assert.IsTrue(co.AnyAllowed);
			Assert.AreEqual("DV_TEXT", co.ReferenceModelTypeName);

			Assert.AreEqual(typeof(CQuantity), ma.Children[1].GetType());
			var qu = (CQuantity)ma.Children[1];
			Assert.IsFalse(qu.AnyAllowed);
			Assert.AreEqual("DV_QUANTITY", qu.ReferenceModelTypeName);
			Assert.AreEqual(string.Empty, qu.NodeId);
			Assert.AreEqual(1, qu.Occurences.Upper);
			Assert.AreEqual(1, qu.Occurences.Lower);
			Assert.IsTrue(qu.Occurences.IsLowerIncluded);
			Assert.IsTrue(qu.Occurences.IsUpperIncluded);
			Assert.IsFalse(qu.Occurences.IsLowerUnbounded);
			Assert.IsFalse(qu.Occurences.IsUpperUnbounded);
			Assert.AreEqual("382", qu.CodePhrase.CodeString);
			Assert.AreEqual("openehr", qu.CodePhrase.TerminologyId.Value);
			Assert.AreEqual(2, qu.Quantities.Count);
			//Assert.IsTrue(qu.Quantities.Contains("l/m"));
			//Assert.IsTrue(qu.Quantities.Contains("ml/min"));

			Assert.AreEqual(typeof(ConstraintRef), ma.Children[2].GetType());
			var cr = (ConstraintRef)ma.Children[2];
			Assert.AreEqual("CODE_PHRASE", cr.ReferenceModelTypeName);
			Assert.AreEqual(string.Empty, cr.NodeId);
			Assert.AreEqual("ac0.1", cr.Reference);
			Assert.AreEqual(1, cr.Occurences.Upper);
			Assert.AreEqual(1, cr.Occurences.Lower);
			Assert.IsTrue(cr.Occurences.IsLowerIncluded);
			Assert.IsTrue(cr.Occurences.IsUpperIncluded);
			Assert.IsFalse(cr.Occurences.IsLowerUnbounded);
			Assert.IsFalse(cr.Occurences.IsUpperUnbounded);

			Assert.AreEqual(typeof(CPrimitiveObject), ma.Children[3].GetType());
			var du = (CPrimitiveObject)ma.Children[3];
			Assert.IsFalse(du.AnyAllowed);
			Assert.AreEqual("DV_DURATION", du.ReferenceModelTypeName);
			Assert.AreEqual(string.Empty, du.NodeId);
			Assert.AreEqual(1, du.Occurences.Upper);
			Assert.AreEqual(1, du.Occurences.Lower);
			Assert.IsTrue(du.Occurences.IsLowerIncluded);
			Assert.IsTrue(du.Occurences.IsUpperIncluded);
			Assert.IsFalse(du.Occurences.IsLowerUnbounded);
			Assert.IsFalse(du.Occurences.IsUpperUnbounded);
			Assert.AreEqual(typeof(CDuration), du.Item.GetType());
			Assert.AreEqual("PT1M", ((CDuration)du.Item).Range.Lower.Value);
			Assert.AreEqual("PT1M", ((CDuration)du.Item).Range.Upper.Value);

			Assert.AreEqual(typeof(COrdinal), ma.Children[4].GetType());
			var or = (COrdinal)ma.Children[4];
			Assert.AreEqual("DV_ORDINAL", or.ReferenceModelTypeName);
			Assert.AreEqual(string.Empty, or.NodeId);
			Assert.AreEqual(1, or.Occurences.Upper);
			Assert.AreEqual(1, or.Occurences.Lower);
			Assert.IsTrue(or.Occurences.IsLowerIncluded);
			Assert.IsTrue(or.Occurences.IsUpperIncluded);
			Assert.IsFalse(or.Occurences.IsLowerUnbounded);
			Assert.IsFalse(or.Occurences.IsUpperUnbounded);
			Assert.AreEqual(3, or.Ordinals.Count);
			Assert.AreEqual(1, or.Ordinals[0].Value);
			Assert.AreEqual("at0002", or.Ordinals[0].Symbol.DefiningCode.CodeString);
			Assert.AreEqual("local", or.Ordinals[0].Symbol.DefiningCode.TerminologyId.Value);
			Assert.AreEqual(4, or.Ordinals[1].Value);
			Assert.AreEqual("at0003", or.Ordinals[1].Symbol.DefiningCode.CodeString);
			Assert.AreEqual("local", or.Ordinals[1].Symbol.DefiningCode.TerminologyId.Value);
			Assert.AreEqual(7, or.Ordinals[2].Value);
			Assert.AreEqual("at0004", or.Ordinals[2].Symbol.DefiningCode.CodeString);
			Assert.AreEqual("local", or.Ordinals[2].Symbol.DefiningCode.TerminologyId.Value);

			Assert.AreEqual(typeof(CPrimitiveObject), ma.Children[5].GetType());
			var da = (CPrimitiveObject)ma.Children[5];
			Assert.AreEqual("DV_DATE", da.ReferenceModelTypeName);
			Assert.AreEqual(string.Empty, da.NodeId);
			Assert.AreEqual(1, da.Occurences.Upper);
			Assert.AreEqual(1, da.Occurences.Lower);
			Assert.IsTrue(da.Occurences.IsLowerIncluded);
			Assert.IsTrue(da.Occurences.IsUpperIncluded);
			Assert.IsFalse(da.Occurences.IsLowerUnbounded);
			Assert.IsFalse(da.Occurences.IsUpperUnbounded);
			Assert.AreEqual(typeof(CDate), da.Item.GetType());
			Assert.AreEqual("yyyy-??-XX", ((CDate)da.Item).Pattern);

			Assert.AreEqual(typeof(CPrimitiveObject), ma.Children[6].GetType());
			var it = (CPrimitiveObject)ma.Children[6];
			Assert.AreEqual("INTEGER", it.ReferenceModelTypeName);
			Assert.AreEqual(string.Empty, it.NodeId);
			Assert.AreEqual(1, it.Occurences.Upper);
			Assert.AreEqual(1, it.Occurences.Lower);
			Assert.IsTrue(it.Occurences.IsLowerIncluded);
			Assert.IsTrue(it.Occurences.IsUpperIncluded);
			Assert.IsFalse(it.Occurences.IsLowerUnbounded);
			Assert.IsFalse(it.Occurences.IsUpperUnbounded);
			Assert.AreEqual(typeof(CInteger), it.Item.GetType());
			Assert.AreEqual(1, ((CInteger)it.Item).Range.Lower);
			Assert.IsTrue(((CInteger)it.Item).Range.IsLowerIncluded);
			Assert.IsFalse(((CInteger)it.Item).Range.IsUpperIncluded);
			Assert.IsFalse(((CInteger)it.Item).Range.IsLowerUnbounded);
			Assert.IsTrue(((CInteger)it.Item).Range.IsUpperUnbounded);

			Assert.AreEqual(typeof(CCodePhrase), ma.Children[7].GetType());
			var cp = (CCodePhrase)ma.Children[7];
			Assert.AreEqual("CODE_PHRASE", cp.ReferenceModelTypeName);
			Assert.AreEqual(string.Empty, cp.NodeId);
			Assert.AreEqual(1, cp.Occurences.Upper);
			Assert.AreEqual(1, cp.Occurences.Lower);
			Assert.IsTrue(cp.Occurences.IsLowerIncluded);
			Assert.IsTrue(cp.Occurences.IsUpperIncluded);
			Assert.IsFalse(cp.Occurences.IsLowerUnbounded);
			Assert.IsFalse(cp.Occurences.IsUpperUnbounded);
			Assert.AreEqual(1, cp.CodePhrases.Count);
			Assert.AreEqual("at0005", cp.CodePhrases.First().CodeString);

			Assert.AreEqual(typeof(CPrimitiveObject), ma.Children[8].GetType());
			var dt = (CPrimitiveObject)ma.Children[8];
			Assert.AreEqual("DV_DATE_TIME", dt.ReferenceModelTypeName);
			Assert.AreEqual(string.Empty, dt.NodeId);
			Assert.AreEqual(1, dt.Occurences.Upper);
			Assert.AreEqual(1, dt.Occurences.Lower);
			Assert.IsTrue(dt.Occurences.IsLowerIncluded);
			Assert.IsTrue(dt.Occurences.IsUpperIncluded);
			Assert.IsFalse(dt.Occurences.IsLowerUnbounded);
			Assert.IsFalse(dt.Occurences.IsUpperUnbounded);
			Assert.AreEqual(typeof(CDateTime), dt.Item.GetType());
			Assert.AreEqual("yyyy-??-??T??:??:??", ((CDateTime)dt.Item).Pattern);

			Assert.AreEqual(typeof(CPrimitiveObject), ma.Children[9].GetType());
			var re = (CPrimitiveObject)ma.Children[9];
			Assert.AreEqual("DOUBLE", re.ReferenceModelTypeName);
			Assert.AreEqual(string.Empty, re.NodeId);
			Assert.AreEqual(1, re.Occurences.Upper);
			Assert.AreEqual(1, re.Occurences.Lower);
			Assert.IsTrue(re.Occurences.IsLowerIncluded);
			Assert.IsTrue(re.Occurences.IsUpperIncluded);
			Assert.IsFalse(re.Occurences.IsLowerUnbounded);
			Assert.IsFalse(re.Occurences.IsUpperUnbounded);
			Assert.AreEqual(typeof(CReal), re.Item.GetType());
			Assert.AreEqual(0.0, ((CReal)re.Item).Range.Lower);
			Assert.IsTrue(((CReal)re.Item).Range.IsLowerIncluded);
			Assert.IsFalse(((CReal)re.Item).Range.IsUpperIncluded);
			Assert.IsFalse(((CReal)re.Item).Range.IsLowerUnbounded);
			Assert.IsTrue(((CReal)re.Item).Range.IsUpperUnbounded);

			// ontology
			Assert.AreEqual(2, archetype.Ontology.TerminologyDefinitions.Count);
			Assert.IsTrue(archetype.Ontology.TerminologyDefinitions.ContainsKey("nl"));
			Assert.AreEqual(6, archetype.Ontology.TerminologyDefinitions["nl"].Count);
			var termNl = (from t in archetype.Ontology.TerminologyDefinitions["nl"]
			              where t.Code == "at0000"
			              select t).Single();
			Assert.AreEqual(2, termNl.Items.Count());
			Assert.IsTrue(termNl.Items.ContainsKey("text"));
			Assert.IsTrue(termNl.Items.ContainsKey("description"));
			Assert.IsTrue(termNl.Items["text"].Contains("at0000-text-nl"));
			Assert.IsTrue(termNl.Items["description"].Contains("at0000-description-nl"));
			Assert.IsTrue(archetype.Ontology.TerminologyDefinitions.ContainsKey("en"));
			Assert.AreEqual(6, archetype.Ontology.TerminologyDefinitions["en"].Count);
			var termEn = (from t in archetype.Ontology.TerminologyDefinitions["en"]
						  where t.Code == "at0003"
						  select t).Single();
			Assert.AreEqual(2, termEn.Items.Count());
			Assert.IsTrue(termEn.Items.ContainsKey("text"));
			Assert.IsTrue(termEn.Items.ContainsKey("description"));
			Assert.IsTrue(termEn.Items["text"].Contains("at0003-text-en"));
			Assert.IsTrue(termEn.Items["description"].Contains("at0003-description-en"));
			// TODO
			Assert.AreEqual(0, archetype.Ontology.TerminologyBindings.Count);
			// TODO
			Assert.AreEqual(0, archetype.Ontology.ConstraintDefinitions.Count);
			// TODO
			Assert.AreEqual(0, archetype.Ontology.ConstraintBindings.Count);
		}
	}
}