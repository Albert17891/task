using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HrApi.Models;
using HrApi.Interfaces;
namespace HrApi.Controllers

    
{

    [Route("api/[controller]")]
    [ApiController]
    public class CRUDWebController : ControllerBase
    {

        private ICrudService service;


        private EmployeeContext context;

        public CRUDWebController(EmployeeContext stuContext,ICrudService crud)
        {
            context = stuContext;
            service = crud;
        }

        [HttpGet]
       // public  Task GetEmployees() => service.GetEmployees();

       public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await context.Employees.ToListAsync();
        }



        [HttpGet("{id}")]
        public IActionResult GetEmployee(int id)
        {

           
            var result=service.GetEmployee(id);

            if (!ModelState.IsValid)
            {
                BadRequest();
            }
            return Ok(result);   
        
           

        }
      
       [Route("ser/{search}")]
       [HttpGet]
        public async Task <IEnumerable<Employee>> Employees (string search)

        {

            var result = service.SearchEmployee(search);

            return await result;
        }
      
        [HttpPost]

        public IActionResult SaveEmployee(Employee employee)
        {
          if (!ModelState.IsValid)
            {

                return BadRequest();
            }
            else
            {
                service.SaveEmployee(employee);
                return Ok();
            }
            


        }

      

       


        [HttpPut]
        public IActionResult  Edit ( Employee emp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            service.EditEmployee(emp);          

            return Ok();
           

        }

        
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
             service.DeleteEmployee(id);     

            return Ok();

        }

    }
}
