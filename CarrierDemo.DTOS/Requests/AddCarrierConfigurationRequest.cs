using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrierDemo.DTOS.Requests
{
    public class AddCarrierConfigurationRequest
    {
        [Required(ErrorMessage = "Bu alan boş bırakılamaz!")]
        public int CarrierId { get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz!")]
        public int CarrierMaxDesi { get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz!")]
        public int CarrierMinDesi { get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz!")]
        [DataType(DataType.Currency)]
        public decimal CarrierCost { get; set; }
    }
}
