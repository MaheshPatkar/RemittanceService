using System;
using System.ComponentModel;
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
        [StringLength(2)]
        public string SenderCountry { get; set; }

        [Required]
        public string SenderCity { get; set; }

        [Required]
        [StringLength(2)]
        public string SendFromState { get; set; }

        [Required]
        public string SenderPostalCode { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string ToFirstName { get; set; }

        [Required]
        public string ToLastName { get; set; }

        [Required]
        [StringLength(2)]
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
        [DefaultValue(0)]
        public decimal Fees { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(25)]
        public string TransactionNumber { get; set; }

        [Required]
        [StringLength(3)]
        public string FromCurrency { get; set; }
    }
}
