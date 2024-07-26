using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCWebAppDatabaseFirst.Controllers
{
    public class EmployeeController : Controller
    {
        TutorialsEntities _context = new TutorialsEntities();
        // GET: Employee
        public ActionResult Index()
        {
            
             var listofData = _context.EmployeeTables.ToList();
            return View(listofData);
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            var listofData = _context.EmployeeTables.Where(x => x.EmployeeID == id).FirstOrDefault();
            return View(listofData);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(EmployeeTable model)
        {
            _context.EmployeeTables.Add(model);
            _context.SaveChanges();
            ViewBag.Message = "Data Insert Successfully";
            return RedirectToAction("Index");
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            var listofData = _context.EmployeeTables.Where(x=>x.EmployeeID==id).FirstOrDefault();
            return View(listofData);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, EmployeeTable model)
        {
            try
            {
                // TODO: Add update logic here
                var listofData = _context.EmployeeTables.Where(x => x.EmployeeID == id).FirstOrDefault();
                listofData.EmployeeName = model.EmployeeName;
                listofData.EmployeeSalary = model.EmployeeSalary;
                listofData.EmployeeCity = model.EmployeeCity;
                _context.SaveChanges();


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            var listofData = _context.EmployeeTables.Where(x => x.EmployeeID == id).FirstOrDefault();
            return View(listofData);
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, EmployeeTable model)
        {
            try
            {
                // TODO: Add delete logic here
                 var listofData = _context.EmployeeTables.Where(x => x.EmployeeID == id).FirstOrDefault();
                _context.EmployeeTables.Remove(listofData);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
