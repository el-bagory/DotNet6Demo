using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Models.Employee;

namespace Demo.BL.Interface
{
    public interface IEmployeeRep
     {
        void Add(EmployeeVM emp);
        
        IQueryable<EmployeeVM> GetAll();
        EmployeeVM GetById(string Id);
        void Edit(EmployeeVM emp);
        void Delete(string id);

    }
}