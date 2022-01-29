using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Models.Project;

namespace Demo.BL.Interface
{
    public interface IProjectRep
    {
        IQueryable<ProjectVM> GetAll();
        void Add(ProjectVM dpt);
        ProjectVM GetById(int Id);
        void Edit(ProjectVM dpt);
        void Delete(int id);
        ProjectVM CheckLeader(string id);

    }
}