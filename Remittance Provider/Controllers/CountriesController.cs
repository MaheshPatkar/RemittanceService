using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Remittance_Provider.IDAL;
using System.Linq;
using System.Threading.Tasks;

namespace Remittance_Provider.Controllers
{
    [Route("get-country-list")]
    [ApiController]
    [Authorize]
    public class CountriesController : ControllerBase
    {
        public ICountriesDAL _countriesDAL;
        public CountriesController(ICountriesDAL countriesDAL)
        {
            _countriesDAL = countriesDAL;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var countries = await _countriesDAL.GetCountriesAsync();

                if (countries.Any())
                {
                    return Ok(countries);
                }
                return NoContent();
            }
            catch
            {
                return StatusCode((int)ResponseStatus.SERVICE_UNAVAILABLE, ResponseStatus.SERVICE_UNAVAILABLE.ToString());
            }
        }


    }
}
