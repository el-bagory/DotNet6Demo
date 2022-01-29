using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Demo.Models.Account
{
    public class ForgotPasswordConfirmation
    {
        public string? Token { get; set; }
    }
}
