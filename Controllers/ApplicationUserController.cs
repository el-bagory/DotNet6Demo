using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics; 
using Demo.BL.Interface;
using Demo.Models.ApplicationUser;
using Demo.BL.Repository; 
using Demo.Data;
using Demo.Models.Project;


namespace Demo.Controllers
{
    public class ApplicationUserController : Controller
    {
        // private DbContainer db = new DbContainer();

        //Loosly Coupled
        private readonly IApplicationUserRep user;
        private readonly IProjectRep project;
        private readonly ILogger<ApplicationUserController> logger;
        //Tightly Coupled
    

        public ApplicationUserController(
            IApplicationUserRep user_,
            IProjectRep project_, 
            ILogger<ApplicationUserController>  logger_)
        {
            user = user_;
            project = project_;
            logger = logger_;
        }

        public IActionResult Index()
        {
            var data = user.GetAll();
            return View(data);
        }

        // public IActionResult Create()
        // {
        //     var data = department.GetAll();
        //     ViewBag.DepartmentList = new SelectList(data, "Id", "DepartmentName");
        //     return View();
        // }

        // [HttpPost]
        // public IActionResult Create(ApplicationUserVM user_)
        // {
        //     try
        //     {
        //         if(ModelState.IsValid)
        //         {
        //             user.Add(user_);
        //             return RedirectToAction("Index", "user");
        //         }
        //         var data = department.GetAll();
        //         ViewBag.DepartmentList = new SelectList(data, "Id", "DepartmentName");
        //         return View(user_);                
        //     }
        //    
        // }


        // public IActionResult Edit(string id)
        // {
        //     var data = user.GetById(id);
        //     return View(data);
        // }

        // [HttpPost]
        // public IActionResult Edit(ApplicationUserVM user_)
        // {
        //     if(ModelState.IsValid)
        //     {
        //         user.Edit(user_);
        //         return RedirectToAction("Index", "user");
        //     }
        //     return View(user_);
        // }

        

        public IActionResult Delete(string id)
        {
            var data = user.GetById(id);

            return View(data);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(string id)
        {
            var proj  = project.CheckLeader(id);
            if(proj != null)
            {
                var Message = $"Employee is a Leader for Project {proj}";
                logger.LogError(Message);
                return RedirectToAction("Index", "ApplicationUser");
            }
            

            user.Delete(id);
            return RedirectToAction("Index", "ApplicationUser");
                
        }










      //------------------ Ajax Call -------------------------------

    //     [HttpPost]
    //     public JsonResult GetCityDataByCountryId(int CntryID)
    //     {
    //         var data = city.Get().Where(a => a.CountryId == CntryID);
    //         return Json(data);
    //     }

    //    [HttpPost]
    //     public JsonResult GetDistrictDataByCityId(int cityId)
    //     {
    //         var data = district.Get().Where(a => a.CityId == cityId);
    //         return Json(data);
    //     }













    }

}