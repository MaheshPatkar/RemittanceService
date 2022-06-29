using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Remittance_Provider.IDAL;
using System.Linq;
using System.Threading.Tasks;

namespace Remittance_Provider.Controllers
{
    [Route("get-state-list")]
    [ApiController]
    [Authorize]
    public class StatesController : ControllerBase
    {
        public IStatesDAL _statesDAL;
        public StatesController(IStatesDAL statesDAL)
        {
            _statesDAL = statesDAL;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var states = await _statesDAL.GetStatesAsync();

                if (states.Any())
                {
                    return Ok(states);
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
