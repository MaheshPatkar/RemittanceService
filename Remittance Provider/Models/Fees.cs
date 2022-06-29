using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Remittance_Provider.Models
{
    public partial class Fees
    {
        public int Id { get; set; }
        public string SourceCountry { get; set; }
        public string DestinationCountry { get; set; }
        public decimal? BaseRate { get; set; }

        public virtual Countries DestinationCountryNavigation { get; set; }
        public virtual Countries SourceCountryNavigation { get; set; }
    }
}
