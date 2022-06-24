using Microsoft.EntityFrameworkCore;
using Remittance_Provider.Dtos;
using Remittance_Provider.IDAL;
using Remittance_Provider.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Remittance_Provider.DAL
{
    public class StatesDAL : IStatesDAL
    {

        private RemittanceContext dbContext { get; set; }
        public StatesDAL(RemittanceContext remittanceContext)
        {
            dbContext = remittanceContext;
        }
        public async Task<List<StatesReadDto>> GetStatesAsync()
        {
            List<StatesReadDto> states = new List<StatesReadDto>();
            try
            {
                    var lststates = await dbContext.States.ToListAsync();

                    foreach (var state in lststates)
                    {
                        states.Add(
                            new StatesReadDto { code = state.Code, name = state.Name });
                    }
                return states;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
