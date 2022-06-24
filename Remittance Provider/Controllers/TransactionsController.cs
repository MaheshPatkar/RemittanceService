using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Remittance_Provider.Dtos;
using Remittance_Provider.IDAL;
using System;
using System.Net;
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
                    return Created("", transactionResponse.transactionId);
                }
                else
                {
                    return Ok(transactionResponse.transactionId);
                }
            }
            catch
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [Route("get-transaction-status")]
        [HttpGet]
        public async Task<IActionResult> Get(Guid transactionId)
        {
            try
            {
                var transactionResponse = await _transactionDAL.GetTransactionAsync(transactionId);

                if (transactionResponse.transactionId != Guid.Empty)
                {
                    return Ok(transactionResponse);
                }

                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
