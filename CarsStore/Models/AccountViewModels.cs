using CarsStore.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Web.Mvc;

namespace CarsStore.UI.Models
{

        public class ExternalLoginConfirmationViewModel
        {
            [Required]
            [Display(Name = "Email")]
            public string Email { get; set; }
        }

        public class ExternalLoginListViewModel
        {
            public string ReturnUrl { get; set; }
        }

        public class SendCodeViewModel
        {
            public string SelectedProvider { get; set; }
            public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
            public string ReturnUrl { get; set; }
            public bool RememberMe { get; set; }
        }

        public class VerifyCodeViewModel
        {
            [Required]
            public string Provider { get; set; }

            [Required]
            [Display(Name = "Code")]
            public string Code { get; set; }
            public string ReturnUrl { get; set; }

            [Display(Name = "Remember this browser?")]
            public bool RememberBrowser { get; set; }

            public bool RememberMe { get; set; }
        }

        public class ForgotViewModel
        {
            [Required]
            [Display(Name = "Email")]
            public string Email { get; set; }
        }

        public class LoginViewModel
        {
            [Required]
            [Display(Name = "Email")]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }

        public class UserViewModel
        {
            //[Required]
            //[EmailAddress]
            //[Display(Name = "Email")]
            //public string Email { get; set; }

            //[Required]
            //[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
            //[DataType(DataType.Password)]
            //[Display(Name = "Password")]
            //public string Password { get; set; }

            //[DataType(DataType.Password)]
            //[Display(Name = "Confirm password")]
            //[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            //public string ConfirmPassword { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public IEnumerable<SelectListItem> RoleList { get; set; }
            public string RoleName { get; set; }
            public string RoleId { get; set; }
            [DataType(DataType.Password)]
            public string Password { get; set; }
            [DataType(DataType.Password)]
            public string ConfirmedPassword { get; set; }
        }

        public class ResetPasswordViewModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            //[Display(Name = "Confirm password")]
            //[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            public string Code { get; set; }
        }
        public class ChangePasswordViewModel {
            public string Password { get; set; }
            public string ConfirmedPassword { get; set; }

        }

        public class ForgotPasswordViewModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }
        }
        public class LogInViewModel
        {
            public IdentityRole Role { get; set; }
            public ApplicationUser User { get; set; }
            public IEnumerable<SelectListItem> RoleList { get; set; }



            public string Password { get; set; }
            public string ConfirmPassword { get; set; }
            //[HiddenInput(DisplayValue = false)]
            //public string ReturnUrl { get; set; }

        }


    }

