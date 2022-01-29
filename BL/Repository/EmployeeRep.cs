using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Demo.BL.Interface;
using Demo.BL.Helper;
using Demo.Models.Employee;
using Demo.Data;
using Demo.Data.Entities;
using Demo.BL.Mapper;

namespace Demo.BL.Repository
{
    public class EmployeeRep : IEmployeeRep
    {
        private readonly ApplicationDbContext db;
        private readonly IMapper mapper;
        
        public EmployeeRep(ApplicationDbContext db_, IMapper mapper_)
        {
            db = db_;
            mapper = mapper_;
        }

        public void Add(EmployeeVM emp)
        {
            var data = db.Users.Find(emp.Id);
            data.Salary = emp.Salary;
            data.HireDate = emp.HireDate;
            // data.CvName = emp.CvName;
            // data.PhotoName = emp.PhotoName;
            data.DepartmentId = emp.DepartmentId;
            data.DistrictId = emp.DistrictId;
            data.ProjectId = emp.ProjectId;            


            // var data = mapper.Map<ApplicationUser>(emp);

            data.PhotoName = UploadFileHelper.SaveFile(emp.Photo, "Photos");
            data.CvName = UploadFileHelper.SaveFile(emp.Cv, "Docs");

            db.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            //  db.SaveChanges();
            var saved = false;
            while (!saved)
            {
                try
                {
                    db.SaveChanges();
                    saved = true;
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    foreach (var entry in ex.Entries)
                    {
                        if (entry.Entity is ApplicationUser)
                        {
                            var proposedValues = entry.CurrentValues;
                            var databaseValues = entry.GetDatabaseValues();

                            foreach (var property in proposedValues.Properties)
                            {
                                var proposedValue = proposedValues[property];
                                var databaseValue = databaseValues[property];

                                // TODO: decide which value should be written to database
                                // proposedValues[property] = <RowVersion>;
                            }

                            // Refresh original values to bypass next concurrency check
                            entry.OriginalValues.SetValues(databaseValues);
                        }
                        else
                        {
                            throw new NotSupportedException(
                                "Don't know how to handle concurrency conflicts for "
                                + entry.Metadata.Name);
                        }
                    }
                }
            }
           

           
        }
      
        public IQueryable<EmployeeVM> GetAll()
        {
            var data = db.Users.Where(a => a.Salary != null).Select(a => new EmployeeVM { 
                FullName = a.FullName,
                Email = a.Email,

                Id = a.Id,
                Salary = a.Salary,
                HireDate = a.HireDate,
                CvName = a.CvName,
                PhotoName = a.PhotoName,
                DistrictName = a.District.DistrictName, 
                DepartmentName = a.Department.DepartmentName,
                ProjectName = a.Project.ProjectName,
                IsActive = a.IsActive
  
            });
            return data;
        }

        public EmployeeVM GetById(string id)
        {
            var data  = db.Users.Where(a => a.Id == id)
                                     .Select(a => new EmployeeVM { 
                                        FullName = a.FullName,
                                        Id = a.Id,
                                        Salary = a.Salary,
                                        HireDate = a.HireDate,
                                        CvName = a.CvName,
                                        PhotoName = a.PhotoName,
                                        DistrictName = a.District.DistrictName, 
                                        DepartmentName = a.Department.DepartmentName,
                                        ProjectName = a.Project.ProjectName,
                                        IsActive = a.IsActive,
                                        Address = a.Address,
                                        Sex = a.Sex,
                                        UserName = a.UserName
                                        // Department = a.Department         
                                         } )
                                     .FirstOrDefault();
            return data; 

        }

        public void Edit(EmployeeVM emp)
        {
            var data = mapper.Map<ApplicationUser>(emp);
            db.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();

        }
        public void Delete(string id)
        {
            var DeletedOpject = db.Users.Find(id);
            db.Users.Remove(DeletedOpject);
            UploadFileHelper.RemoveFile("Photos/", DeletedOpject.PhotoName);
            db.SaveChanges();
        }
        
    }
}