using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Models.ApplicationUser;

namespace Demo.BL.Interface
{
    public interface IApplicationUserRep
    {
        IQueryable<ApplicationUserVM> GetAll();
        // void Add(ApplicationUserVM emp);
        ApplicationUserVM GetById(string Id);
        // void Edit(ApplicationUserVM emp);

        // void AddToEmployees(ApplicationUserVM user);
        // IQueryable<ApplicationUserVM> GetAllAsEmployee();

        // ApplicationUserVM GetAsEmployeeById(string id);
        void Delete(string id);

    }
}