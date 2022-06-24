using System;
using System.ComponentModel.DataAnnotations;

namespace Remittance_Provider.Dtos
{
    
    public class TransactionParams
    {
        [Required]
        public string SenderFirstName { get; set; }
        [Required]
        public string SenderLastName { get; set; }
        [Required]
        public string SenderEmail { get; set; }
        [Required]
        public string SenderPhone { get; set; }
        [Required]
        public string SenderAddress { get; set; }
        [Required]
        public string SenderCountry { get; set; }
        [Required] 
        public string SenderCity { get; set; }
        [Required] 
        public string SendFromState { get; set; }
        [Required] 
        public string SenderPostalCode { get; set; }
        [Required] 
        public DateTime DateOfBirth { get; set; }
        [Required] 
        public string ToFirstName { get; set; }
        [Required] 
        public string ToLastName { get; set; }
        [Required] 
        public string ToCountry { get; set; }
        [Required] 
        public string ToBankAccountName { get; set; }
        [Required] 
        public string ToBankAccountNumber { get; set; }
        [Required] 
        public string ToBankName { get; set; }
        [Required] 
        public string ToBankCode { get; set; }
        [Required] 
        public decimal FromAmount { get; set; }
        [Required] 
        public decimal ExchangeRate { get; set; }
        [Required] 
        public decimal Fees { get; set; }
        [Required] 
        public string TransactionNumber { get; set; }
        [Required] 
        public string FromCurrency { get; set; }
    }
}
