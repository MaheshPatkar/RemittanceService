using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Remittance_Provider.Dtos;
using Remittance_Provider.IDAL;
using System;
using System.Threading.Tasks;

namespace Remittance_Provider.Controllers
{
    [Route("get-exchange-rate")]
    [ApiController]
    [Authorize]
    public class ExchangeRateController : ControllerBase
    {
        private IExchangeRateDAL _exchangeRateDAL { get; set; }
        public ExchangeRateController(IExchangeRateDAL exchangeRateDAL)
        {
            _exchangeRateDAL = exchangeRateDAL;
        }

        [HttpPost]
        public async Task<ActionResult> Get(ExchangeRateParams exchangeRateParams)
        {
            try
            {
                ExchangeRateReadDto exchangeRate = await _exchangeRateDAL.GetExchangeRateAsync(exchangeRateParams);

                if (exchangeRate != null)
                {
                    return Ok(exchangeRate);
                }
                return NotFound("No Records Found");
            }
            catch (Exception)
            {
                return StatusCode((int)ResponseStatus.SERVICE_UNAVAILABLE, ResponseStatus.SERVICE_UNAVAILABLE.ToString());
            }

        }

    }
}
