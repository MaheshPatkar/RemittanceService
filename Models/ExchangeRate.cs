using System;

namespace Models
{
    public class ExchangeRate
    {
        public string sourceCountry { get; set; }

        public string destinationCountry { get; set; }

        public decimal exchangeRate { get; set; }

        public string exchangeRateToken { get; set; }

    }
}
