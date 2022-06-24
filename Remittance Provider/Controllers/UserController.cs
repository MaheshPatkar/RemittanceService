using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Remittance_Provider.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet("{user}")]
        public IActionResult GetAuthToken(string user)
        {
            try
            {
                var token =  CommonHelper.GenerateJWTToken(user);
                return Ok(token);
            }
            catch
            {
                return StatusCode(500);
            }

        }
    }
}
