using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.BL.Interface;
using Demo.Models.Address;
using Demo.Data;
using Demo.Data.Entities;
using Demo.BL.Mapper;
using AutoMapper;


namespace Demo.BL.Repository
{
    public class DistrictRep : IDistrictRep 
    {
        private readonly ApplicationDbContext db;
        
        
        public DistrictRep(ApplicationDbContext db_)
        {
            db = db_;
        }

        
        public IQueryable<DistrictVM> Get()
        {
            var data = db.Districts.Select(a => new DistrictVM { 
                Id = a.Id, 
                DistrictName = a.DistrictName, 
                CityId = a.CityId

            });
            return data;
        }


        public DistrictVM GetDistrictById(int id)
        {
            var data  = db.Districts.Where(a => a.Id == id)
                                     .Select(a => new DistrictVM { 
                                         Id = a.Id, 
                                         DistrictName = a.DistrictName , 
                                         CityId = a.CityId
                                    }).FirstOrDefault();
            return data; 

        }

      
    }
}