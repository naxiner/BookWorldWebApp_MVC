using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
		public IActionResult Create(Category obj)
		{
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
				TempData["success"] = "Category successfully created!";
			    return RedirectToAction("Index");
            }
            return View();
		}

		public IActionResult Edit(int? id)
		{
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Category? category = _db.Categories.Find(id);
            if (category == null) 
            {
				return NotFound();
			}
			return View(category);
		}

		[HttpPost]
		public IActionResult Edit(Category obj)
		{
			if (ModelState.IsValid)
			{
				_db.Categories.Update(obj);
				_db.SaveChanges();
				TempData["success"] = "Category successfully updated!";
				return RedirectToAction("Index");
			}
			return View();
		}

		public IActionResult Delete(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}

			Category? category = _db.Categories.Find(id);
			if (category == null)
			{
				return NotFound();
			}
			return View(category);
		}

		[HttpPost, ActionName("Delete")]
		public IActionResult DeletePOST(int? id)
		{
			Category? category = _db.Categories.Find(id);
			if (category == null)
			{
				return NotFound();
			}

			_db.Remove(category);
			_db.SaveChanges();
			TempData["success"] = "Category successfully deleted!";
			return RedirectToAction("Index");
		}
	}
}
