using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrierDemo.DAL.Repositories.Concrete
{
    public class CarrierReadRepository : ReadRepository<Carrier>, ICarrierReadRepository
    {
        public CarrierReadRepository(CarrierDbContext context) : base(context)
        {
        }
    }
}
