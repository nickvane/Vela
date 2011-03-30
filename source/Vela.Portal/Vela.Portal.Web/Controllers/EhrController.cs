using System.Linq;
using System.Web.Mvc;
using Vela.Portal.PatientEhrLink.Contracts;
using Vela.Portal.PatientStorage.Contracts;

namespace Vela.Portal.Web.Controllers
{
	public class EhrController : Controller
	{
		public IPatientEhrLinkService PatientEhrLinkService { get; set; }
		public IPatientService PatientService { get; set; }

		//
		// GET: /Ehr/

		public ActionResult Index()
		{
			return View();
		}

		//
		// GET: /Ehr/Details/5

		public ActionResult Details(string id)
		{
			string ehrId = PatientEhrLinkService.GetEhrId(id);
			ViewBag.EhrId = ehrId;
			var patient = PatientService.GetPatients(new PatientRequest
			                                         	{
			                                         		PatientNumber = id
			                                         	}).Patients.SingleOrDefault();
			ViewBag.Patient = patient;
			return View();
		}

		//
		// GET: /Ehr/Create

		public ActionResult Create()
		{
			return View();
		}

		//
		// POST: /Ehr/Create

		[HttpPost]
		public ActionResult Create(FormCollection collection)
		{
			try
			{
				// TODO: Add insert logic here

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		//
		// GET: /Ehr/Edit/5

		public ActionResult Edit(int id)
		{
			return View();
		}

		//
		// POST: /Ehr/Edit/5

		[HttpPost]
		public ActionResult Edit(int id, FormCollection collection)
		{
			try
			{
				// TODO: Add update logic here

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		//
		// GET: /Ehr/Delete/5

		public ActionResult Delete(int id)
		{
			return View();
		}

		//
		// POST: /Ehr/Delete/5

		[HttpPost]
		public ActionResult Delete(int id, FormCollection collection)
		{
			try
			{
				// TODO: Add delete logic here

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}
	}
}