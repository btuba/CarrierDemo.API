using CarrierDemo.CORE;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrierDemo.BLL
{
    public class CarrierConfigurationService : ICarrierConfigurationService
    {
        private readonly ICarrierConfigurationReadRepository _carrierConfigurationReadRepository;
        private readonly ICarrierConfigurationWriteRepository _carrierConfigurationWriteRepository;
        private readonly ICarrierReadRepository _carrierReadRepository;
        private readonly IMapper _mapper;
        public CarrierConfigurationService(
            ICarrierConfigurationWriteRepository carrierConfigurationWriteRepository,
            ICarrierConfigurationReadRepository carrierConfigurationReadRepository,
            ICarrierReadRepository carrierReadRepository,
            IMapper mapper)
        {
            _carrierConfigurationWriteRepository = carrierConfigurationWriteRepository;
            _carrierConfigurationReadRepository = carrierConfigurationReadRepository;
            _carrierReadRepository = carrierReadRepository;
            _mapper = mapper;
        }
        public async Task<int> AddCarrierConfiguration(AddCarrierConfigurationRequest request)
        {
            var carrierConfiguration = _mapper.Map<CarrierConfiguration>(request);
            carrierConfiguration.Carrier = await _carrierReadRepository.GetByIdAsync(request.CarrierId);
            await _carrierConfigurationWriteRepository.AddAsync(carrierConfiguration);
            await _carrierConfigurationWriteRepository.SaveAsync();
            return carrierConfiguration.Id;
        }

        public async Task DeleteCarrierConfiguration(int id)
        {
            await _carrierConfigurationWriteRepository.RemoveAsync(id);
            await _carrierConfigurationWriteRepository.SaveAsync();
        }

        public async Task<CarrierConfigurationDisplayResponse> GetCarrierConfiguration(int id)
        {
            var carrierConfiguration = await _carrierConfigurationReadRepository.GetByIdAsync(id);
            var response = _mapper.Map<CarrierConfigurationDisplayResponse>(carrierConfiguration);
            return response;
        }

        public IList<CarrierConfigurationDisplayResponse> GetCarrierConfigurations()
        {
            var carrierConfigurations = _carrierConfigurationReadRepository.GetAll().Include(x=> x.Carrier);
            var result = _mapper.Map<IList<CarrierConfigurationDisplayResponse>>(carrierConfigurations);
            return result;
        }

        public async Task<bool> IsCarrierConfigurationExist(int id)
        {
            return await _carrierConfigurationReadRepository.IsExist(id);
        }

        public async Task UpdateCarrierConfiguration(int id, object request)
        {
            var carrierConfiguration = _mapper.Map<CarrierConfiguration>(request);
            carrierConfiguration.Id = id;
            _carrierConfigurationWriteRepository.Update(carrierConfiguration);
            await _carrierConfigurationWriteRepository.SaveAsync();
        }
    }
}
