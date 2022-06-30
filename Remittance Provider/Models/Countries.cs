using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Remittance_Provider.Models
{
    public partial class Countries
    {
        public Countries()
        {
            Bank = new HashSet<Bank>();
            ExchangeRateDestinationCountryNavigation = new HashSet<ExchangeRate>();
            ExchangeRateSourceCountryNavigation = new HashSet<ExchangeRate>();
            FeesDestinationCountryNavigation = new HashSet<Fees>();
            FeesSourceCountryNavigation = new HashSet<Fees>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Bank> Bank { get; set; }
        public virtual ICollection<ExchangeRate> ExchangeRateDestinationCountryNavigation { get; set; }
        public virtual ICollection<ExchangeRate> ExchangeRateSourceCountryNavigation { get; set; }
        public virtual ICollection<Fees> FeesDestinationCountryNavigation { get; set; }
        public virtual ICollection<Fees> FeesSourceCountryNavigation { get; set; }
    }
}
