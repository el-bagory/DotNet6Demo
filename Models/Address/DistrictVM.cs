using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Demo.Models.Address
{
    public class DistrictVM
    {
        public int Id { get; set; }

        public string? DistrictName { get; set; }

        public int CityId { get; set; }

    }
}