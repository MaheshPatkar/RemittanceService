using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Remittance_Provider.Dtos;
using Remittance_Provider.IDAL;
using System;
using System.Threading.Tasks;

namespace Remittance_Provider.Controllers
{
    [Route("get-beneficiary-name")]
    [ApiController]
    [Authorize]
    public class BeneficiaryController : ControllerBase
    {
        private IBeneficiaryDAL _beneficiaryDAL;
        public BeneficiaryController(IBeneficiaryDAL beneficiaryDAL)
        {
            this._beneficiaryDAL = beneficiaryDAL;
        }

        [HttpPost]
        public async Task<ActionResult> Get(BeneficiaryParams beneficiaryParams)
        {
            try
            {
                string beneficiary = await _beneficiaryDAL.GetBeneficiaryAsync(beneficiaryParams);

                if (!String.IsNullOrWhiteSpace(beneficiary))
                {
                    return Ok(beneficiary);
                }
                return NotFound("No Records Found");
            }
            catch (Exception)
            {
                return StatusCode((int)ResponseStatus.INTERNAL_SERVER_ERROR, Constants.ERROR_MESSAGE);
            }
        }


    }
}
