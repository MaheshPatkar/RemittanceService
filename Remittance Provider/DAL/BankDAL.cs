using Microsoft.EntityFrameworkCore;
using Remittance_Provider.Dtos;
using Remittance_Provider.IDAL;
using Remittance_Provider.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Remittance_Provider.DAL
{
    public class BankDAL : IBankDAL
    {

        private RemittanceContext dbContext { get; set; }
        public BankDAL(RemittanceContext remittanceContext)
        {
            dbContext = remittanceContext;
        }

        public async Task<List<BankReadDto>> GetBanksByCountryCodeAsync(string countryCode)
        {
            try
            {
                List<BankReadDto> bankReadDtos = new List<BankReadDto>();

                    var banks = await dbContext.Bank.Where(x => x.CountryCode == countryCode).ToListAsync();

                    foreach (var bank in banks)
                    {
                        bankReadDtos.Add(new BankReadDto { code = bank.Code, name = bank.Name });
                    }
                    return bankReadDtos;
            }
            catch
            {
                throw;
            }
        }
    }
}
