using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Demo.Models.Address
{
    public class CityVM
    {
        public int Id { get; set; }

        public string? CityName { get; set; }

        public int CountryId { get; set; }

    }
}