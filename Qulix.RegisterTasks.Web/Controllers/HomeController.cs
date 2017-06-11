using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Qulix.RegisterTasks.Dal;
using Qulix.RegisterTasks.BL.Concrete;

namespace Qulix.RegisterTasks.Web.Controllers
{
    public class HomeController : Controller
    {


        private EmployeesRepository repository = new EmployeesRepository();

        public ActionResult Index()
        {
            return View(repository.GetAll());


        }

        public ActionResult Create()
        {


            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            if (ModelState.IsValid)
            {
                repository.Save(emp);
            }


            return RedirectToAction("Index", "Home");
        }



        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                repository.Delete(id);
            }


            return RedirectToAction("Index", "Home");
        }


        public ActionResult Update(int id)
        {


            return View(repository.GetById(id));
        }

        [HttpPost]
        public ActionResult Update(Employee emp)
        {
            if (ModelState.IsValid)
            {
                repository.Update(emp);
            }


            return RedirectToAction("Index", "Home");
        }







    }
}