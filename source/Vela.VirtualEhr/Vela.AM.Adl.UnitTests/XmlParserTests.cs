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
using Vela.AM.Aom.Assertions;
using Vela.AM.Aom.ConstraintModel;
using Vela.AM.Aom.Primitives;
using Vela.AM.Ap.DataTypes.Quantity;
using Vela.AM.Ap.DataTypes.Text;

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
				var archetype = new XmlParser().Parse(archetypeString);
				Assert.IsNotNull(archetype, file);
			}
		}

		[Test]
		public void ArchetypeWithMissingMandatorySections()
		{
			string s1 = File.ReadAllText(@"Tests\ArchetypeWithNoArchetypeId.xml");
			Assert.Throws<ParseException>(() => new XmlParser().Parse(s1));
			string s2 = File.ReadAllText(@"Tests\ArchetypeWithNoConcept.xml");
			Assert.Throws<ParseException>(() => new XmlParser().Parse(s2));
			string s3 = File.ReadAllText(@"Tests\ArchetypeWithNoDefinition.xml");
			Assert.Throws<ParseException>(() => new XmlParser().Parse(s3));
			string s4 = File.ReadAllText(@"Tests\ArchetypeWithNoOntology.xml");
			Assert.Throws<ParseException>(() => new XmlParser().Parse(s4));
			string s5 = File.ReadAllText(@"Tests\ArchetypeWithNonConsistentTypeName.xml");
			Assert.Throws<ParseException>(() => new XmlParser().Parse(s5));
		}

		[Test]
		public void ParseFullArchetype()
		{
			var archetypeString = File.ReadAllText(@"Tests\FullArchetype.xml");
			var archetype = new XmlParser().Parse(archetypeString);
			
			// header
			Assert.AreEqual("2", archetype.AdlVersion);
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
			Assert.AreEqual(1, archetype.Description.Details["en"].OtherDetails.Count);
			Assert.IsTrue(archetype.Description.Details["en"].OtherDetails.ContainsKey("references"));
			Assert.AreEqual(string.Empty, archetype.Description.Details["en"].OtherDetails["references"]);
			Assert.AreEqual(0, archetype.Description.Details["en"].OriginalResourceUri.Count);

			//translations
			Assert.AreEqual(1, archetype.Translations.Count);
			Assert.IsTrue(archetype.Translations.ContainsKey("nl"));
			var tr = archetype.Translations["nl"];
			Assert.AreEqual("nl", tr.Language.CodeString);
			Assert.AreEqual("ISO_639-1", tr.Language.TerminologyId.Value);
			Assert.AreEqual(2, tr.Author.Count);
			Assert.IsTrue(tr.Author.ContainsKey("email"));
			Assert.IsTrue(tr.Author.ContainsKey("date"));
			Assert.AreEqual("john.doe@vela.net", tr.Author["email"]);
			Assert.AreEqual("08/03/2011", tr.Author["date"]);
			Assert.AreEqual("translation accreditation", tr.Accreditation);
			Assert.AreEqual(2, tr.OtherDetails.Count);
			Assert.IsTrue(tr.OtherDetails.ContainsKey("detail"));
			Assert.IsTrue(tr.OtherDetails.ContainsKey("references"));
			Assert.AreEqual("other detail", tr.OtherDetails["detail"]);
			Assert.AreEqual(string.Empty, tr.OtherDetails["references"]);

			//invariants
			Assert.AreEqual(1, archetype.Invariants.Count);
			Assert.AreEqual("invariants tag", archetype.Invariants.First().Tag);
			Assert.AreEqual("string expression", archetype.Invariants.First().ExpressionString);
			Assert.AreEqual(1, archetype.Invariants.First().Variables.Count);
			Assert.AreEqual("variable name", archetype.Invariants.First().Variables.First().Name);
			Assert.AreEqual("variable definition", archetype.Invariants.First().Variables.First().Definition);
			Assert.AreEqual(typeof(ExprUnaryOperator), archetype.Invariants.First().Expression.GetType());
			var exp1 = (ExprUnaryOperator) archetype.Invariants.First().Expression;
			Assert.AreEqual("BOOLEAN", exp1.Type);
			Assert.AreEqual(OperatorKind.OpMatches, exp1.Operator);
			Assert.IsFalse(exp1.IsPrecedenceOverriden);
			Assert.AreEqual(typeof(ExprLeaf), exp1.Operand.GetType());
			var op1 = (ExprLeaf) exp1.Operand;
			Assert.AreEqual("STRING", op1.Type);
			Assert.AreEqual("archetype_id/value", op1.Item);
			Assert.AreEqual("CONSTANT", op1.ReferenceType);
			
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

			Assert.AreEqual(13, ma.Children.Count);

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
			Assert.AreEqual("382", qu.Property.CodeString);
			Assert.AreEqual("openehr", qu.Property.TerminologyId.Value);
			Assert.AreEqual(2, qu.QuantityConstraints.Count);
			Assert.AreEqual("l/m", qu.QuantityConstraints.First().Units);
			Assert.AreEqual(50.0, qu.QuantityConstraints.First().Magnitude.Upper);
			Assert.AreEqual(0.0, qu.QuantityConstraints.First().Magnitude.Lower);
			Assert.IsTrue(qu.QuantityConstraints.First().Magnitude.IsLowerIncluded);
			Assert.IsTrue(qu.QuantityConstraints.First().Magnitude.IsUpperIncluded);
			Assert.IsFalse(qu.QuantityConstraints.First().Magnitude.IsLowerUnbounded);
			Assert.IsFalse(qu.QuantityConstraints.First().Magnitude.IsUpperUnbounded);
			Assert.AreEqual("ml/min", qu.QuantityConstraints.Last().Units);
			Assert.AreEqual(50000.0, qu.QuantityConstraints.Last().Magnitude.Upper);
			Assert.AreEqual(0.0, qu.QuantityConstraints.Last().Magnitude.Lower);
			Assert.IsTrue(qu.QuantityConstraints.Last().Magnitude.IsLowerIncluded);
			Assert.IsTrue(qu.QuantityConstraints.Last().Magnitude.IsUpperIncluded);
			Assert.IsFalse(qu.QuantityConstraints.Last().Magnitude.IsLowerUnbounded);
			Assert.IsFalse(qu.QuantityConstraints.Last().Magnitude.IsUpperUnbounded);

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
			Assert.AreEqual(1, cp.CodeList.Count);
			Assert.AreEqual("at0005", cp.CodeList.First());

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

			Assert.AreEqual(typeof(CPrimitiveObject), ma.Children[10].GetType());
			var bo = (CPrimitiveObject)ma.Children[10];
			Assert.AreEqual("DV_BOOLEAN", bo.ReferenceModelTypeName);
			Assert.AreEqual(1, bo.Occurences.Upper);
			Assert.AreEqual(1, bo.Occurences.Lower);
			Assert.IsTrue(bo.Occurences.IsLowerIncluded);
			Assert.IsTrue(bo.Occurences.IsUpperIncluded);
			Assert.IsFalse(bo.Occurences.IsLowerUnbounded);
			Assert.IsFalse(bo.Occurences.IsUpperUnbounded);
			Assert.AreEqual(typeof(CBoolean), bo.Item.GetType());
			Assert.IsTrue(((CBoolean)bo.Item).IsFalseValid);
			Assert.IsFalse(((CBoolean)bo.Item).IsTrueValid);

			Assert.AreEqual(typeof(ArchetypeSlot), ma.Children[11].GetType());
			var ars = (ArchetypeSlot)ma.Children[11];
			Assert.AreEqual("CLUSTER", ars.ReferenceModelTypeName);
			Assert.AreEqual("at0012", ars.NodeId);
			Assert.AreEqual(0, ars.Occurences.Lower);
			Assert.IsTrue(ars.Occurences.IsLowerIncluded);
			Assert.IsFalse(ars.Occurences.IsUpperIncluded);
			Assert.IsFalse(ars.Occurences.IsLowerUnbounded);
			Assert.IsTrue(ars.Occurences.IsUpperUnbounded);
			Assert.AreEqual(1, ars.Includes.Count);
			Assert.AreEqual(string.Empty, ars.Includes.First().Tag);
			Assert.AreEqual(string.Empty, ars.Includes.First().ExpressionString);
			Assert.AreEqual(typeof(ExprBinaryOperator), ars.Includes.First().Expression.GetType());
			var exp2 = (ExprBinaryOperator)ars.Includes.First().Expression;
			Assert.AreEqual("BOOLEAN", exp2.Type);
			Assert.AreEqual(OperatorKind.OpMatches, exp2.Operator);
			Assert.IsFalse(exp1.IsPrecedenceOverriden);
			Assert.AreEqual(typeof(ExprLeaf), exp2.LeftOperand.GetType());
			Assert.AreEqual(typeof(ExprLeaf), exp2.RightOperand.GetType());
			var op2 = (ExprLeaf)exp2.LeftOperand;
			Assert.AreEqual("STRING", op2.Type);
			Assert.AreEqual("archetype_id/value", op2.Item);
			Assert.AreEqual("CONSTANT", op2.ReferenceType);
			var op3 = (ExprLeaf)exp2.RightOperand;
			Assert.AreEqual("STRING", op3.Type);
			Assert.AreEqual(@"openEHR-EHR-CLUSTER\.device(-[a-zA-Z0-9_]+)*\.v1", ((CString)op3.Item).Pattern);
			Assert.AreEqual("CONSTANT", op3.ReferenceType);
			Assert.AreEqual(1, ars.Excludes.Count);

			Assert.AreEqual(typeof(ArchetypeInternalRef), ma.Children[12].GetType());
			var air = (ArchetypeInternalRef)ma.Children[12];
			Assert.AreEqual("ELEMENT", air.ReferenceModelTypeName);
			Assert.AreEqual(1, air.Occurences.Upper);
			Assert.AreEqual(1, air.Occurences.Lower);
			Assert.IsTrue(air.Occurences.IsLowerIncluded);
			Assert.IsTrue(air.Occurences.IsUpperIncluded);
			Assert.IsFalse(air.Occurences.IsLowerUnbounded);
			Assert.IsFalse(air.Occurences.IsUpperUnbounded);
			Assert.AreEqual("/data[at0001]/items[at0073]/items[at0104]/items[at0107]", air.TargetPath);

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