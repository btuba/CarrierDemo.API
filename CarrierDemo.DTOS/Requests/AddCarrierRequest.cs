using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrierDemo.DTOS.Requests
{
    public class AddCarrierRequest
    {
        [Required(ErrorMessage = "Bu alan boş bırakılamaz!")]
        public string CarrierName { get; set; }
        [Required(ErrorMessage = "Bu alan boş bırakılamaz!")]
        public bool CarrierIsActive { get; set; }
        [Required(ErrorMessage = "Bu alan boş bırakılamaz!")]
        public int CarrierPlusDesiCost { get; set; }
    }
}
