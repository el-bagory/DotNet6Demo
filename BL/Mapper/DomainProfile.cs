using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;   
using AutoMapper;
using Demo.Data.Entities;
using Demo.Models.ApplicationUser;
using Demo.Models.Department;
using Demo.Models.Employee;
using Demo.Models.Project;
using Demo.BL.Repository; 
using Demo.BL.Interface;


namespace Demo.BL.Mapper
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Department, DepartmentVM>();
            CreateMap<DepartmentVM, Department>();

            // CreateMap<ApplicationUser, ApplicationUserVM>();
            // CreateMap<ApplicationUserVM, ApplicationUser>();

            CreateMap<Project, ProjectVM>();
            CreateMap<ProjectVM, Project>();

            CreateMap<ApplicationUser, EmployeeVM>();
            CreateMap<EmployeeVM, ApplicationUser>();

        }
    }
}