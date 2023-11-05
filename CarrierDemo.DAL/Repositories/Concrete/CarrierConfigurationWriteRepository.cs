using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrierDemo.DAL.Repositories.Concrete
{
    public class CarrierConfigurationWriteRepository : WriteRepository<CarrierConfiguration>, ICarrierConfigurationWriteRepository
    {
        public CarrierConfigurationWriteRepository(CarrierDbContext context) : base(context)
        {
        }
    }
}
