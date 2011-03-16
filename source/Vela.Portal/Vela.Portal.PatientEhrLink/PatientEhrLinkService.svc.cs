using Vela.Portal.PatientEhrLink.Contracts;

namespace Vela.Portal.PatientEhrLink
{
	public class PatientEhrLinkService : IPatientEhrLinkService
	{
		public string GetEhrId(string patientId)
		{
			return "ehr" + patientId;
		}
	}
}
