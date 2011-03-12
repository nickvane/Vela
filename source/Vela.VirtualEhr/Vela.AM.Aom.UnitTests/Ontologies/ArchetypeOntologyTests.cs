//-----------------------------------------------------------------------
// <copyright file="ArchetypeOntologyTests.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System;
using NUnit.Framework;
using Vela.AM.Aom.Ontologies;

namespace Vela.AM.Aom.UnitTests.Ontologies
{
	[TestFixture]
	public class WhenUsingArchetypeOntology
	{
		[Test]
		public void ListsAreNotNull()
		{
			var archetypeOntology = new ArchetypeOntology();
			Assert.IsNotNull(archetypeOntology.ConstraintBindings);
			Assert.IsNotNull(archetypeOntology.ConstraintDefinitions);
			Assert.IsNotNull(archetypeOntology.TerminologyBindings);
			Assert.IsNotNull(archetypeOntology.TerminologyDefinitions);
			Assert.IsNotNull(archetypeOntology.ConstraintCodes);
			Assert.IsNotNull(archetypeOntology.TerminologyAttributeNames);
			Assert.IsNotNull(archetypeOntology.TerminologyCodes);
		}

		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void HasLanguageThrowsException()
		{
			var archetypeOntology = new ArchetypeOntology();
			var result = archetypeOntology.HasLanguage(string.Empty);
		}

		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void HasTerminologyThrowsException()
		{
			var archetypeOntology = new ArchetypeOntology();
			var result = archetypeOntology.HasTerminology(string.Empty);
		}

		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void HasTerminologyCodeThrowsException()
		{
			var archetypeOntology = new ArchetypeOntology();
			var result = archetypeOntology.HasTerminologyCode(string.Empty);
		}

		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void HasConstraintCodeThrowsException()
		{
			var archetypeOntology = new ArchetypeOntology();
			var result = archetypeOntology.HasConstraintCode(string.Empty);
		}

		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void GetConstraintDefinitionThrowsException()
		{
			var archetypeOntology = new ArchetypeOntology();
			var result = archetypeOntology.GetConstraintDefinition(string.Empty, string.Empty);
		}

		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void GetTerminologyBindingThrowsException()
		{
			var archetypeOntology = new ArchetypeOntology();
			var result = archetypeOntology.GetTerminologyBinding(string.Empty, string.Empty);
		}

		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void GetConstraintBindingThrowsException()
		{
			var archetypeOntology = new ArchetypeOntology();
			var result = archetypeOntology.GetConstraintBinding(string.Empty, string.Empty);
		}
	}
}