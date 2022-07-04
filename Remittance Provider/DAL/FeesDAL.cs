using Microsoft.EntityFrameworkCore;
using Remittance_Provider.Dtos;
using Remittance_Provider.IDAL;
using Remittance_Provider.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Remittance_Provider.DAL
{
    public class FeesDAL : IFeesDAL
    {

        private RemittanceContext dbContext { get; set; }
        public FeesDAL(RemittanceContext remittanceContext)
        {
            dbContext = remittanceContext;
        }

        /// <summary>
        /// Provides fees based on the base rate for the conversion
        /// </summary>
        /// <param name="feesParams"></param>
        /// <returns></returns>
        public async Task<List<FeesReadDto>> GetFees(FeesParams feesParams)
        {
            try
            {
                List<FeesReadDto> feeslist = new List<FeesReadDto>();

                Fees fees = null;

                if (feesParams.from == "US")
                {
                    fees = await dbContext.Fees.FirstOrDefaultAsync(x => x.SourceCountry == feesParams.from && x.DestinationCountry == feesParams.to);
                }
                else if (feesParams.to == "US")
                {

                    fees = await dbContext.Fees.FirstOrDefaultAsync(x => x.SourceCountry == feesParams.to && x.DestinationCountry == feesParams.from);
                }

                if (fees == null)
                    return feeslist;

                //This logic has been written to provide the user the rate applied for transfer for a set range of amounts so that user gets an estimate as to what fees would apply for the amount he wishes to transfer

                for (int amount = 10; amount <= 100000; amount *= 10)
                {
                    feeslist.Add(new FeesReadDto
                    {
                        amount = amount.ToString(),
                        fee = (fees.BaseRate * amount).ToString()
                    });
                }
                return feeslist;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
