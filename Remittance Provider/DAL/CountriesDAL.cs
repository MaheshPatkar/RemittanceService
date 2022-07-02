using AutoMapper;
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
    public class CountriesDAL : ICountriesDAL
    {
        private RemittanceContext dbContext { get; set; }
        private IMapper _mapper;
        public CountriesDAL(RemittanceContext remittanceContext, IMapper mapper)
        {
            dbContext = remittanceContext;
            _mapper = mapper;
        }


        public async Task<List<CountryReadDto>> GetCountriesAsync()
        {
            try
            {
                var lstcountries = await dbContext.Countries.ToListAsync();
                IEnumerable<CountryReadDto> countries = _mapper.Map<IEnumerable<CountryReadDto>>(lstcountries);
                return countries.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> isValidCountryAsync(string countryCode)
        {
            try
            {
                bool doesCountryExists = await dbContext.Countries.AnyAsync(x => x.Code == countryCode);
                return doesCountryExists;
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
