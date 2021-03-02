using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using ConsumeWebApiDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ConsumeWebApiDemo.Controllers
{
    public class EmployeeManagerController : Controller
    {
        private readonly HttpClient client = null;
        private string employeeApiUrl = "";


        public EmployeeManagerController(HttpClient client,IConfiguration config )
        {
            this.client = client;
            employeeApiUrl = config.GetValue<string>("AppSettings:EmployeesApiUrl");
        }
       //public async Task<IActionResult> Index()
       // {
       //     HttpResponseMessage response = await client.GetAsync(employeeApiUrl);
       //     string stringData = await response.Content.ReadAsStringAsync();


       //     var options = new JsonSerializerOptions
       //     {
       //         PropertyNameCaseInsensitive = true
       //     };
       //     List<Employee> data = JsonSerializer.Deserialize<List<Employee>>(stringData, options);
       //     return View(data);
       // }

        public async Task<IActionResult> Index() 
        {
            HttpResponseMessage response = await client.GetAsync(employeeApiUrl);
            string stringData = await response.Content.ReadAsStringAsync();


            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            List<Employee> data = JsonSerializer.Deserialize<List<Employee>>(stringData, options);
            return View(data);
        }

        public async Task<IActionResult> Details(int id)
        {
            HttpResponseMessage response = await client.GetAsync($"{employeeApiUrl}/{id}");
            string stringData = await response.Content.ReadAsStringAsync();


            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
           Employee data = JsonSerializer.Deserialize<Employee>(stringData, options);
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Employee model)
        {
          if(ModelState.IsValid)
            {
                string stringData = JsonSerializer.Serialize(model);

                var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(employeeApiUrl, contentData);
                if (response.IsSuccessStatusCode) {

                    ViewBag.Message = "Employee Inserted Sucessfully";

                }
                else
                {
                    ViewBag.Message = "Error While Calling the API";
                }

            }
            return View(model);
        }
    }
}
