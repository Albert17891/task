using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using HrApi.Models;

namespace HrApi.Validators
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public  EmployeeValidator()
        {
            RuleFor(x => x.number.ToString())
                .NotEmpty().Matches("^[0-9]{11}$");
            RuleFor(x => x.Name)
                .NotEmpty();
            RuleFor(x => x.SurName)
                .NotEmpty();
            RuleFor(x => x.Gender)
                .NotEmpty();
            RuleFor(x => x.Bdate)
                .NotEmpty();
            RuleFor(x => x.position)
                .NotEmpty();
            RuleFor(x => x.status)
                .NotEmpty();
            RuleFor(x => x.Mphone)
                .NotEmpty();            
            

                           
         }
    }
}
