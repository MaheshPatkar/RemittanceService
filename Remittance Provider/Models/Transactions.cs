using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Remittance_Provider.Models
{
    public partial class Transactions
    {
        public Guid Id { get; set; }
        public string SenderFirstName { get; set; }
        public string SenderLastName { get; set; }
        public string SenderEmail { get; set; }
        public string SenderPhone { get; set; }
        public string SenderAddress { get; set; }
        public string SenderCountry { get; set; }
        public string SenderCity { get; set; }
        public string SendFromState { get; set; }
        public string SenderPostalCode { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ToFirstName { get; set; }
        public string ToLastName { get; set; }
        public string ToCountry { get; set; }
        public string ToBankAccountName { get; set; }
        public string ToBankAccountNumber { get; set; }
        public string ToBankName { get; set; }
        public string ToBankCode { get; set; }
        public decimal FromAmount { get; set; }
        public decimal ExchangeRate { get; set; }
        public decimal Fees { get; set; }
        public string TransactionNumber { get; set; }
        public string FromCurrency { get; set; }
        public int? Status { get; set; }
    }
}
