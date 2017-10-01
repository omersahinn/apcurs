using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace apcurs.Models
{
    public class AccountViewModel
    {

        public class ResetPasswordModel
        {
            [Required(ErrorMessage = "Sıfırlama Linki İçin Email Adresiniz Gerekli")]
            [Display(Name = "Email")]
            [EmailAddress(ErrorMessage = "Lütfen Geçerli Bir Eposta Adresi Giriniz.")]
            public string Email { get; set; }
        }




        //public class ExternalLoginConfirmationViewModel
        //{
        //    [Required]
        //    [Display(Name = "User name")]
        //    public string UserName { get; set; }
        //}

        //public class ManageUserViewModel
        //{
        //    [Required]
        //    [DataType(DataType.Password)]
        //    [Display(Name = "Current password")]
        //    public string OldPassword { get; set; }

        //    [Required]
        //    [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        //    [DataType(DataType.Password)]
        //    [Display(Name = "New password")]
        //    public string NewPassword { get; set; }

        //    [DataType(DataType.Password)]
        //    [Display(Name = "Confirm new password")]
        //    [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        //    public string ConfirmPassword { get; set; }
        //}

        //public class LoginViewModel
        //{
        //    [Required(ErrorMessage = "Bu Alanı Doldurmak Zorunlu")]
        //    [Display(Name = "Kullanıcı Adı")]
        //    public string UserName { get; set; }

        //    [Required(ErrorMessage = "Bu Alanı Doldurmak Zorunlu")]
        //    [DataType(DataType.Password)]
        //    [Display(Name = "Şifre")]
        //    public string Password { get; set; }

        //    [Display(Name = "Beni Hatırla?")]
        //    public bool RememberMe { get; set; }
        //}

        //public class RegisterViewModel
        //{
        //    [Required]
        //    [Display(Name = "User name")]
        //    public string NameSurname { get; set; }

        //    [Required]
        //    [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        //    [DataType(DataType.Password)]
        //    [Display(Name = "Password")]
        //    public string Password { get; set; }

        //    [Required]
        //    [EmailAddress]
        //    [Display(Name = "E-mail")]
        //    public string Email { get; set; }

        //}
    }
}