using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Remittance_Provider.Dtos;
using Remittance_Provider.IDAL;
using Remittance_Provider.Models;
using System;
using System.Threading.Tasks;

namespace Remittance_Provider.DAL
{
    public class TransactionDAL : ITransactionDAL
    {
        private RemittanceContext dbContext { get; set; }
        public TransactionDAL(RemittanceContext remittanceContext)
        {
            dbContext = remittanceContext;
        }
        public async Task<TransactionResponse> SubmitTransactionAsync(TransactionParams transactionParams)
        {
            try
            {

                Transactions transaction = new Transactions
                {
                    Id = Guid.NewGuid(),
                    FromAmount = transactionParams.FromAmount,
                    SenderAddress = transactionParams.SenderAddress,
                    ToBankAccountName = transactionParams.ToBankAccountName,
                    ToBankAccountNumber = transactionParams.ToBankAccountNumber,
                    DateOfBirth = transactionParams.DateOfBirth,
                    ExchangeRate = transactionParams.ExchangeRate,
                    Fees = transactionParams.Fees,
                    FromCurrency = transactionParams.FromCurrency,
                    SenderCity = transactionParams.SenderCity,
                    SenderCountry = transactionParams.SenderCountry,
                    SenderEmail = transactionParams.SenderEmail,
                    SenderFirstName = transactionParams.SenderFirstName,
                    SenderLastName = transactionParams.SenderLastName,
                    SenderPhone = transactionParams.SenderPhone,
                    SenderPostalCode = transactionParams.SenderPostalCode,
                    SendFromState = transactionParams.SendFromState,
                    ToBankCode = transactionParams.ToBankCode,
                    ToBankName = transactionParams.ToBankName,
                    ToCountry = transactionParams.ToCountry,
                    ToFirstName = transactionParams.ToFirstName,
                    ToLastName = transactionParams.ToLastName,
                    TransactionNumber = transactionParams.TransactionNumber,
                };

                //This is to randomly create transaction which completed or Pending
                Random random = new Random();
                int num = random.Next();

                if (num % 2 == 0)
                {
                    transaction.Status = (int)ResponseStatus.SUCCESS;
                }
                else
                {
                    transaction.Status = (int)ResponseStatus.CREATED;
                }

                var response = await dbContext.Transactions.AddAsync(transaction);
                await dbContext.SaveChangesAsync();

                TransactionResponse transactionResponse = new TransactionResponse
                {
                    transactionId = response.Entity.Id,
                    responseStatus = transaction.Status
                };
                return transactionResponse;
            }
            catch (Exception )
            {
                throw;
            }
        }

        public async Task<TransactionReadResponse> GetTransactionAsync(string transactionId)
        {
            try
            {

                Guid transactionIdGuid;
                Guid.TryParse(transactionId,out transactionIdGuid);

                int? status;
                if (transactionIdGuid == Guid.Empty)
                {

                    var transaction = await dbContext.Transactions.FirstOrDefaultAsync(x => x.TransactionNumber ==transactionId);
                    transactionIdGuid = transaction.Id;
                    status = transaction.Status;
                }
                else
                {
                    var transaction = await dbContext.Transactions.FirstOrDefaultAsync(x => x.Id == transactionIdGuid);
                    status = transaction.Status;
                }
                var response = new TransactionReadResponse
                {
                    transactionId = transactionIdGuid,
                    responseStatus = status == (int)ResponseStatus.SUCCESS ? Constants.COMPLETED : Constants.PENDING
                };
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
