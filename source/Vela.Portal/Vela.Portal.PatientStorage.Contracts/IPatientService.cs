using System.ServiceModel;

namespace Vela.Portal.PatientStorage.Contracts
{
	[ServiceContract]
	public interface IPatientService
	{
		[OperationContract]
		PatientResponse GetPatients(PatientRequest request);
	}
}
