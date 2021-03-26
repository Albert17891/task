using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HrApi.Models;
using HrApi.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HrApi.Service
{
    public class CrudService:ICrudService
    {
        public EmployeeContext context;

        public CrudService(EmployeeContext contextEmployee)
        {
            context = contextEmployee;
        }

        //Search Employee using id
        public  Employee GetEmployee(int id)
        {
            var result = context.Employees.Where(x => x.Id == id).Select(e => new Employee()
            {
                Id = e.Id,
                number = e.number,
                Name = e.Name,
                SurName = e.SurName,
                Gender = e.Gender,
                Bdate = e.Bdate,
                position = e.position,
                status = e.status,
                timeoffwork = e.timeoffwork,
                Mphone = e.Mphone
            }).FirstOrDefault();

            return  result;
        }

        //Search Employee
        public async Task<IEnumerable<Employee>> SearchEmployee(string search)
        {
            var result = context.Employees.Where(x => x.Name.Contains(search) || x.SurName.Contains(search) || search == null);
           
            return await result.ToListAsync();
        }


        //Create new Employee
       public  void SaveEmployee(Employee emp)
        {
            var number = emp.number;

            var nump = context.Employees.Where(x => x.number == number).Select(x => x).FirstOrDefault();

           
            if (nump == null)
            {
                 context.Employees.Add(emp);
                 context.SaveChanges();

            }
        }

        //Edit Employee

        public  void EditEmployee(Employee emp)
        {
            var number = emp.number;

            var nump = context.Employees.Where(x => x.Id != emp.Id && x.number == emp.number).FirstOrDefault();

            var update = context.Employees.Where(x => x.Id == emp.Id).FirstOrDefault<Employee>();

            if (update != null)
            {
                if (nump == null)
                {
                                     
                
                    update.Id = emp.Id;
                    update.number = emp.number;
                    update.Name = emp.Name;
                    update.SurName = emp.SurName;
                    update.Gender = emp.Gender;
                    update.Bdate = emp.Bdate;
                    update.position = emp.position;
                    update.status = emp.status;
                    update.timeoffwork = emp.timeoffwork;
                    update.Mphone = emp.Mphone;
                   context.SaveChanges();
                }
            }
            
        }

        //Delete Employee
        public  void DeleteEmployee(int id)
        {
            var result = context.Employees.Where(s => s.Id == id).Select(s => s).FirstOrDefault();

            context.Entry(result).State = EntityState.Deleted;

              context.SaveChanges();


        }
    }
}
