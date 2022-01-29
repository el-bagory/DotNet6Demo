using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Demo.BL.Interface;
using Demo.Models.Department;
using Demo.Data;
using Demo.Data.Entities;
using Demo.BL.Mapper;


namespace Demo.BL.Repository
{
    public class DepartmentRep : IDepartmentRep
     {
        private readonly ApplicationDbContext db;
        private readonly IMapper mapper;
        
        public DepartmentRep(ApplicationDbContext db_, IMapper mapper_)
        {
            db = db_;
            mapper = mapper_;
        }

        
        public IQueryable<DepartmentVM> GetAll()
        {
            var data = db.Departments.Select(a => new DepartmentVM { 

                    Id = a.Id, 
                    DepartmentName = a.DepartmentName, 
                    DepartmentCode = a.DepartmentCode 

            } );
            return data;
        }

        public void Add(DepartmentVM dpt)
        {
            var data = mapper.Map<Department>(dpt);

            db.Departments.Add(data);
            db.SaveChanges();
        }

        public DepartmentVM GetById(int id)
        {
            var data  = db.Departments.Where(a => a.Id == id)
                                     .Select(a => new DepartmentVM{ Id = a.Id, 
                                     DepartmentName = a.DepartmentName, 
                                     DepartmentCode = a.DepartmentCode 
                                     })
                                     .FirstOrDefault();
            return data; 

        }

        public void Edit(DepartmentVM dpt)
        {
            var data = mapper.Map<Department>(dpt);
            db.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();

        }
        public void Delete(int id)
        {
            var DeletedOpject = db.Departments.Find(id);
            db.Departments.Remove(DeletedOpject);
            db.SaveChanges();
        }
        
    }
}