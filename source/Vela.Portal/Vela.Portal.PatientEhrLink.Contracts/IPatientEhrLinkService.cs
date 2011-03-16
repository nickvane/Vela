using System.ServiceModel;

namespace Vela.Portal.PatientEhrLink.Contracts
{
	[ServiceContract]
	public interface IPatientEhrLinkService
	{
		[OperationContract]
		string GetEhrId(string patientId);
	}
}
