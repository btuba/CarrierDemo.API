using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrierDemo.DTOS.Requests
{
    public class UpdateCarrierRequest
    {
        [Required]
        public string CarrierName { get; set; }
        [Required]
        public bool CarrierIsActive { get; set; }
        [Required]
        public int CarrierPlusDesiCost { get; set; }
    }
}
