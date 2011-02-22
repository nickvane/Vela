using System;
using Vela.RM.Core.DataTypes.TextPackage;
using Vela.RM.Core.Support;
using DateTime = Vela.RM.Core.DataTypes.DateTimePackage.DateTime;

namespace Vela.RM.Patterns.Common.GenericPackage
{
	///<summary>
	/// The set of attributes required to document the committal of an information item to a repository.
	///</summary>
	[Serializable]
	[OpenEhrName("AUDIT_DETAILS")]
	public class AuditDetails
	{
		/// <summary>
		/// Identity of the system where the change was committed. Ideally this is a machine- and human-processable identifier, but it may not be.
		/// </summary>
		[OpenEhrName("system_id")]
		public string SystemId { get; set; }

		/// <summary>
		/// Identity and optional reference into identity management service, of user who committed the item.
		/// </summary>
		[OpenEhrName("committer")]
		public PartyProxy Committer { get; set; }

		/// <summary>
		/// Time of committal of the item.
		/// </summary>
		[OpenEhrName("time_committed")]
		public DateTime TimeCommitted { get; set; }

		/// <summary>
		/// Type of change. Coded using the openEHR Terminology “audit change type” group.
		/// </summary>
		[OpenEhrName("change_type")]
		public CodedText ChangeType { get; set; }

		/// <summary>
		/// Reason for committal.
		/// </summary>
		[OpenEhrName("description")]
		public Text Description { get; set; }
	}
}
