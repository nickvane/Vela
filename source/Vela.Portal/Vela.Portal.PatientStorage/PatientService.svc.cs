using System.Linq;
using Vela.Portal.PatientStorage.Contracts;

namespace Vela.Portal.PatientStorage
{
	public class PatientService : IPatientService
	{
		public PatientResponse GetPatients(PatientRequest request)
		{
			var patientList = new PatientRepository().GetPatients();
			var result = patientList.AsQueryable();
			if (!string.IsNullOrEmpty(request.Name))
				result = result.Where(p => p.FirstName.ToLowerInvariant().Contains(request.Name.ToLowerInvariant()) | p.LastName.ToLowerInvariant().Contains(request.Name.ToLowerInvariant()));
			if (request.BirthYear.HasValue)
				result = result.Where(p => p.BirthDate.Year == request.BirthYear);
			if (request.Gender.HasValue)
				result = result.Where(p => p.Gender == request.Gender);
			if (!string.IsNullOrEmpty(request.PatientNumber))
				result = result.Where(p => p.PatientNumber.ToLowerInvariant() == request.PatientNumber.ToLowerInvariant());
			return new PatientResponse
			       	{
			       		Patients = result.ToList()
			       	};
		}
	}
}
