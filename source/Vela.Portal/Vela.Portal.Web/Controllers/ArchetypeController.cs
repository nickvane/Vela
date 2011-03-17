using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;
using Vela.AM.Aom.Archetypes;
using Vela.Portal.Web.Plumbing;
using Vela.SM.ArchetypeService;

namespace Vela.Portal.Web.Controllers
{
	public class ArchetypeController : Controller
	{
		public IArchetypeService ArchetypeService { get; set; }

		//
		// GET: /Archetype/

		public ActionResult Index()
		{
			IList<Archetype> archetypes = ArchetypeService.GetAllArchetypes();
			return View(archetypes);
		}

		//
		// GET: /Archetype/Details/5

		public ActionResult Details(string id)
		{
			var archetype = ArchetypeService.GetArchetype(id);
			return View(archetype);
		}

		//
		// GET: /Archetype/Create

		public ActionResult Create()
		{
			return View();
		}

		//
		// POST: /Archetype/Create

		[HttpPost]
		[UnitOfWork]
		public ActionResult Create(FormCollection collection)
		{
			try
			{
				var postedFile = Request.Files["Archetype"];
				string archetype;
				using (var textReader = new StreamReader(postedFile.InputStream))
				{
					archetype = textReader.ReadToEnd();
				}
				
				ArchetypeService.Save(archetype);

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		//
		// GET: /Archetype/Edit/5

		public ActionResult Edit(int id)
		{
			return View();
		}

		//
		// POST: /Archetype/Edit/5

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
		// GET: /Archetype/Delete/5

		public ActionResult Delete(int id)
		{
			return View();
		}

		//
		// POST: /Archetype/Delete/5

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