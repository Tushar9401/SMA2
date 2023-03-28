using SM.Core.Contracts;
using SM.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SM.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
     
         IRepository<Category> context;

        public CategoryController(IRepository<Category> Categorycontext)
        {
            context = Categorycontext;
        }

        public ActionResult Index()
        {
            List<Category> categories = context.Collection().ToList();
            return View(categories);
        }

        public ActionResult Create()
        {
            Category category = new Category();
            return View(category);
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }
            else
            {
                context.Insert(category);
                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string ID)
        {
            Category category = context.Find(ID);

            if (category == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(category);
            }
        }

        [HttpPost]
        public ActionResult Edit(Category category, string Id)
        {
            Category categoryToEdit = context.Find(Id);

            if (categoryToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(category);
                }

                categoryToEdit.CategoryName = category.CategoryName;

                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(string ID)
        {
            Category categoryToDelete = context.Find(ID);

            if (categoryToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(categoryToDelete);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string ID)
        {
            Category categoryToDelete = context.Find(ID);

            if (categoryToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(ID);
                context.Commit();

                return RedirectToAction("Index");
            }
        }
    }
}
  