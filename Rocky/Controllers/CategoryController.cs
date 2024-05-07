using Microsoft.AspNetCore.Mvc;
using Rocky.Data;
using Rocky.Models;
using System.Security.Principal;

namespace Rocky.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDBContext _db;

        public CategoryController(ApplicationDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> objList = _db.Category;
            return View(objList);
        }

        //GET request for Create
        public IActionResult Create() 
        { 
            return View();
        }

        //POST request for Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _db.Category.Add(category);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

		//GET request for Edit
		public IActionResult Edit(int? id)
		{
            if (id==null || id==0)
            {
                return NotFound();
            }
            var obj = _db.Category.Find(id);
            if (obj==null) {
                return NotFound();
            }

            return View(obj);
		}

		//POST request for Edit
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(Category category)
		{
			if (ModelState.IsValid)
			{
				_db.Category.Update(category);
				_db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(category);
		}

		//GET request for Delete
		public IActionResult Delete(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			var obj = _db.Category.Find(id);
			if (obj == null)
			{
				return NotFound();
			}

			return View(obj);
		}

		//POST request for Delete
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult DeletePost(int? id)
		{
			var obj = _db.Category.Find(id);
			if (obj == null) { return NotFound();}
			_db.Category.Remove(obj);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
