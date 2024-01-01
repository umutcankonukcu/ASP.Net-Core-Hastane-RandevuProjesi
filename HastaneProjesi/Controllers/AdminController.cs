using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Data;
using System.Net.Http.Headers;

namespace HastaneProjesi.Controllers
{
    public class AdminController : Controller
    {
        string baseUrl = "https://localhost:44370/";
        private readonly HttpClient _client;

       
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            DataTable dt = new DataTable();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage getData = await client.GetAsync("Admin");

                if(getData.IsSuccessStatusCode)
                {
                    string result = getData.Content.ReadAsStringAsync().Result;
                    dt = JsonConvert.DeserializeObject<DataTable>(result);

                }
                else
                {
                    Console.WriteLine("Error Calling web API");
                }

                ViewData.Model = dt;
            }


            return View();
        }
    }
}
