using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApiWithoutClientFactory.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountryClient : Controller
    {
        [HttpGet]
        public async Task<HttpResponseMessage> GetCountryInformation(string name)
        {
            HttpClient httpClient = new HttpClient();
            var result = await httpClient.GetAsync($"https://restcountries.eu/rest/v2/name/{name}");

            return result;
        }

        [HttpGet]
        [Route("apiinfo")]
        public IActionResult GetApiInformation()
        {
            var info = new
            {
                Memory = Process.GetCurrentProcess().WorkingSet64 / 1024 / 1024 + "MB"
            };

            return Ok(info);
        }
    }
}
