using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApiWithClientFactory.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountryClient : Controller
    {
        private HttpClient _httpClient;

        public CountryClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        
        [HttpGet]
        public async Task<HttpResponseMessage> GetCountryInformation(string name)
        {
            var result = await _httpClient.GetAsync($"https://restcountries.eu/rest/v2/name/{name}");

            return result;
        }

        [HttpGet]
        [Route("apiinfo")]
        public  IActionResult GetApiInformation()
        {
            var info = new
            {
                Memory = Process.GetCurrentProcess().WorkingSet64 / 1024 / 1024 + "MB"
            };

            return Ok(info);
        }
    }
}
