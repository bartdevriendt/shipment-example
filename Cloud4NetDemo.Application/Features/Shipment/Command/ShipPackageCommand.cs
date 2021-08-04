using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Cloud4NetDemo.Application.Services;
using Cloud4NetDemo.Shared;
using MediatR;

namespace Cloud4NetDemo.Application.Features.Shipment.Command
{
    public class ShipPackageCommand : IRequest<ShipmentTrackerDto>
    {
        public ShipmentRequestDto Request { get; set; }
    }

    public class ShipPackageCommandHandler : IRequestHandler<ShipPackageCommand, ShipmentTrackerDto>
    {
        private IShipmentService _shipmentService;
        private IMapper _mapper;

        public ShipPackageCommandHandler(IShipmentService shipmentService, IMapper mapper)
        {
            _shipmentService = shipmentService;
            _mapper = mapper;
        }


        public async Task<ShipmentTrackerDto> Handle(ShipPackageCommand request, CancellationToken cancellationToken)
        {

            var shipment = await _shipmentService.ShipPackage(request.Request.CustomerId, request.Request.PackageId);
            return _mapper.Map<ShipmentTrackerDto>(shipment);
            
        }
    }
}