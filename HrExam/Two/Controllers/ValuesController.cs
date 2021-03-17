using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Two.Models;

namespace Two.Controllers

    
{

    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private EmployeeContext context;

        public ValuesController(EmployeeContext stuContext)
        {
            context = stuContext;
        }

        [HttpGet]
        public async Task<IEnumerable<employee>> GetEmployees()
        {
            return await context.Employees.ToListAsync();
        }



        [HttpGet("{id}")]
        public IActionResult GetEmployee(int id)
        {

            var result = context.Employees.Where(x => x.Id == id).Select(e => new employee()
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

            if (!ModelState.IsValid)
            {
                BadRequest();
            }
            return Ok(result);   
        
           

        }
      
       [Route("ser/{search}")]
       [HttpGet]
        public async Task <IEnumerable<employee>> Employees (string search)

        {
            

            
            var result = context.Employees.Where(x => x.Name.Contains(search)|| x.SurName.Contains(search) || search ==null);

            return await result.ToListAsync();
        }
      
        [HttpPost]

        public async Task SaveEmployee(employee emp) 
        {
            

            var number = emp.number;

            var nump = context.Employees.Where(x => x.number == number).Select(x => x).FirstOrDefault();

          
           
            if (ModelState.IsValid)
            {
                if (nump!=null)
                {
                    BadRequest("hhh");

                }
                else {


                    await context.Employees.AddAsync(emp);
                    await context.SaveChangesAsync();
                }
            }
           
        }

       


        [HttpPut]
        public IActionResult  Edit ( employee emp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var number = emp.number;

            var nump = context.Employees.Where(x => x.Id !=emp.Id&&x.number==emp.number).FirstOrDefault();

            var update = context.Employees.Where(x => x.Id == emp.Id).FirstOrDefault<employee>();
            
                if (update != null)
                {
                    if (nump!=null)
                    {

                        BadRequest();
                    }
                    else
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
            
            else
            {
                NotFound();
            }
            

            return Ok();
           

        }

        
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var result = context.Employees.Where(s => s.Id == id).Select(s => s).FirstOrDefault();

            

            context.Entry(result).State =EntityState.Deleted;

           
             context.SaveChanges();

            return Ok();

        }

    }
}
