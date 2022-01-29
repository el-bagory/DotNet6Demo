using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics; 
using Demo.BL.Interface;
using Demo.Models.ApplicationUser;
using Demo.Models.Employee;
using Demo.BL.Repository; 
using Demo.Data;


namespace Demo.Controllers
{
    public class EmployeeController : Controller
    {
        // private DbContainer db = new DbContainer();

        //Loosly Coupled
        private readonly IEmployeeRep employee;
        private readonly IApplicationUserRep user;
        private readonly IDepartmentRep department;
        private readonly ICountryRep country;
        private readonly ICityRep city;
        private readonly IDistrictRep district;
        private readonly IProjectRep project;
        


        public EmployeeController(
            IEmployeeRep employee_,
            IApplicationUserRep user_, 
            IDepartmentRep department_,
            ICountryRep country_,
            ICityRep city_,
            IDistrictRep district_,
            IProjectRep project_
            )
        {
            employee = employee_;
            user = user_;
            department = department_;
            country = country_;
            city = city_;
            district = district_;
            project = project_;
        }

        public IActionResult Index()
        {
            var data = employee.GetAll();
            return View(data);
        }

        public IActionResult Create(string id)
        {
            var emp = employee.GetById(id);

            var viewEmp = employee.GetAll();
            ViewBag.EmployeeList = new SelectList(viewEmp,  "FullName");

            var dpt = department.GetAll();
            ViewBag.DepartmentList = new SelectList(dpt, "Id", "DepartmentName");

            var prjt = project.GetAll();
            ViewBag.ProjectList = new SelectList(prjt, "Id", "Name");

            var cntry = country.Get();
            ViewBag.CountryList = new SelectList(cntry, "Id", "CountryName");

            return View(emp);
        }

        [HttpPost]
        public IActionResult Create(EmployeeVM emp)
        {
          
                if (ModelState.IsValid)
                {
                    employee.Add(emp);
                    return RedirectToAction("Index", "Employee");
                }

                var data = department.GetAll();

                ViewBag.DepartmentList = new SelectList(data, "Id", "DepartmentName");
                return RedirectToAction("Index", "Employee");

        
        }


        public IActionResult Edit(string id)
        {
            var emp = employee.GetById(id);

            var viewEmp = employee.GetAll();
            ViewBag.EmployeeList = new SelectList(viewEmp,  "FullName");

            var dpt = department.GetAll();
            ViewBag.DepartmentList = new SelectList(dpt, "Id", "DepartmentName");

            var prjt = project.GetAll();
            ViewBag.ProjectList = new SelectList(prjt, "Id", "Name");

            var cntry = country.Get();
            ViewBag.CountryList = new SelectList(cntry, "Id", "CountryName");

            return View(emp);
        }

        [HttpPost]
        public IActionResult Edit(EmployeeVM emp)
        {
            
        
            if (ModelState.IsValid)
            {
                employee.Add(emp);
                return RedirectToAction("Index", "Employee");
            }

            var data = department.GetAll();

            ViewBag.DepartmentList = new SelectList(data, "Id", "DepartmentName");
            return RedirectToAction("Index", "Employee");

           
        }

        

        public IActionResult Delete(string id)
        {
            var data = employee.GetById(id);

            return View(data);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(string id)
        {
           

            employee.Delete(id);
            return RedirectToAction("Index", "user");
                
        }










     // ------------------ Ajax Call -------------------------------

        [HttpPost]
        public JsonResult GetCityDataByCountryId(int CntryID)
        {
            var data = city.Get().Where(a => a.CountryId == CntryID);
            return Json(data);
        }

       [HttpPost]
        public JsonResult GetDistrictDataByCityId(int cityId)
        {
            var data = district.Get().Where(a => a.CityId == cityId);
            return Json(data);
        }


    }

}