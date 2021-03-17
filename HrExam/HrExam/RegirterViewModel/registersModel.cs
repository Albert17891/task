using System;
using System.ComponentModel.DataAnnotations;


namespace HrExam.ViewModel
{
    public class registersModel
    {

        [Required(ErrorMessage =("Please Enter Id Numper"))]
        
        [Display(Name = "ID No")]
        [RegularExpression("^[0-9]{11}$",ErrorMessage=("Please Enter ID Numper"))]
        public long number { get; set; }
        [Required(ErrorMessage = "Please Enter User Name")]
        [Display(Name = "სახელი")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please Enter SurName")]
        [Display(Name = "გვარი")]
        public string SurName { get; set; }
        [Required(ErrorMessage = "Please Choose Gender")]
        [Display(Name = "სქესი")]
         public string Gender { get; set; }
        [Required(ErrorMessage = "Please Enter Date")]
        [DataType(DataType.Date)]
        [Display(Name = "დაბ. თარიღი")]
        public DateTime dateTime { get; set; }

        [Required(ErrorMessage = "Please Enter Email")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Enter Password")]
        [DataType(DataType.Password)]
        [Display(Name = "პაროლი")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please repeat Password")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Confirm Password do not match Password")]
        [Display(Name = "გამიმეორედ პაროლი")]
        public string ConfirmPassword { get; set; }

    }
}
