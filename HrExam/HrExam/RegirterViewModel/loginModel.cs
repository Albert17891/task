using System;
using System.ComponentModel.DataAnnotations;

namespace HrExam.RegisterViewModel
{
    public class loginModel
    {
        [Required]
        [Display(Name = "სახელი")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "პაროლი")]
        public string Password { get; set; }

        [Display(Name = "დამიმახსოვრე?")]
        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}
