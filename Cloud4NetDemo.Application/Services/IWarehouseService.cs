using System;
using System.Threading.Tasks;
using Cloud4NetDemo.Domain.Entities;

namespace Cloud4NetDemo.Application.Services
{
    public interface IWarehouseService
    {
        Task<PackageInfo> FindPackage(string packageId);
    }
}