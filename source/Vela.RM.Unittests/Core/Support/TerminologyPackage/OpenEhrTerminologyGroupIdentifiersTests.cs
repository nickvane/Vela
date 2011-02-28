using NUnit.Framework;
using Vela.RM.Core.Support.TerminologyPackage;

namespace Vela.RM.UnitTests.Core.Support.TerminologyPackage
{
	[TestFixture]
	public class WhenUsingTerminologyGroupIdentifiers
	{
		[Test]
		public void ShouldBeNoExceptions()
		{
			var test = OpenEhrTerminologyGroupIdentifiers.AttestationReason;
			test = OpenEhrTerminologyGroupIdentifiers.AuditChangeType;
			test = OpenEhrTerminologyGroupIdentifiers.CompositionCategory;
			test = OpenEhrTerminologyGroupIdentifiers.EventMathFunction;
			test = OpenEhrTerminologyGroupIdentifiers.InstructionStates;
			test = OpenEhrTerminologyGroupIdentifiers.InstructionTransitions;
			test = OpenEhrTerminologyGroupIdentifiers.NullFlavours;
			test = OpenEhrTerminologyGroupIdentifiers.ParticipationFunction;
			test = OpenEhrTerminologyGroupIdentifiers.ParticipationMode;
			test = OpenEhrTerminologyGroupIdentifiers.Property;
			test = OpenEhrTerminologyGroupIdentifiers.Setting;
			test = OpenEhrTerminologyGroupIdentifiers.SubjectRelationship;
			test = OpenEhrTerminologyGroupIdentifiers.TerminologyId;
			test = OpenEhrTerminologyGroupIdentifiers.TerminologyMappingPurpose;
			test = OpenEhrTerminologyGroupIdentifiers.VersionLifecycleStatus;

			Assert.IsTrue(OpenEhrTerminologyGroupIdentifiers.IsValidTerminologyGroupId(test));
			Assert.IsFalse(OpenEhrTerminologyGroupIdentifiers.IsValidTerminologyGroupId("boo"));
		}
	}
}
