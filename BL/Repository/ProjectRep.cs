using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Demo.BL.Interface;
using Demo.BL.Helper;
using Demo.Data;
using Demo.Data.Entities;
using Demo.BL.Mapper;
using Demo.Models.Project;

namespace Demo.BL.Repository
{
    public class ProjectRep : IProjectRep
    {  
        private readonly ApplicationDbContext db;
        private readonly IMapper mapper;
        
        public ProjectRep(ApplicationDbContext db_, IMapper mapper_)
        {
            db = db_;
            mapper = mapper_;
        }
      
        public IQueryable<ProjectVM> GetAll()
        {
            var data = db.Projects.Select(a => new ProjectVM{
                     Id = a.Id,
                     ProjectName = a.ProjectName,
                     ProjectDescription = a.ProjectDescription,
                     EstimatedBudget = a.EstimatedBudget,
                     TotalAmountSpent = a.TotalAmountSpent,
                     EstimatedProjectDuration = a.EstimatedProjectDuration,
                     ProjectStatus = a.ProjectStatus,
                     ProjectProgress = a.ProjectProgress,
                     LeaderId = a.Leader.Id,
            });

            return data;
        }
        public void Add(ProjectVM project)
        {
            var data = mapper.Map<Project>(project);
            db.Projects.Add(data);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var DeletedProject = db.Projects.Find(id);
            db.Projects.Remove(DeletedProject);
            db.SaveChanges();
        }

        public void Edit(ProjectVM project)
        {
                var data = mapper.Map<Project>(project);
                db.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
        }

      

        public ProjectVM GetById(int Id)
        {
             var data = db.Projects.Where( a=>a.Id == Id).Select(a => new ProjectVM{
                     Id = a.Id,
                     ProjectName = a.ProjectName,
                     ProjectDescription = a.ProjectDescription,
                     EstimatedBudget = a.EstimatedBudget,
                     TotalAmountSpent = a.TotalAmountSpent,
                     EstimatedProjectDuration = a.EstimatedProjectDuration,
                     ProjectStatus = a.ProjectStatus,
                     ProjectProgress = a.ProjectProgress,
                     LeaderId = a.Leader.Id,
            }).FirstOrDefault();

            return data;
        }

        public ProjectVM CheckLeader(string id)
        {
             ProjectVM proj  = db.Projects.Where(a => a.LeaderId == id)
                                     .Select(a => new ProjectVM{ ProjectName = a.ProjectName })
                                     .FirstOrDefault();
            return proj;
        }
    }
}