using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Models.Department;
using Microsoft.AspNetCore.Mvc;
using Demo.BL.Repository; 
using System.Diagnostics;   
using Demo.BL.Interface;

using Demo.Data;


namespace Demo.Controllers
{
    public class DepartmentController : Controller
    {
        // private DbContainer db = new DbContainer();

        //Loosly Coupled
        private readonly IDepartmentRep department;

        //Tightly Coupled
        // private readonly DepartmentRep department;
        

        public DepartmentController(IDepartmentRep department_)
        {

            department = department_;
        }

        public IActionResult Index()
        {
            var data = department.GetAll();
            return View(data);
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(DepartmentVM dpt)
        {
            if(ModelState.IsValid)
            {
                department.Add(dpt);
                return RedirectToAction("Index", "Department");
            }
            return View(dpt);
        }


        public IActionResult Edit(int id)
        {
            var data = department.GetById(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(DepartmentVM dpt)
        {
           if(ModelState.IsValid)
                {
                    department.Edit(dpt);
                    return RedirectToAction("Index", "Department");
                }

            return View(dpt);
        }


        public IActionResult Delete(int id)
        {
            var data = department.GetById(id);
            return View(data);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {

            department.Delete(id);
            return RedirectToAction("Index", "Department");
        }
    }

}