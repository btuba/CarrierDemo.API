using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrierDemo.BLL
{
    public interface ICarrierService
    {
        Task<int> AddCarrier(object request);
        Task<CarrierDisplayResponse> GetCarrier(int id);
        IList<CarrierDisplayResponse> GetCarriers();
        Task UpdateCarrier(int id, object request);
        Task DeleteCarrier(int id);
        Task<bool> IsCarrierExist(int id);
    }
}
