using System.ComponentModel.DataAnnotations;

namespace Remittance_Provider.Dtos
{
    public class FeesParams
    {
        [Required]
        public string from { get; set; }
        [Required]
        public string to { get; set; }
    }

}
