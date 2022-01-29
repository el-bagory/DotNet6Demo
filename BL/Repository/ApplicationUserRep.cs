using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Demo.BL.Interface;
using Demo.BL.Helper;
using Demo.Models.ApplicationUser;
using Demo.Data;
using Demo.Data.Entities;
using Demo.BL.Mapper;


namespace Demo.BL.Repository
{
    public class ApplicationUserRep : IApplicationUserRep
    {
        private readonly ApplicationDbContext db;
        private readonly IMapper mapper;
        
        
        public ApplicationUserRep(ApplicationDbContext db_, IMapper mapper_ )
        {
            db = db_;
            mapper = mapper_;
        }
      
        public IQueryable<ApplicationUserVM> GetAll()
        {
            var data = db.Users.Select(a => new ApplicationUserVM { 
                Id = a.Id,
                FullName = a.FullName, 
                Sex = a.Sex,
                Address = a.Address, 
                Email = a.Email, 
                PhotoName = (a.PhotoName == null) ? a.Avatar : a.PhotoName,
                Salary = a.Salary
  
            });
            return data;
        }

       

        public ApplicationUserVM GetById(string id)
        {
            var data  = db.Users.Where(a => a.Id == id)
                                     .Select(a => new ApplicationUserVM { 
                                        Id = a.Id,
                                        FullName = a.FullName, 
                                        Sex = a.Sex,
                                        Address = a.Address, 
                                        Email = a.Email, 
                                        PhotoName = a.Avatar,
                                         } )
                                     .FirstOrDefault();
            return data; 

        }

        // public void Edit(ApplicationUserVM user)
        // {
        //     var data = mapper.Map<ApplicationUser>(user);
        //     db.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

        //     if(user.Photo) data.PhotoName = UploadFileHelper.SaveFile(user.Photo, "Photos");
        //     if(user.Cv) data.CvName = UploadFileHelper.SaveFile(emp.Cv, "Docs");

        //     db.SaveChanges();

        // }
        // public void AddToEmployees(ApplicationUserVM user)
        // {
        //     var data = mapper.Map<ApplicationUser>(user);
        //     db.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        //     db.SaveChanges();

        // }

        // public IQueryable<ApplicationUserVM> GetAllAsEmployee()
        // {
        //     var data = db.Users.Select(a => new ApplicationUserVM { 
        //         Id = a.Id,
        //         FullName = a.FullName, 
        //         Sex = a.Sex,
        //         Address = a.Address, 
        //         Email = a.Email, 
        //         PhotoName = a.Avatar,
        //         Salary = a.Salary,
        //         HireDate = a.HireDate,
        //         CvName = a.CvName,
        //         DistrictName = a.District.DistrictName, 
        //         DepartmentName = a.Department.DepartmentName,
        //         ProjectId = a.ProjectId,
        //         IsActive = a.IsActive
  
        //     });
        //     return data;
        // }

       

        // public ApplicationUserVM GetAsEmployeeById(string id)
        // {
        //     var data  = db.Users.Where(a => a.Id == id)
        //                              .Select(a => new ApplicationUserVM { 
        //                                 Id = a.Id,
        //                                 FullName = a.FullName, 
        //                                 Sex = a.Sex,
        //                                 Address = a.Address, 
        //                                 Email = a.Email, 
        //                                 PhotoName = a.Avatar,
        //                                 Salary = a.Salary,
        //                                 HireDate = a.HireDate,
        //                                 CvName = a.CvName,
        //                                 DistrictName = a.District.DistrictName, 
        //                                 DepartmentName = a.Department.DepartmentName,
        //                                 ProjectId = a.ProjectId,
        //                                 IsActive = a.IsActive
        //                                  } )
        //                              .FirstOrDefault();
        //     return data; 

        // }




        public void Delete(string id)
        {
            var DeletedOpject = db.Users.Find(id);

            db.Users.Remove(DeletedOpject);

            UploadFileHelper.RemoveFile("Photos/", DeletedOpject.PhotoName);

           
          
            db.SaveChanges();
        }
        
    }
}