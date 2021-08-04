using System;
using System.Threading.Tasks;
using Cloud4NetDemo.Application.Exceptions;
using Cloud4NetDemo.Application.Services;
using Cloud4NetDemo.Domain.Entities;
using Cloud4NetDemo.Domain.Enums;

namespace Cloud4NetDemo.Infrastructure.Services
{
    public class ShipmentService : IShipmentService
    {

        private IWarehouseService _warehouseService;
        private ICustomerService _customerService;

        public ShipmentService(IWarehouseService warehouseService, ICustomerService customerService)
        {
            _warehouseService = warehouseService;
            _customerService = customerService;
        }

        public async Task<Shipment> ShipPackage(string customerId, string packageId)
        {
            var packageInfo = await _warehouseService.FindPackage(packageId);

            if (packageInfo == null)
            {
                throw new ShipmentException($"Cannot find package {packageId}");
            }

            if (!packageInfo.InWarehouse)
            {
                throw new ShipmentException($"Package {packageId} has not yet arrived at the warehouse");
            }

            var customerInfo = await _customerService.FindCustomer(customerId);
            if (customerInfo == null)
            {
                throw new ShipmentException($"Cannot find customer {customerId}");
            }

            ShipmentType shipmentType = ShipmentType.STANDARD.fromCustomerGrade(customerInfo.Grade);
            Guid trackingNumber = Guid.NewGuid();

            return new Shipment
            {
                CustomerInfo = customerInfo,
                PackageInfo = packageInfo,
                TrackingNumber = trackingNumber,
                ShipmentType = shipmentType
            };
        }
    }
}