using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace HostelManagementWebClient.Controllers
{
    public class HostelController : Controller
    {
        private readonly HttpClient client = null;
        private string HostelApiUrl = "";
        public HostelController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            HostelApiUrl = "https://localhost:44314/api/Hostels";
        }
        public async Task<IActionResult> Index()
        {
            HttpResponseMessage response = await client.GetAsync(HostelApiUrl);
            string strData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            IEnumerable<Hostel> hostels = JsonSerializer.Deserialize<IEnumerable<Hostel>>(strData, options);

            return View(hostels);
        }
    }
}
