using AutoMapper;
using Cloud4NetDemo.Domain.Entities;
using Cloud4NetDemo.Shared;

namespace Cloud4NetDemo.Application.Mappings
{
    public class ShipmentProfile : Profile
    {
        public ShipmentProfile()
        {

            CreateMap<Shipment, ShipmentTrackerDto>()
                .ForMember(s => s.CustomerName, opt => opt.MapFrom(s => s.CustomerInfo.Name))
                .ForMember(s => s.PackageDescription, opt => opt.MapFrom(s => s.PackageInfo.Description));

        }
    }
}