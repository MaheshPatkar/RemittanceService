using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Remittance_Provider.Dtos
{
    public class FeesParams
    {
        [DefaultValue("US")]
        private string _from;

        public string from
        {
            get { return _from == null ? "US" : _from; }
            set { _from = value; }
        }
        [Required]
        public string to { get; set; }
    }

}
