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
        private ICountriesDAL _countriesDAL { get; set; }

        public TransactionsController(ITransactionDAL transactionDAL, ICountriesDAL countriesDAL)
        {
            _transactionDAL = transactionDAL;
            _countriesDAL = countriesDAL;
        }

        [Route("submit-transaction")]
        [HttpPost]
        public async Task<IActionResult> Post(TransactionParams transactionParams)
        {
            try
            {
                //custom validators
                if (!await _countriesDAL.isValidCountryAsync(transactionParams.SenderCountry))
                {
                    return BadRequest("Please provide a valid Sender Country");
                }

                if (!await _countriesDAL.isValidCountryAsync(transactionParams.ToCountry))
                {
                    return BadRequest("Please provide a valid Reciever Country");
                }
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
                return StatusCode((int)ResponseStatus.INTERNAL_SERVER_ERROR, Constants.ERROR_MESSAGE);
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
                return StatusCode((int)ResponseStatus.INTERNAL_SERVER_ERROR, Constants.ERROR_MESSAGE);
            }
        }
    }
}
