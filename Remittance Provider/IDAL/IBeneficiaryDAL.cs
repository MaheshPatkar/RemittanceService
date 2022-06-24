using Remittance_Provider.Dtos;
using System.Threading.Tasks;

namespace Remittance_Provider.IDAL
{
    public interface IBeneficiaryDAL
    {
        Task<string> GetBeneficiaryAsync(BeneficiaryParams beneficiaryParams);

    }
}
