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
                exchangeRateParams.from = string.IsNullOrWhiteSpace(exchangeRateParams.from)? "US": exchangeRateParams.from;


                    var exchangeRate = await dbContext.ExchangeRate.FirstOrDefaultAsync(x => x.SourceCountry == exchangeRateParams.from && x.DestinationCountry == exchangeRateParams.to);


                    if (exchangeRate != null)
                    {
                        ExchangeRateReadDto exchangeRateReadDto = new ExchangeRateReadDto
                        {
                            sourceCountry = exchangeRate.SourceCountry,
                            destinationCountry = exchangeRate.DestinationCountry,
                            exchangeRate = exchangeRate.ExchangeRate1,
                            exchangeRateToken = exchangeRate.ExchangeRateToken
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
