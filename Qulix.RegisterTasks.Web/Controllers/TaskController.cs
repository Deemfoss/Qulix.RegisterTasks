using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Qulix.RegisterTasks.Dal;
using Qulix.RegisterTasks.BL.Concrete;
namespace Qulix.RegisterTasks.Web.Controllers
{
    public class TaskController : Controller
    {
        private TasksRepository repository = new TasksRepository();
        private EmployeesRepository repemp = new EmployeesRepository();
        public ActionResult Index()
        {


            return View(repository.GetAll());
        }

        public ActionResult Create()
        {


            ViewBag.Status =   new SelectList(
       new List<SelectListItem>
       {
            new SelectListItem {Text = "Not Started", Value = "Not Started"},
            new SelectListItem {Text = "Delayed", Value = "Delayed"},
            new SelectListItem {Text = "Completed", Value = "Completed"},
            new SelectListItem {Text = "In the Process", Value = "In the Process"},

       }, "Value", "Text");
            
            ViewBag.Emp = new SelectList(repemp.GetAll(), "Id", "Last_name");

            return View();
        }

        [HttpPost]
        public ActionResult Create(Task task)
        {
            if (ModelState.IsValid)
            {
                repository.Save(task);
            }


            return RedirectToAction("Index", "Task");
        }



        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                repository.Delete(id);
            }


            return RedirectToAction("Index", "Task");
        }


        public ActionResult Update(int id)
        {
            ViewBag.Emp = new SelectList(repemp.GetAll(), "Id", "Last_name");

            ViewBag.Status = new SelectList(
       new List<SelectListItem>
       {
            new SelectListItem {Text = "Not Started", Value = "Not Started"},
            new SelectListItem {Text = "Delayed", Value = "Delayed"},
            new SelectListItem {Text = "Completed", Value = "Completed"},
            new SelectListItem {Text = "In the Process", Value = "In the Process"},

       }, "Value", "Text");


            return View(repository.GetById(id));
        }

        [HttpPost]
        public ActionResult Update(Task task)
        {
            if (ModelState.IsValid)
            {
                repository.Update(task);
            }


            return RedirectToAction("Index", "Task");
        }



    }
}