using AutoMapper;
using Remittance_Provider.Dtos;
using Remittance_Provider.Models;

namespace Remittance_Provider.Profiles
{
    public class RemittanceProfile : Profile
    {
        public RemittanceProfile()
        {
            //Source --> Target
            CreateMap<Bank, BankReadDto>();
            CreateMap<Countries, CountryReadDto>();
            CreateMap<ExchangeRate, ExchangeRateReadDto>();
            CreateMap<Fees,FeesReadDto>();
            CreateMap<States, StatesReadDto >();
        }
    }
}
