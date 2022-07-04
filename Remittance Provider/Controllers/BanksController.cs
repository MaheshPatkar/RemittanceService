using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Remittance_Provider.IDAL;
using System.Linq;
using System.Threading.Tasks;

namespace Remittance_Provider.Controllers
{
    [Route("get-bank-list")]
    [ApiController]
    [Authorize]
    public class BanksController : ControllerBase
    {
        private IBankDAL _bankDAL;
        public BanksController(IBankDAL bankDAL)
        {
            _bankDAL = bankDAL;
        }

        [HttpGet("{country}")]
        public async Task<IActionResult> Get(string country)
        {
            try
            {
                var banks = await _bankDAL.GetBanksByCountryCodeAsync(country);
                if (banks.Any())
                {
                    return Ok(banks);
                }
                return NotFound("No Records Found");
            }
            catch
            {
                return StatusCode((int)ResponseStatus.INTERNAL_SERVER_ERROR, Constants.ERROR_MESSAGE);
            }
        }

    }
}
