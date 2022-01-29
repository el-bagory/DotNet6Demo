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
    public class CityRep : ICityRep
    {
        private readonly ApplicationDbContext db;
        
        
        public CityRep(ApplicationDbContext db_)
        {
            db = db_;
        }

        
        public IQueryable<CityVM> Get()
        {
            var data = db.Cities.Select(a => new CityVM { 
                Id = a.Id, 
                CityName = a.CityName, 
                CountryId = a.CountryId
            } );
            return data;
        }


        public CityVM GetECityById(int id)
        {
            var data  = db.Cities.Where(a => a.Id == id)
                                     .Select(a => new CityVM { 
                                        Id = a.Id, 
                                        CityName = a.CityName, 
                                        CountryId = a.CountryId
                                    })
                                     .FirstOrDefault();
            return data; 

        }

      
    }
}