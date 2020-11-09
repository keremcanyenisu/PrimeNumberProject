using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PrimeNumberClient.Models;
using PrimeNumberClient.Options;

namespace PrimeNumberClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppSettings _appSettings;

        public HomeController(IOptions<AppSettings> options)
        {
            _appSettings = options.Value;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("getPrimeNumberFromApi")]
        public async Task<IActionResult> GetPrimeNumberFromApi(int index)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(_appSettings.ApiUrl + "primeNumber/getPrimeNumber/" + index);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                // Above three lines can be replaced with new helper method below
                // string responseBody = await client.GetStringAsync(uri);

                return new JsonResult(responseBody);
            }
            catch (HttpRequestException e)
            {
                throw e;
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
