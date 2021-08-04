using System;

namespace Cloud4NetDemo.Domain.Entities
{
    public class PackageInfo
    {
        public string PackageId { get; set; }
        public string Description { get; set; }
        public bool InWarehouse { get; set; }
    }
}