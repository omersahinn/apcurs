using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace apcurs.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Bu Alanı Doldurmak Zorunlu")]
        [Display(Name = "Kullanıcı Adı veya EMail")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Bu Alanı Doldurmak Zorunlu")]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre")]
        public string Password { get; set; }

        //[Display(Name = "Beni Hatırla?")]
        //public bool RememberMe { get; set; }
    }
}