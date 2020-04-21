using Refit;
using SipIt.types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SipIt.api.Services
{
    public interface ICustomerService
    {
        [Post("/customer")]
        Task AddCustomerAsync(Customer customer);

        [Get("/customer")]
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
    }
}
