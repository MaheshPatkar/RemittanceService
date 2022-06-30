using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Remittance_Provider.Dtos;
using Remittance_Provider.IDAL;
using System;
using System.Threading.Tasks;

namespace Remittance_Provider.Controllers
{

    [ApiController]
    [Authorize]
    public class TransactionsController : ControllerBase
    {
        private ITransactionDAL _transactionDAL { get; set; }

        public TransactionsController(ITransactionDAL transactionDAL)
        {
            _transactionDAL = transactionDAL;
        }

        [Route("submit-transaction")]
        [HttpPost]
        public async Task<IActionResult> Post(TransactionParams transactionParams)
        {
            try
            {
                var transactionResponse = await _transactionDAL.SubmitTransactionAsync(transactionParams);

                if (transactionResponse.responseStatus == (int)ResponseStatus.CREATED)
                {
                    return StatusCode((int)ResponseStatus.CREATED, transactionResponse.transactionId);
                }
                return Ok(transactionResponse.transactionId);
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException ex)
            {
                if (ex.InnerException.Message.Contains("Violation of PRIMARY KEY constraint"))
                {
                    return BadRequest("Transaction number must be unique");
                }
                else throw;
            }
            catch (Exception)
            {
                return StatusCode((int)ResponseStatus.SERVICE_UNAVAILABLE, ResponseStatus.SERVICE_UNAVAILABLE.ToString());
            }
        }


        [Route("get-transaction-status/{transactionId}")]
        [HttpGet]
        public async Task<IActionResult> Get(string transactionId)
        {
            try
            {
                var transactionResponse = await _transactionDAL.GetTransactionAsync(transactionId);

                if (transactionResponse.transactionId != Guid.Empty)
                {
                    return Ok(transactionResponse);
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
