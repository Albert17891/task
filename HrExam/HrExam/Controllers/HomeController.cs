using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HrExam.EmployeeModel;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System;
using System.Net.Http.Json;




namespace HrExam.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class HomeController : Controller
    {


        string Baseurl = "http://localhost:57389";
        HttpClient client = new HttpClient();


        public async Task<IActionResult> Index()
        {
            List<employee> EmpInfo = new List<employee>();

            client.BaseAddress = new Uri(Baseurl);



            HttpResponseMessage Res = await client.GetAsync("api/CRUDWeb");


            if (Res.IsSuccessStatusCode)
            {

                var EmpResponse = Res.Content.ReadAsStringAsync().Result;


                EmpInfo = JsonConvert.DeserializeObject<List<employee>>(EmpResponse);

            }

            return View(EmpInfo);

        }

        
        public async Task<IActionResult> Search(string search)
        {
            List<employee> EmpInfo = new List<employee>();

            client.BaseAddress = new Uri(Baseurl);



            HttpResponseMessage Res = await client.GetAsync("api/CRUDWeb/ser/" + search);


            if (Res.IsSuccessStatusCode)
            {

                var EmpResponse = Res.Content.ReadAsStringAsync().Result;


                EmpInfo = JsonConvert.DeserializeObject<List<employee>>(EmpResponse);

            }

            return View(EmpInfo);


        }




            public IActionResult Create()
        {
            return View("Create");
        }


        [HttpPost]
        public async Task<IActionResult> Create(employee emp)
        {
           

            client.BaseAddress = new Uri(Baseurl);

            HttpResponseMessage Res = await client.PostAsJsonAsync("api/CRUDWeb", emp);
            if (Res.IsSuccessStatusCode)
            {
               
                
               
                return RedirectToAction("Index");
            }
             
            
           

            return View("Create");
        }

        
        public ActionResult Edit(int id)
        {
           
            employee emp = new employee();

            client.BaseAddress = new Uri(Baseurl);

            var Res =  client.GetAsync("api/CRUDWeb/" + id).Result;

            
            
            if (Res.IsSuccessStatusCode)
            {
                 var EmpPutREsponse =Res.Content.ReadAsStringAsync().Result;
             
               emp = JsonConvert.DeserializeObject<employee>(EmpPutREsponse);         
                           


            }
            return View("Edit",emp);
        }



        [HttpPost]
        public  IActionResult Edit(employee emp)
        {
            

            client.BaseAddress = new Uri(Baseurl);

            var Res =  client.PutAsJsonAsync<employee>("api/CRUDWeb", emp);

            var Emp = Res.Result;

            if (Emp.IsSuccessStatusCode)
            {
               
                return RedirectToAction("Index");
            }
            return View(emp);
        }

        public IActionResult Delete(int id)
        {
            employee emp = new employee();


            client.BaseAddress = new Uri(Baseurl);

            HttpResponseMessage Res = client.GetAsync("api/CRUDWeb/" + id).Result;

            if (Res.IsSuccessStatusCode)
            {
                var result = Res.Content.ReadAsStringAsync().Result;
                emp = JsonConvert.DeserializeObject<employee>(result);
            }


            return View(emp);

        }


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
