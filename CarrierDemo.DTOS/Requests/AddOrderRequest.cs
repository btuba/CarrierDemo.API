using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrierDemo.DTOS.Requests
{
    public class AddOrderRequest
    {
        [Required(ErrorMessage = "Bu alan boş bırakılamaz!")]
        public int OrderDesi { get; set; }
    }
}
