namespace Remittance_Provider.Dtos
{
    public class ExchangeRateReadDto
    {
        public string sourceCountry { get; set; }

        public string destinationCountry { get; set; }

        public decimal exchangeRate { get; set; }

        public int exchangeRateToken { get; set; }
    }
}
