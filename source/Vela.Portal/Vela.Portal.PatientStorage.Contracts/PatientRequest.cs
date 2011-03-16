using System.Runtime.Serialization;

namespace Vela.Portal.PatientStorage.Contracts
{
	[DataContract]
	public class PatientRequest
	{
		[DataMember]
		public string Name
		{
			get;
			set;
		}
		[DataMember]
		public int? BirthYear
		{
			get;
			set;
		}
		[DataMember]
		public Gender? Gender
		{
			get;
			set;
		}
		[DataMember]
		public string PatientNumber
		{
			get; set; }
	}
}