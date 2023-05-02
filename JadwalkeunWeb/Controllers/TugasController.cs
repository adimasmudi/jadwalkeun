using JadwalkeunWeb.Data;
using JadwalkeunWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace JadwalkeunWeb.Controllers
{
	public class TugasController : Controller
	{
		private readonly ApplicationDbContext _db;
		public TugasController(ApplicationDbContext db)
		{
			_db = db;
		}

		public IActionResult Index()
		{
			IEnumerable<Tugas> objTugasList = _db.Tugases.ToList();
			return View(objTugasList);
		}

		// GET
		public IActionResult CREATE()
		{
			return View();
		}

		// POST
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult CREATE(Tugas obj)
		{
			if (obj.Status != "masuk" && obj.Status != "keluar")
			{
				ModelState.AddModelError("status", "status harus masuk atau keluar (lowercase)");
			}
			if (ModelState.IsValid)
			{
				_ = _db.Tugases.Add(obj);
				_ = _db.SaveChanges();
				TempData["success"] = "Success Create";
				return RedirectToAction("Index");
			}

			return View(obj);
		}
		// GET
		public IActionResult Edit(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			var tugasFromDb = _db.Tugases.Find(id);

			if (tugasFromDb == null)
			{
				return NotFound();
			}
			return View(tugasFromDb);
		}

		// POST
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(Tugas obj)
		{
			if (obj.Status != "masuk" && obj.Status != "keluar")
			{
				ModelState.AddModelError("status", "status harus masuk atau keluar (lowercase)" + obj.Status);
			}
			if (ModelState.IsValid)
			{
				_ = _db.Tugases.Update(obj);
				_ = _db.SaveChanges();
				TempData["success"] = "Success Update";
				return RedirectToAction("Index");
			}

			return View(obj);
		}

		// GET
		public IActionResult Delete(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			var tugasFromDb = _db.Tugases.Find(id);

			if (tugasFromDb == null)
			{
				return NotFound();
			}
			return View(tugasFromDb);
		}

		// POST
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult DeletePOST(int? id)
		{

			var obj = _db.Tugases.Find(id);
			if (obj == null)
			{
				return NotFound();
			}

			_ = _db.Tugases.Remove(obj);
			_ = _db.SaveChanges();
			TempData["success"] = "Success Delete";
			return RedirectToAction("Index");


		}



	}
}
