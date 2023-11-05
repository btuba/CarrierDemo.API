using Microsoft.EntityFrameworkCore;

namespace CarrierDemo.BLL.Jobs
{
    public class Job
    {
        private readonly ICarrierReportWriteRepository _carrierReportWriteRepository;
        private readonly IOrderReadRepository _orderReadRepository;
        public Job(ICarrierReportWriteRepository carrierReportWriteRepository, IOrderReadRepository orderReadRepository)
        {
            _carrierReportWriteRepository = carrierReportWriteRepository;
            _orderReadRepository = orderReadRepository;
        }
        public async Task ReportOrders()
        {
            var carrierReports = _orderReadRepository
                .GetAll()
                .Include(x => x.Carrier)
                .AsEnumerable().GroupBy(x => new { x.Carrier, x.OrderDate })
                .Select(g => new CarrierReport
                {
                    Carrier = g.Key.Carrier,
                    CarrierCost = g.Sum(x => x.OrderCarrierCost),
                    CarrierReportDate = g.Key.OrderDate,
                    CreatedDate = DateTime.Now
                })
                .ToArray();

            await _carrierReportWriteRepository.AddRangeAsync(carrierReports);
            await _carrierReportWriteRepository.SaveAsync();
        }
    }
}
