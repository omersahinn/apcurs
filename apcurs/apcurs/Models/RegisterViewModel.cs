
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace apcurs.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Bu Alanı Doldurmak Zorunlu")]
        [Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }


        [Required(ErrorMessage ="Bu Alanı Doldurmak Zorunlu")]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Bu Alanı Doldurmak Zorunlu")]
        [StringLength(50, ErrorMessage = "En az 6 karakterden oluşmalıdır", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

    }
}