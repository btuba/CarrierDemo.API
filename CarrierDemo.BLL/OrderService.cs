using CarrierDemo.CORE;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrierDemo.BLL
{
    public class OrderService : IOrderService
    {
        private readonly ICarrierReadRepository _carrierReadRepository;
        private readonly ICarrierConfigurationReadRepository _carrierConfigurationReadRepository;
        private readonly IOrderReadRepository _orderReadRepository;
        private readonly IOrderWriteRepository _ordererWriteRepository;
        private readonly IMapper _mapper;

        public OrderService(
            ICarrierReadRepository carrierReadRepository,
            ICarrierConfigurationReadRepository carrierConfigurationReadRepository,
            IOrderReadRepository orderReadRepository,
            IOrderWriteRepository orderWriteRepository,
            IMapper mapper)
        {
            _carrierConfigurationReadRepository = carrierConfigurationReadRepository;
            _carrierReadRepository = carrierReadRepository;
            _orderReadRepository = orderReadRepository;
            _ordererWriteRepository = orderWriteRepository;
            _mapper = mapper;
        }
        public async Task<int> AddOrder(AddOrderRequest request)
        {
            var order = _mapper.Map<Order>(request);
            order = CreateOrder(order);
            order.OrderDate = DateTime.Now.Date;
            await _ordererWriteRepository.AddAsync(order);
            await _ordererWriteRepository.SaveAsync();
            return order.Id;
        }

        public async Task DeleteOrder(int id)
        {
            await _ordererWriteRepository.RemoveAsync(id);
            await _ordererWriteRepository.SaveAsync();
        }

        public IList<OrderDisplayRepsonse> GetOrders()
        {
            var orders = _orderReadRepository.GetAll().Include(x=> x.Carrier);
            var result = _mapper.Map<IList<OrderDisplayRepsonse>>(orders);
            return result;
        }

        public async Task<bool> IsOrderExist(int id)
        {
            return await _orderReadRepository.IsExist(id);
        }

        private Order CreateOrder(Order order)
        {
            CarrierConfiguration carrierConfiguration;
            var _carrierConfigurations =
                _carrierConfigurationReadRepository
                .GetAll()
                .Include(x => x.Carrier)
                .Where(x => x.Carrier.CarrierIsActive)
                .Where(x => x.CarrierMinDesi <= order.OrderDesi && order.OrderDesi <= x.CarrierMaxDesi);
            
            if (_carrierConfigurations.Any())
            {
                carrierConfiguration = _carrierConfigurations
                    .OrderBy(x => x.CarrierCost)
                    .First();
                
                order.OrderCarrierCost = carrierConfiguration.CarrierCost;
            }
            else
            {
                carrierConfiguration = _carrierConfigurationReadRepository
                    .GetAll()
                    .Include(x=> x.Carrier)
                    .OrderBy(x => order.OrderDesi - x.CarrierMaxDesi).First();

                order.OrderCarrierCost =
                    carrierConfiguration.CarrierCost
                    + carrierConfiguration.Carrier.CarrierPlusDesiCost * (order.OrderDesi - carrierConfiguration.CarrierMaxDesi);
            }

            order.Carrier = carrierConfiguration.Carrier;

            return order;
        }
    }
}
