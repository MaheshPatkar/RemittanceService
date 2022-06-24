using Microsoft.EntityFrameworkCore;
using Remittance_Provider.Dtos;
using Remittance_Provider.IDAL;
using Remittance_Provider.Models;
using System;
using System.Threading.Tasks;

namespace Remittance_Provider.DAL
{
    public class BeneficiaryDAL : IBeneficiaryDAL
    {
        public async Task<string> GetBeneficiaryAsync(BeneficiaryParams beneficiaryParams)
        {
            try
            {
                using (var dbContext = new RemittanceContext())
                {
                    var account = await dbContext.Accounts.FirstOrDefaultAsync(x => x.AccountNumber == beneficiaryParams.accountNumber && x.BankCode == beneficiaryParams.bankCode);

                    return account.BeneficiaryName;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
