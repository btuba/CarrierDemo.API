using AutoMapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrierDemo.BLL.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<AddCarrierRequest, Carrier>();
            CreateMap<UpdateCarrierRequest, Carrier>();
            CreateMap<Carrier, CarrierDisplayResponse>();
            
            CreateMap<AddCarrierConfigurationRequest, CarrierConfiguration>();
            CreateMap<UpdateCarrierConfigurationRequest, CarrierConfiguration>();
            CreateMap<CarrierConfiguration, CarrierConfigurationDisplayResponse>();

            CreateMap<AddOrderRequest, Order>();
            CreateMap<Order, OrderDisplayRepsonse>();
        }
    }
}
