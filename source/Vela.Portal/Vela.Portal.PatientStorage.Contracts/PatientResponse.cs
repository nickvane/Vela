using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Vela.Portal.PatientStorage.Contracts
{
	[DataContract]
	public class PatientResponse
	{
		[DataMember]
		public IList<Patient> Patients
		{
			get;
			set;
		}
	}
}