using System;

namespace Cloud4NetDemo.Shared
{
    public class ShipmentTrackerDto
    {
        
        public Guid TrackingNumber { get; set; }
        public string PackageDescription { get; set; }
        public string CustomerName { get; set; }
    }
}