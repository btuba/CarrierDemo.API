using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrierDemo.BLL
{
    public interface ICarrierConfigurationService
    {
        Task<int> AddCarrierConfiguration(AddCarrierConfigurationRequest request);
        Task<CarrierConfigurationDisplayResponse> GetCarrierConfiguration(int id);
        IList<CarrierConfigurationDisplayResponse> GetCarrierConfigurations();
        Task UpdateCarrierConfiguration(int id, object request);
        Task DeleteCarrierConfiguration(int id);
        Task<bool> IsCarrierConfigurationExist(int id);
    }
}
