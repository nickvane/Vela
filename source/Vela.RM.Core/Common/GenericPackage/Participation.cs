using System;
using Vela.RM.Core.DataTypes.QuantityPackage;
using Vela.RM.Core.DataTypes.TextPackage;
using Vela.RM.Core.Support;
using DateTime = Vela.RM.Core.DataTypes.DateTimePackage.DateTime;

namespace Vela.RM.Core.Common.GenericPackage
{
	/// <summary>
	/// Model of a participation of a Party (any Actor or Role) in an activity.
	/// Used to represent any participation of a Party in some activity, which is not explicitly in the model, e.g. assisting nurse. Can be used to record past or future participations.
	/// Should not be used in place of more permanent relationships between demographic entities.
	/// </summary>
	[Serializable]
	[OpenEhrName("PARTICIPATION")]
	public class Participation
	{
		/// <summary>
		/// The id and possibly demographic system link of the party participating in the activity.
		/// </summary>
		[OpenEhrName("performer")]
		public PartyProxy Performer { get; set; }

		/// <summary>
		/// The function of the Party in this participation (note that a given party might participate in more than one way in a particular activity). This attribute should be coded, but cannot be limited to the HL7v3:ParticipationFunction vocabulary, since it is too limited and hospital-oriented.
		/// </summary>
		[OpenEhrName("function")]
		public Text Function { get; set; }

		/// <summary>
		/// The mode of the performer / activity interaction, e.g. present, by telephone, by email etc.
		/// </summary>
		[OpenEhrName("mode")]
		public CodedText Mode { get; set; }

		/// <summary>
		/// The time interval during which the participation took place, if it is used in an observational context (i.e. recording facts about the past); or the intended time interval of the participation when used in future contexts, such as EHR Instructions.
		/// </summary>
		[OpenEhrName("time")]
		public Interval<DateTime> Time { get; set; }

	}
}
