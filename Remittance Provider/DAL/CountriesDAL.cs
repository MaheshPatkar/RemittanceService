﻿using Microsoft.EntityFrameworkCore;
using Remittance_Provider.Dtos;
using Remittance_Provider.IDAL;
using Remittance_Provider.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Remittance_Provider.DAL
{
    public class CountriesDAL : ICountriesDAL
    {
        public async Task<List<CountryReadDto>> GetCountriesAsync()
        {
            List<CountryReadDto> countries = new List<CountryReadDto>();
            try
            {
                using (var context = new RemittanceContext())
                {
                    var lstcountries = await context.Countries.ToListAsync();

                    foreach (var country in lstcountries)
                    {
                        countries.Add(
                            new CountryReadDto { code = country.Code, name = country.Name });
                    }
                }
                return countries;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}