using System.ComponentModel.DataAnnotations;

namespace Remittance_Provider.Dtos
{
    public class BeneficiaryParams
    {
        [Required]
        public int accountNumber { get; set; }
        [Required]
        public string bankCode { get; set; }
    }
}
