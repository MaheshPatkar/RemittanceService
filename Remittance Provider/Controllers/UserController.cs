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

        [HttpGet]
        public IActionResult GetAuthToken()
        {
            try
            {
                var token = CommonHelper.GenerateJWTToken(_configuration);
                return Ok(token);
            }
            catch
            {
                return StatusCode((int)ResponseStatus.INTERNAL_SERVER_ERROR, Constants.ERROR_MESSAGE);
            }

        }
    }
}
