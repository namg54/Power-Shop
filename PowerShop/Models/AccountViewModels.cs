using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PowerShop.Models
{
   public class RegisterViewModel
    {
        [Required(ErrorMessage = " لطفاً {0} را وارد کنید")]
        [MaxLength(100)]
        [EmailAddress]
        [DisplayName("ایمیل")]
        [Remote("VerifyEmail", "Account")]
        public string Email { get; set; }
        [Required(ErrorMessage = " لطفاً {0} را وارد کنید")]
        [MaxLength(16)]
        [DataType(DataType.Password)]
        [DisplayName("گذرواژه")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,20}$", ErrorMessage = "کلمه عبور باید شامل حرف و عدد باشد")]
        public string Password { get; set; }
        [Required(ErrorMessage = " لطفاً {0} را وارد کنید")]
        [MaxLength(16)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [DisplayName("تکرار گذرواژه")]
        public string RePassword { get; set; }

    }

   public class LoginViewModel
   {
       [Required(ErrorMessage = " لطفاً {0} را وارد کنید")]
       [MaxLength(100)]
       [EmailAddress]
       [DisplayName("ایمیل")]
       public string Email { get; set; }

       [Required(ErrorMessage = " لطفاً {0} را وارد کنید")]
       [MaxLength(16)]
       [DataType(DataType.Password)]
       [DisplayName("گذرواژه")]
       public string Password { get; set; }


       [DisplayName("مرا بخاطر بسپار")]
        public bool  RememberMe { get; set; }

    }
}
