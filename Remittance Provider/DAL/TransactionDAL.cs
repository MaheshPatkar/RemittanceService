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
        public async Task<TransactionResponse> SubmitTransactionAsync(TransactionParams transactionParams)
        {
            try
            {
                using (var dbContext = new RemittanceContext())
                {
                    Transactions transaction = new Transactions
                    {
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
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<TransactionReadResponse> GetTransactionAsync(Guid transactionId)
        {
            try
            {
                using (var context = new RemittanceContext())
                {
                    var transaction = await context.Transactions.FirstOrDefaultAsync(x => x.Id == transactionId);

                    var response = new TransactionReadResponse
                    {
                        transactionId = transactionId,
                        responseStatus = transaction.Status == (int)ResponseStatus.CREATED ? "Pending" : "Completed"
                    };
                    return response;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
