using Remittance_Provider.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Remittance_Provider.IDAL
{
    public interface IFeesDAL
    {
        Task<List<FeesReadDto>> GetFees(FeesParams feesParams);

    }
}
