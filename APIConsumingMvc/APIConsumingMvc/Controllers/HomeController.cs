using APIConsumingMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace APIConsumingMvc.Controllers
{
    public class HomeController : Controller
    {

        private string baseUrl = "https://localhost:7094/";
       

        public async Task<ActionResult> Index()
        {
            List<Student> students = new List<Student>();

            using(var client =  new HttpClient())
            {
                client.BaseAddress =  new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await client.GetAsync("api/StudentAPI");
                if (res.IsSuccessStatusCode)
                {
                    var std =  res.Content.ReadAsStringAsync().Result;

                    students = JsonConvert.DeserializeObject<List<Student>>(std);

                }
                return View(students);
            }

         
        }

        [HttpGet]
        public async Task<ActionResult> AddUser()
        {
            return View();

        }

        [HttpPost]
        public async Task<ActionResult> AddUser(Student std)
        {
            Student s = new Student();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                StringContent content = new StringContent(JsonConvert.SerializeObject(std), Encoding.UTF8, "application/json");

                using (var response = await client.PostAsync("api/StudentAPI", content)) 
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    s = JsonConvert.DeserializeObject<Student>(apiResponse);
                }
            }


            return RedirectToAction("Index");

        }



        public async Task<ActionResult> Edit(int id)
        {
            Student s = new Student();
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add( new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/StudentAPI/Get" + id);
                if (response.IsSuccessStatusCode)
                {
                    var resConvt =  response.Content.ReadAsStringAsync().Result;
                    s = JsonConvert.DeserializeObject<Student>(resConvt);


                }

                return View(s);
            }

        }


        [HttpPost]
        public async Task<ActionResult> Edit(Student std)
        {
            Student s = new Student();
            using (var client = new HttpClient())
            {

                StringContent res = new StringContent(JsonConvert.SerializeObject(std), Encoding.UTF8, "application/json");


            }

        }

    }
}