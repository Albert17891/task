using System;
using System.ComponentModel.DataAnnotations;

namespace HrApi.Models
{
      
    public class Employee
    {
       
        public int Id { get; set; }
        
       
        public long number { get; set; }
       
        public string Name { get; set; }
      
        public string SurName { get; set; }
       

        public string Gender { get; set; }
       
        public DateTime Bdate { get; set; }
       
        public string position { get; set; }
       
        public string status { get; set; }

        public DateTime? timeoffwork { get; set; }
       
        public int Mphone { get; set; }
    }
}
