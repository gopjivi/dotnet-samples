using MVCAppwithADO.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCAppwithADO.Models;

namespace MVCAppwithADO.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            CategoriesTable tab = new CategoriesTable();
            ModelState.Clear();
            return View(tab.GetCategories());
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CategoriesTable EmpRepo = new CategoriesTable();

                    if (EmpRepo.AddCategory(category))
                    {
                        ViewBag.Message = "Employee details added successfully";
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            CategoriesTable EmpRepo = new CategoriesTable();



            return View(EmpRepo.GetCategories().Find(Emp => Emp.ID == id));
           
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Category obj)
        {
            try
            {
                CategoriesTable EmpRepo = new CategoriesTable();

                EmpRepo.UpdateCategory(obj);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            CategoriesTable EmpRepo = new CategoriesTable();



            return View(EmpRepo.GetCategories().Find(Emp => Emp.ID == id));
        }

     
        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                CategoriesTable EmpRepo = new CategoriesTable();
                if (EmpRepo.DeleteCategory(id))
                {
                    ViewBag.AlertMsg = "Category details deleted successfully";

                }
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }
    }
}
