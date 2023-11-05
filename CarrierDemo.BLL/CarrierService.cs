using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrierDemo.BLL
{
    public class CarrierService : ICarrierService
    {
        private readonly ICarrierReadRepository _carrierReadRepository;
        private readonly ICarrierWriteRepository _carrierWriteRepository;
        private readonly IMapper _mapper;
        public CarrierService(
            ICarrierWriteRepository carrierWriteRepository,
            ICarrierReadRepository carrierReadRepository,
            IMapper mapper)
        {
            _carrierWriteRepository = carrierWriteRepository;
            _carrierReadRepository = carrierReadRepository;
            _mapper = mapper;
        }
        public async Task<int> AddCarrier(object request)
        {
            var carrier = _mapper.Map<Carrier>(request);
            await _carrierWriteRepository.AddAsync(carrier);
            await _carrierWriteRepository.SaveAsync();
            return carrier.Id;
        }

        public async Task DeleteCarrier(int id)
        {
            await _carrierWriteRepository.RemoveAsync(id);
            await _carrierWriteRepository.SaveAsync();
        }

        public async Task<CarrierDisplayResponse> GetCarrier(int id)
        {
            var carrier = await _carrierReadRepository.GetByIdAsync(id);
            var response = _mapper.Map<CarrierDisplayResponse>(carrier);
            return response;
        }

        public IList<CarrierDisplayResponse> GetCarriers()
        {
            var carriers = _carrierReadRepository.GetAll();
            var result = _mapper.Map<IList<CarrierDisplayResponse>>(carriers);
            return result;
        }

        public async Task<bool> IsCarrierExist(int id)
        {
            return await _carrierReadRepository.IsExist(id);
        }

        public async Task UpdateCarrier(int id,object request)
        {
            var carrier = _mapper.Map<Carrier>(request);
            carrier.Id = id;
            _carrierWriteRepository.Update(carrier);
            await _carrierWriteRepository.SaveAsync();
        }
    }
}
