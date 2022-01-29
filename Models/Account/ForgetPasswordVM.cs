using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Demo.Models.Account
{
    public class ForgetPasswordVM
    {

        [Required(ErrorMessage = "Required Email")]
        [EmailAddress]
        public string? Email { get; set; }

        public string? PasswordResetLink { get; set; }
    }
}
