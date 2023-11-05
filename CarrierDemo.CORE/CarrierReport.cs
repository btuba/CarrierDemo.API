using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrierDemo.CORE
{
    public class CarrierReport : BaseEntitiy
    {
        public Carrier Carrier { get; set; }
        public decimal CarrierCost { get; set; }
        public DateTime CarrierReportDate { get; set; }
    }
}
