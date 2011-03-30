using System.Runtime.Serialization;

namespace Vela.Portal.PatientStorage.Contracts
{
	[DataContract]
	public enum Gender
	{
		[EnumMember]
		Male,
		[EnumMember]
		Female
	}
}