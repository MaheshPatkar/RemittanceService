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
    public class StatesDAL : IStatesDAL
    {
        private RemittanceContext dbContext { get; set; }
        private IMapper _mapper;
        public StatesDAL(RemittanceContext remittanceContext, IMapper mapper)
        {
            dbContext = remittanceContext;
            _mapper = mapper;
        }

        /// <summary>
        /// Returns all the States in the US available in the database
        /// </summary>
        /// <returns></returns>
        public async Task<List<StatesReadDto>> GetStatesAsync()
        {
            try
            {
                var lststates = await dbContext.States.ToListAsync();
                IEnumerable<StatesReadDto> states = _mapper.Map<IEnumerable<StatesReadDto>>(lststates);
                return states.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
