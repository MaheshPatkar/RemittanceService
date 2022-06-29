using Remittance_Provider.Dtos;
using System.Threading.Tasks;

namespace Remittance_Provider.IDAL
{
    public interface ITransactionDAL
    {

        Task<TransactionResponse> SubmitTransactionAsync(TransactionParams transactionParams);
        Task<TransactionReadResponse> GetTransactionAsync(string transactionId);

    }
}
