using System;

namespace Remittance_Provider.Dtos
{
    public class TransactionResponse
    {
        public Guid transactionId { get; set; }

        public int? responseStatus { get; set; }

    }

    public class TransactionReadResponse
    {
        public Guid transactionId { get; set; }

        public string responseStatus { get; set; }

    }
}
