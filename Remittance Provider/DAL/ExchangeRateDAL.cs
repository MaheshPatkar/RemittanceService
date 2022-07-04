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
        /// <summary>
        /// Returns the Exchange Rate
        /// </summary>
        /// <param name="exchangeRateParams"></param>
        /// <returns></returns>
        public async Task<ExchangeRateReadDto> GetExchangeRateAsync(ExchangeRateParams exchangeRateParams)
        {
            try
            {
                ExchangeRate exchangeRate = null;
                bool isreversed = false;

                //Handled all possible scenario in the code itself so that data redundancy is reduced
                //Based on the design we can either handle these in the code or keep redundant data in Database so that 
                //explicit logic like below is not required
                if (exchangeRateParams.from == exchangeRateParams.to)
                {
                    exchangeRate = new ExchangeRate { ExchangeRate1 = 1 };
                }
                else if (exchangeRateParams.from == "US")
                {
                    exchangeRate = await dbContext.ExchangeRate.FirstOrDefaultAsync(x => x.SourceCountry == exchangeRateParams.from && x.DestinationCountry == exchangeRateParams.to);
                }
                else if (exchangeRateParams.to == "US")
                {
                    isreversed = true;
                    exchangeRate = await dbContext.ExchangeRate.FirstOrDefaultAsync(x => x.SourceCountry == exchangeRateParams.to && x.DestinationCountry == exchangeRateParams.from);
                }
                else
                {
                    var sourceexchangeRate = await dbContext.ExchangeRate.FirstOrDefaultAsync(x => x.SourceCountry == "US" && x.DestinationCountry == exchangeRateParams.from);

                    var targetexchangeRate = await dbContext.ExchangeRate.FirstOrDefaultAsync(x => x.SourceCountry == "US" && x.DestinationCountry == exchangeRateParams.to);

                    if (sourceexchangeRate != null && targetexchangeRate != null)
                        exchangeRate = new ExchangeRate
                        { ExchangeRate1 = Math.Round((1 / sourceexchangeRate.ExchangeRate1) * targetexchangeRate.ExchangeRate1, 3) };
                }

                if (exchangeRate != null)
                {
                    ExchangeRateReadDto exchangeRateReadDto = new ExchangeRateReadDto
                    {
                        sourceCountry = exchangeRateParams.from,
                        destinationCountry = exchangeRateParams.to,
                        exchangeRate = isreversed ? Math.Round(1 / exchangeRate.ExchangeRate1, 3).ToString() : exchangeRate.ExchangeRate1.ToString(),
                        //Token can be stored by the client as a datetime field and based on a client specific time interval,client can use this token to identify whether it needs to refresh the exhangerate values by recalling the API.
                        exchangeRateToken = DateTime.UtcNow.ToString()
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
