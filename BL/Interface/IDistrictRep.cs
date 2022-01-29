using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Models.Address;

namespace Demo.BL.Interface
{
    public interface IDistrictRep
    {
        IQueryable<DistrictVM> Get();
        
        DistrictVM GetDistrictById(int Id);
       

    }
}