using System;
using Cloud4NetDemo.Domain.Enums;

namespace Cloud4NetDemo.Domain.Entities
{
    public class Shipment
    {
        public PackageInfo PackageInfo { get; set; }
        public CustomerInfo CustomerInfo { get; set; }
        public Guid TrackingNumber { get; set; }
        public ShipmentType ShipmentType { get; set; }
        
    }
}