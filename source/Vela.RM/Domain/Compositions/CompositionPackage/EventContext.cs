using System;
using System.Collections.Generic;
using Vela.RM.Core.DataStructures.ItemStructurePackage;
using Vela.RM.Core.DataTypes.TextPackage;
using Vela.RM.Core.Support;
using Vela.RM.Patterns.Common.ArchetypedPackage;
using Vela.RM.Patterns.Common.GenericPackage;
using DateTime = Vela.RM.Core.DataTypes.DateTimePackage.DateTime;

namespace Vela.RM.Domain.Compositions.CompositionPackage
{
	/// <summary>
	/// Collection the context information of a healthcare event involving the subject of care and the health system. The context information recorded here are independent of the attributes recorded in the version audit, which document the “system interaction” context, i.e. the context of a user interacting with the health record system. Healthcare events include patient contacts, and any other business activity, such as pathology investigations which take place on behalf of the patient.
	/// </summary>
	[Serializable]
	[OpenEhrName("EVENT_CONTEXT")]
	public class EventContext : Pathable
	{
		/// <summary>
		/// The health care facility under whose care the event took place. This is the most specific workgroup or delivery unit within a care delivery enterprise that has an official identifier in the health system, and can be used to ensure medico-legal accountability.
		/// </summary>
		[OpenEhrName("health_care_facility")]
		public PartyIdentified HealtCareFacility { get; set; }

		/// <summary>
		/// Start time of the clinical session or other kind of event during which a provider performs a service of any kind for the patient.
		/// </summary>
		[OpenEhrName("start_time")]
		public DateTime StartTime { get; set; }

		/// <summary>
		/// Optional end time of the clinical session.
		/// </summary>
		[OpenEhrName("end_time")]
		public DateTime EndTime { get; set; }

		/// <summary>
		/// Parties involved in the healthcare event. These would normally include the physician(s) and often the patient (but not the latter if the clinical session is a pathology test for example).
		/// </summary>
		[OpenEhrName("participations")]
		public IList<Participation> Participations { get; set; }

		/// <summary>
		/// The actual location where the session occurred, e.g. “microbiol lab 2”, “home”, “ward A3” and so on.
		/// </summary>
		[OpenEhrName("location")]
		public string Location { get; set; }

		/// <summary>
		/// The setting in which the clinical session took place. Coded using the openEHR Terminology, “setting” group.
		/// </summary>
		[OpenEhrName("setting")]
		public CodedText Setting { get; set; }

		/// <summary>
		/// Other optional context which will be archetyped.
		/// </summary>
		[OpenEhrName("other_context")]
		public ItemStructure OtherContext { get; set; }

		///<summary>
		/// The path to an item relative to the root of this archetyped structure.
		///</summary>
		///<param name="item"></param>
		///<returns></returns>
		public override string GetPathOfItem(Pathable item)
		{
			throw new NotImplementedException();
		}

		///<summary>
		/// The item at a path (relative to this item); only valid for unique paths, i.e. paths that resolve to a single item.
		///</summary>
		///<param name="path"></param>
		///<returns></returns>
		public override object GetItemAtPath(string path)
		{
			throw new NotImplementedException();
		}

		///<summary>
		/// List of items corresponding to a non-unique path.
		///</summary>
		///<param name="path"></param>
		///<returns></returns>
		public override List<object> GetItemsAtPath(string path)
		{
			throw new NotImplementedException();
		}

		///<summary>
		/// True if the path exists in the data with respect to the current item.
		///</summary>
		///<param name="path"></param>
		///<returns></returns>
		public override bool DoesPathExists(string path)
		{
			throw new NotImplementedException();
		}

		///<summary>
		/// True if the path corresponds to a single item in the data.
		///</summary>
		///<param name="path"></param>
		///<returns></returns>
		public override bool IsPathUnique(string path)
		{
			throw new NotImplementedException();
		}
	}
}
