// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Remittance_Provider.Models
{
    public partial class Bank
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string CountryCode { get; set; }

        public virtual Countries CountryCodeNavigation { get; set; }
    }
}
