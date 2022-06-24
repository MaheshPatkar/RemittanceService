using Microsoft.EntityFrameworkCore;
using Remittance_Provider.Dtos;
using Remittance_Provider.IDAL;
using Remittance_Provider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Remittance_Provider.DAL
{
    public class FeesDAL : IFeesDAL
    {
        public async Task<List<FeesReadDto>> GetFees(FeesParams feesParams)
        {
            try
            {
                List<FeesReadDto> feeslist = new List<FeesReadDto>();
                using (var dbContext = new RemittanceContext())
                {
                    var fees = await dbContext.Fees.Where(x => x.SourceCountry == feesParams.from && x.DestinationCountry == feesParams.to).ToListAsync();

                    foreach (var fee in fees)
                    {
                        feeslist.Add(new FeesReadDto
                        {
                            amount = fee.Amount,
                            fee = fee.Rate * fee.Amount
                        });
                    }
                    return feeslist;
                }

                //return fees;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
