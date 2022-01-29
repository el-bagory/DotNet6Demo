using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Models.Project;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Demo.BL.Repository; 
using System.Diagnostics;   
using Demo.BL.Interface;

using Demo.Data;


namespace Demo.Controllers
{
    public class ProjectController : Controller
    {
        
        private readonly IProjectRep project;
        private readonly IApplicationUserRep user;

        public ProjectController(IProjectRep project_, IApplicationUserRep user_)
        {
            user = user_;
            project = project_;
        }

        public IActionResult Index()
        {
            var data = project.GetAll();
            return View(data);
        }

        public IActionResult Create()
        {
            
            var u = user.GetAll().Where(a => a.Salary != null);
            ViewBag.EmployeeList = new SelectList(u, "Id", "FullName");

            return View();
        }

        [HttpPost]
        public IActionResult Create(ProjectVM prjct)
        {
            if(ModelState.IsValid)
            {
                project.Add(prjct);
                return RedirectToAction("Index", "Project");
            }
           
            return View(prjct);
        }


        public IActionResult Edit(int id)
        {
            var u = user.GetAll().Where(a => a.Salary != null);
            ViewBag.EmployeeList = new SelectList(u, "Id", "FullName");

            var data = project.GetById(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(ProjectVM dpt)
        {
           if(ModelState.IsValid)
                {
                    project.Edit(dpt);
                    return RedirectToAction("Index", "Project");
                }

            return View(dpt);
        }


        // public IActionResult Delete(int id)
        // {
        //     var data = project.GetById(id);
        //     return View(data);
        // }

        // [HttpPost]
        // [ActionName("Delete")]
        // public IActionResult ConfirmDelete(int id)
        // {

        //     project.Delete(id);
        //     return RedirectToAction("Index", "Project");
        // }
    }

}