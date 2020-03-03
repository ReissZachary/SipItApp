using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SipIt.customers.Services
{
    public interface ICustomerDataStore
    {
        Task<int> AddAsync(Customer customer);
        Task DeleteAsync(Customer customer);

        Task UpdateAsync(Customer customer);
    }
}
