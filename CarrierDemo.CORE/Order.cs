﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrierDemo.CORE
{
    public class Order : BaseEntitiy
    {
        public int OrderDesi { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal OrderCarrierCost { get; set; }
        public Carrier Carrier { get; set; }
    }
}
