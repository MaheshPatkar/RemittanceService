using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Remittance_Provider.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IConfiguration _configuration { get; }
        public UserController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpGet("{user}")]
        public IActionResult GetAuthToken(string user)
        {
            try
            {
                var token = CommonHelper.GenerateJWTToken(user, _configuration);
                return Ok(token);
            }
            catch
            {
                return StatusCode(500);
            }

        }
    }
}
