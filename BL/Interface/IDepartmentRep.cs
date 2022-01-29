using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Models.Department;

namespace Demo.BL.Interface
{
    public interface IDepartmentRep
    {
        IQueryable<DepartmentVM> GetAll();
        void Add(DepartmentVM dpt);
        DepartmentVM GetById(int Id);
        void Edit(DepartmentVM dpt);
        void Delete(int id);

    }
}