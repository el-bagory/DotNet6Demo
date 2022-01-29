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
    public class CountryRep : ICountryRep
    {
        private readonly ApplicationDbContext db;
        
        
        public CountryRep(ApplicationDbContext db_)
        {
            db = db_;
        }

        
        public IQueryable<CountryVM> Get()
        {
            var data = db.Countries.Select(a => new CountryVM { 
                Id = a.Id, 
                CountryName = a.CountryName
            });
            return data;
        }


        public CountryVM GetCountryById(int id)
        {
            var data  = db.Countries.Where(a => a.Id == id)
                                     .Select(a => new CountryVM{ 
                                         Id = a.Id, 
                                         CountryName = a.CountryName 
                                      })
                                     .FirstOrDefault();
            return data; 

        }

      
    }
}