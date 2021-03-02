using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ConsumeWebApiDemo.Models;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace ConsumeWebApiDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient client = null;
        private string employeeApiUrl = "";


        public HomeController(ILogger<HomeController> logger,HttpClient client, IConfiguration config)
        {
            _logger = logger;
            this.client = client;
            employeeApiUrl = config.GetValue<string>("AppSettings:EmployeesApiUrl");
        }


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
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
