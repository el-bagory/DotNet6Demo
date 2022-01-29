using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Models.Address;

namespace Demo.BL.Interface
{
    public interface ICountryRep
    {
        IQueryable<CountryVM> Get();
        
        CountryVM GetCountryById(int Id);
       

    }
}