using System;
using System.Runtime.Serialization;

namespace Vela.Portal.PatientStorage.Contracts
{
	[DataContract]
	public class Patient
	{
		[DataMember]
		public string FirstName
		{
			get;
			set;
		}
		[DataMember]
		public string LastName
		{
			get;
			set;
		}
		[DataMember]
		public DateTime BirthDate
		{
			get;
			set;
		}
		[DataMember]
		public Gender Gender
		{
			get;
			set;
		}
		[DataMember]
		public Guid PatientId
		{
			get;
			set;
		}
		[DataMember]
		public string PatientNumber
		{
			get;
			set;
		}
	}
}