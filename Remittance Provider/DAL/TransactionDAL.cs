using AutoMapper;
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
        private IMapper _mapper { get; set; }
        public TransactionDAL(RemittanceContext remittanceContext, IMapper mapper)
        {
            dbContext = remittanceContext;
            _mapper = mapper;
        }

        /// <summary>
        /// Save the Transaction in the database
        /// </summary>
        /// <param name="transactionParams"></param>
        /// <returns></returns>
        public async Task<TransactionResponse> SubmitTransactionAsync(TransactionParams transactionParams)
        {
            try
            {
                Transactions transaction = _mapper.Map<Transactions>(transactionParams);

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
                transaction.Id = Guid.NewGuid();

                var response = await dbContext.Transactions.AddAsync(transaction);
                await dbContext.SaveChangesAsync();

                TransactionResponse transactionResponse = new TransactionResponse
                {
                    transactionId = response.Entity.Id,
                    responseStatus = transaction.Status
                };
                return transactionResponse;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Fetches the Transaction on basis of the provided TransactionId
        /// </summary>
        /// <param name="transactionId"></param>
        /// <returns></returns>
        public async Task<TransactionReadResponse> GetTransactionAsync(string transactionId)
        {
            try
            {

                Guid transactionIdGuid;
                Guid.TryParse(transactionId, out transactionIdGuid);

                int? status;
                //Check if the provided i/p is a valid GUID, in case of a valid guid fetch match it against the Id else match it aganst the TransactionNumber - Used to identifiy if the i/p is TransactionNumber or TransactionIdGuid
                if (transactionIdGuid == Guid.Empty)
                {
                    var transaction = await dbContext.Transactions.FirstOrDefaultAsync(x => x.TransactionNumber == transactionId);

                    if (transaction == null)
                        return new TransactionReadResponse { transactionId = Guid.Empty };

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
