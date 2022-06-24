using Remittance_Provider.Dtos;
using System.Threading.Tasks;

namespace Remittance_Provider.IDAL
{
    public interface IExchangeRateDAL
    {
        Task<ExchangeRateReadDto> GetExchangeRateAsync(ExchangeRateParams exchangeRate);
    }
}
