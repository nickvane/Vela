using System.Web.Mvc;
using Vela.Portal.PatientStorage.Contracts;

namespace Vela.Portal.Web.Controllers
{
	public class PatientController : Controller
	{
		public IPatientService PatientService { get; set; }

		//
		// GET: /Patient/

		public ActionResult Index()
		{
			var patients = PatientService.GetPatients(new PatientRequest()).Patients;
			return View(patients);
		}
	}
}