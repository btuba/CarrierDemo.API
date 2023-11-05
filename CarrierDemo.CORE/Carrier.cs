using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrierDemo.CORE
{
    public class Carrier : BaseEntitiy
    {
        public string CarrierName { get; set; }
        public bool CarrierIsActive { get; set; }
        public int CarrierPlusDesiCost { get; set; }
        public ICollection<CarrierConfiguration>? CarrierConfigurations { get; set; }
        public ICollection<Order>? Orders { get; set; }
        public ICollection<Carrier>? CarrierReports { get; set; }

    }
}
