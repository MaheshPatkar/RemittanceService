namespace Remittance_Provider.Dtos
{
    public class ExchangeRateReadDto
    {
        public string sourceCountry { get; set; }

        public string destinationCountry { get; set; }

        public string exchangeRate { get; set; }

        public string exchangeRateToken { get; set; }
    }
}
