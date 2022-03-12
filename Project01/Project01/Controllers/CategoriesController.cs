using Project01.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Project01.Controllers
{
    public class CategoriesController : Controller
    {
        private static IList<Category> categories = new List<Category>()
        {
            new Category()
            {
                CategoryId = 1,
                Name = "Notebooks"
            },
            new Category()
            {
                CategoryId = 2,
                Name = "Monitores"
            },
            new Category()
            {
                CategoryId = 3,
                Name = "Impressoras"
            },
            new Category()
            {
                CategoryId = 4,
                Name = "Mouses"
            },
            new Category()
            {
                CategoryId = 5,
                Name = "Desktops"
            }
        };

        // GET: Categories
        public ActionResult Index()
        {
            return View(categories);
        }

        //GET: Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            categories.Add(category);
            category.CategoryId = categories.Select(m => m.CategoryId).Max() + 1;
            return RedirectToAction("Index");
        }

        public ActionResult Edit(long id)
        {
            return View(categories.Where(m => m.CategoryId == id).First());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category)
        {
            categories.Remove(categories.Where(
                            c => c.CategoryId == category.CategoryId)
                            .First());
            categories.Add(category);
            return RedirectToAction("Index");
        }
    }
}