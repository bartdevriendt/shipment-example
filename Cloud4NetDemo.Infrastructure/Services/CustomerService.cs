using System;
using System.Threading.Tasks;
using Cloud4NetDemo.Application.Services;
using Cloud4NetDemo.Domain.Entities;

namespace Cloud4NetDemo.Infrastructure.Services
{
    public class CustomerService : ICustomerService
    {
        public async Task<CustomerInfo> FindCustomer(string customerId)
        {
            if (customerId != "foo") return null;

            return new CustomerInfo
            {
                Address = "Bosstraat 12, 4001 Meerdaalwoud",
                CustomerId = "foo",
                Name = "Paulus De Boskabouter",
                Grade = 17
            };
        }
    }
}