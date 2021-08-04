using System;
using System.Threading.Tasks;
using Cloud4NetDemo.Application.Services;
using Cloud4NetDemo.Domain.Entities;

namespace Cloud4NetDemo.Infrastructure.Services
{
    public class WarehouseService : IWarehouseService
    {
        public async Task<PackageInfo> FindPackage(string packageId)
        {
            if (packageId != "bar")
            {
                return null;
            }

            return new PackageInfo
            {
                PackageId = "foo",
                Description = "Muts",
                InWarehouse = true
            };
        }
    }
}