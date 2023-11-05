using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrierDemo.BLL
{
    public interface IOrderService
    {
        Task<int> AddOrder(AddOrderRequest request);
        IList<OrderDisplayRepsonse> GetOrders();
        Task DeleteOrder(int id);
        Task<bool> IsOrderExist(int id);

    }
}
