using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
namespace HrExam.Models
{
    public class User:IdentityUser
    {
         
        public long number { get; set; }
        public string SurName { get; set; }

        public string Gender { get; set; }
        public DateTime dateTime { get; set; }
    }
}
                                                            