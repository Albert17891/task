using System;
using System.ComponentModel.DataAnnotations;

namespace Two.Models
{
      
    public class employee
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter Id numper")]
        [Display(Name = "ID No")]
        [RegularExpression("^[0-9]{11}$", ErrorMessage = ("შეიტანე პირადი ნომერი"))]
       
        public long number { get; set; }
        [Required(ErrorMessage = "Please Enter Name")]
        [Display(Name = "სახელი")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Enter SurName")]
        [Display(Name = "გვარი")]
        public string SurName { get; set; }
        [Required(ErrorMessage = "Please choose Gender")]
        [Display(Name = "სქესი")]

        public string Gender { get; set; }
        [Required(ErrorMessage = "Please Enter Date of Birth")]
        [DataType(DataType.Date)]
        [Display(Name = "დაბ.თარიღი")]
        public DateTime Bdate { get; set; }
        [Required(ErrorMessage = "Please Enter Position")]
        [Display(Name = "თანამდებობა")]
        public string position { get; set; }
        [Required(ErrorMessage = "Please Enter status ")]
        [Display(Name = "სტატუსი")]
        public string status { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "გათ. თარიღი")]
        public DateTime? timeoffwork { get; set; }
        [Required(ErrorMessage = "Please Enter Phone Numper")]
        [RegularExpression("^[0-9]{9}$", ErrorMessage = ("შეიტანე სწორი მობილური"))]
        public int Mphone { get; set; }
    }
}
