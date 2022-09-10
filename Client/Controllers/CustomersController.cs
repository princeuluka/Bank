using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Net.Http.Headers;


namespace Client.Controllers
{
    public class CustomersController : Controller
    {
        string baseUrl = "https://localhost:7137/";
        public async Task<IActionResult> Index()
        {
            DataTable dt = new DataTable();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage getdata = await client.GetAsync("api/CustomerData/AllCustomers");

                if (getdata.IsSuccessStatusCode)
                {
                    string results = getdata.Content.ReadAsStringAsync().Result;
                    dt = JsonConvert.DeserializeObject<DataTable>(results);
                }
                else
                {
                    Console.WriteLine("Error calling API");
                }
            }
            return View();
        }
    }
}
