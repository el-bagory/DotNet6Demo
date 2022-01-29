using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System.Diagnostics; 
using Demo.Data.Entities;
using Demo.Models.Account;
using Demo.BL.Interface;

namespace Demo.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly ILogger<AccountController> logger;
        private readonly IApplicationUserRep user;


        public AccountController(
            UserManager<ApplicationUser> userManager ,
            SignInManager<ApplicationUser> signInManager ,
            ILogger<AccountController> logger,
            IApplicationUserRep user
            )
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.logger = logger;
            this.user = user;
        }
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationVM Input)
        {
            if (ModelState.IsValid)
            {
                var avatars = new string[] { "avatar1.png", "avatar2.png", "avatar3.png", "avatar4.png" };
                var index = ( Input.Avatar ) == ""  ? int.Parse(Input.Avatar) : 0 ;
                if (index < 0 || index > avatars.Count() - 1)
                    index = 0;
                // var Sex_ =  bool.Parse(Input.Sex) ;
                var avatarName = avatars[index];
                var user = new ApplicationUser()
                { 
                    UserName = Input.Email, 
                    Email = Input.Email,
                    FullName = Input.FullName,
                    Address = Input.Address,
                    Avatar = avatarName,
                    PhotoName = avatarName,          
                    Sex = (Input.Sex == "1") ? true : false
                };

                var result = await userManager.CreateAsync(user, Input.Password);


                if (result.Succeeded)
                {
                    // return RedirectToAction("Login");
                    // var viewEmp = await user.GetAll();
                    // ViewBag.EmployeeList = new SelectList(viewEmp,  "FullName", "PhotoName");

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }


            }

            return View(Input);
        }



        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM Input)
        {
            if (ModelState.IsValid)
            {
              var result = await signInManager.PasswordSignInAsync(Input.Email, Input.Password, Input.RemomberMe, false);

                if (result.Succeeded)
                {
                    // var viewEmp = user.GetAll();
                    // ViewBag.EmployeeList = new SelectList(viewEmp,  "FullName", "PhotoName");
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // var viewEmp = user.GetAll();
                    // ViewBag.EmployeeList = new SelectList(viewEmp,  "FullName", "PhotoName");
                    return RedirectToAction("Index", "Home");
                    // ModelState.AddModelError("", "Invalid UserName Or Password");
                }
            }          
            return View(Input);
        }

        
        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
 
        public IActionResult ForgetPassword(string name)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordVM Input)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(Input.Email);
                if (user != null && (await userManager.IsEmailConfirmedAsync(user)))
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    // return View("ForgetPassword");
                

                    // For more information on how to enable account confirmation and password reset please 
                    // visit https://go.microsoft.com/fwlink/?LinkID=532713
                    var token = await userManager.GeneratePasswordResetTokenAsync(user);

                    // code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

                    var passwordResetLink = Url.Action( "ResetPassword", "Account",
                        new {  email = Input.Email, token = token }, Request.Scheme);
                    Input.PasswordResetLink = passwordResetLink;
                    return View("ForgotPasswordConfirmation");
                }

                return View("ForgotPasswordConfirmation");
            }

            return View(Input);
        }

        [HttpGet]
        public IActionResult ForgotPasswordConfirmation(string name)
        {
            return View();
        }

       

        // [HttpGet]
        // public async Task<IActionResult> ResetPasword(ResetPasswordVM Input)
        // {
        //     if (Input.Token == null)
        //     {
        //         return BadRequest("A code must be supplied for password reset.");
        //     }
            
        //     return View();
        // }
        

        // [HttpPost]
        // public async Task<IActionResult> ResetPasword(ResetPasswordVM Input)
        // {
        //     if(ModelState.IsValid)
        //     {
        //         var user = await userManager.FindByEmailAsync(Input.Email);
        //         if(user != null)
        //         {
        //             var result = await userManager.ResetPasswordAsync(user, Input.Token, Input.Password);
        //             if(result.Succeeded)
        //             {
        //                 return View("Login");
        //             }
        //             else 
        //             {
        //                 foreach (var error in result.Errors)
        //                 {
        //                     ModelState.AddModelError("", error.Description);
        //                 }
        //             }
        //             return View("ResetPasswordConfirmation");

        //         }

        //         return View(Input);
        //     }
        // }

    }
}