using Microsoft.EntityFrameworkCore;
using Remittance_Provider.Dtos;
using Remittance_Provider.IDAL;
using Remittance_Provider.Models;
using System;
using System.Threading.Tasks;

namespace Remittance_Provider.DAL
{
    public class ExchangeRateDAL : IExchangeRateDAL
    {
        private RemittanceContext dbContext { get; set; }
        public ExchangeRateDAL(RemittanceContext remittanceContext)
        {
            dbContext = remittanceContext;
        }

        public async Task<ExchangeRateReadDto> GetExchangeRateAsync(ExchangeRateParams exchangeRateParams)
        {
            try
            {
                ExchangeRate exchangeRate = null;
                bool isreversed = false;

                if (exchangeRateParams.from == "US")
                {
                    exchangeRate = await dbContext.ExchangeRate.FirstOrDefaultAsync(x => x.SourceCountry == exchangeRateParams.from && x.DestinationCountry == exchangeRateParams.to);
                }
                else if (exchangeRateParams.to == "US")
                {
                    isreversed = true;
                    exchangeRate = await dbContext.ExchangeRate.FirstOrDefaultAsync(x => x.SourceCountry == exchangeRateParams.to && x.DestinationCountry == exchangeRateParams.from);
                }

                if (exchangeRate != null)
                {
                    ExchangeRateReadDto exchangeRateReadDto = new ExchangeRateReadDto
                    {
                        sourceCountry = exchangeRateParams.from,
                        destinationCountry = exchangeRateParams.to,
                        exchangeRate = isreversed ? Math.Round(1 / exchangeRate.ExchangeRate1, 3).ToString() : exchangeRate.ExchangeRate1.ToString(),
                        exchangeRateToken = Guid.NewGuid().ToString()
                    };
                    return exchangeRateReadDto;
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
