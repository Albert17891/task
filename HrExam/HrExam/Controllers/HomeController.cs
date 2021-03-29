using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System;
using System.Net.Http.Json;
using HrExam.EmployeeModel;



namespace HrExam.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class HomeController : Controller
    {


        string Baseurl = "http://localhost:57389";
        HttpClient client = new HttpClient();

        //Connects by Server And gets All Employees Information
        public async Task<IActionResult> Index()
        {
            List<Employee> EmpInfo = new List<Employee>();

            client.BaseAddress = new Uri(Baseurl);

            HttpResponseMessage Res = await client.GetAsync("api/CRUDWeb");


            if (Res.IsSuccessStatusCode)
            {

                var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                EmpInfo = JsonConvert.DeserializeObject<List<Employee>>(EmpResponse);

            }

            return View(EmpInfo);

        }

        //Connects by Server And gets Employees using  Name and Last Name
        public async Task<IActionResult> Search(string search)
        {
            List<Employee> EmpInfo = new List<Employee>();

            client.BaseAddress = new Uri(Baseurl);



            HttpResponseMessage Res = await client.GetAsync("api/CRUDWeb/ser/" + search);


            if (Res.IsSuccessStatusCode)
            {

                var EmpResponse = Res.Content.ReadAsStringAsync().Result;


                EmpInfo = JsonConvert.DeserializeObject<List<Employee>>(EmpResponse);

            }

            return View(EmpInfo);


        }


        //Create new Employee

        public IActionResult Create()
        {
            return View("Create");
        }


        //Create new Employee
        [HttpPost]
        public async Task<IActionResult> Create(Employee emp)
        {
           

            client.BaseAddress = new Uri(Baseurl);

            HttpResponseMessage Res = await client.PostAsJsonAsync("api/CRUDWeb", emp);
            if (Res.IsSuccessStatusCode)
            {
               
                
               
                return RedirectToAction("Index");
            }
             
            
           

            return View("Create");
        }

        //Edit Information of Employee 
        public ActionResult Edit(int id)
        {
           
            Employee emp = new Employee();

            client.BaseAddress = new Uri(Baseurl);

            var Res =  client.GetAsync("api/CRUDWeb/" + id).Result;

            
            
            if (Res.IsSuccessStatusCode)
            {
                 var EmpPutREsponse =Res.Content.ReadAsStringAsync().Result;
             
               emp = JsonConvert.DeserializeObject<Employee>(EmpPutREsponse);         
                           


            }
            return View("Edit",emp);
        }


        //Edit Information of Employee
        [HttpPost]
        public  IActionResult Edit(Employee emp)
        {
            

            client.BaseAddress = new Uri(Baseurl);

            var Res =  client.PutAsJsonAsync<Employee>("api/CRUDWeb", emp);

            var Emp = Res.Result;

            if (Emp.IsSuccessStatusCode)
            {
               
                return RedirectToAction("Index");
            }
            return View(emp);
        }


        //Delete Employee
        public IActionResult Delete(int id)
        {
            Employee emp = new Employee();


            client.BaseAddress = new Uri(Baseurl);

            HttpResponseMessage Res = client.GetAsync("api/CRUDWeb/" + id).Result;

            if (Res.IsSuccessStatusCode)
            {
                var result = Res.Content.ReadAsStringAsync().Result;
                emp = JsonConvert.DeserializeObject<Employee>(result);
            }


            return View(emp);

        }

        //Delete Employee
        [HttpPost]
        public IActionResult Deletet(int id)
        {


            client.BaseAddress = new Uri(Baseurl);

            var Res = client.DeleteAsync("api/CRUDWeb/" + id);
            Res.Wait();

            var Emp = Res.Result;

            if (Emp.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
