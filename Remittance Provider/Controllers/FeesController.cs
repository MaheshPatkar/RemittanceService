using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Remittance_Provider.Dtos;
using Remittance_Provider.IDAL;
using System.Linq;
using System.Threading.Tasks;

namespace Remittance_Provider.Controllers
{
    [Route("get-fees-list")]
    [ApiController]
    [Authorize]
    public class FeesController : ControllerBase
    {
        private IFeesDAL _feesDAL;
        public FeesController(IFeesDAL feesDAL)
        {
            _feesDAL = feesDAL;
        }

        [HttpPost]
        public async Task<IActionResult> Get(FeesParams feesParams)
        {
            try
            {
                var fees = await _feesDAL.GetFees(feesParams);

                if (fees.Any())
                {
                    return Ok(fees);
                }
                return NotFound("No Records Found");
            }
            catch
            {
                return StatusCode((int)ResponseStatus.SERVICE_UNAVAILABLE, ResponseStatus.SERVICE_UNAVAILABLE.ToString());
            }
        }

    }
}
