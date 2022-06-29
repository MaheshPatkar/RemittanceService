using AutoMapper;
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
        private IMapper _mapper;
        public BankDAL(RemittanceContext remittanceContext, IMapper mapper)
        {
            dbContext = remittanceContext;
            _mapper = mapper;
        }

        public async Task<List<BankReadDto>> GetBanksByCountryCodeAsync(string countryCode)
        {
            try
            {
                var banks = await dbContext.Bank.Where(x => x.CountryCode == countryCode).ToListAsync();
                IEnumerable<BankReadDto> bankReadDtos = _mapper.Map<IEnumerable<BankReadDto>>(banks);
                return bankReadDtos.ToList();
            }
            catch
            {
                throw;
            }
        }
    }
}
