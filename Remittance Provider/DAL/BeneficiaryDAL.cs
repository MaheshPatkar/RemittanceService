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
        private RemittanceContext dbContext { get; set; }
        public BeneficiaryDAL(RemittanceContext remittanceContext)
        {
            dbContext = remittanceContext;
        }

        /// <summary>
        /// Returns beneficiaryname based on accounNumber and bankCode
        /// </summary>
        /// <param name="beneficiaryParams"></param>
        /// <returns></returns>
        public async Task<string> GetBeneficiaryAsync(BeneficiaryParams beneficiaryParams)
        {
            try
            {
                var account = await dbContext.Accounts.FirstOrDefaultAsync(x => x.AccountNumber == beneficiaryParams.accountNumber && x.BankCode == beneficiaryParams.bankCode);

                if (account == null)
                    return string.Empty;

                return account.BeneficiaryName;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
