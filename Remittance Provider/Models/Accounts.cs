// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Remittance_Provider.Models
{
    public partial class Accounts
    {
        public int AccountNumber { get; set; }
        public string Name { get; set; }
        public string BankCode { get; set; }
        public string BeneficiaryName { get; set; }
    }
}
