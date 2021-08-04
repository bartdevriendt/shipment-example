using System;
using System.Threading.Tasks;
using Cloud4NetDemo.Domain.Entities;

namespace Cloud4NetDemo.Application.Services
{
    public interface ICustomerService
    {
        Task<CustomerInfo> FindCustomer(string customerId);
    }
}