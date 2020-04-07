using SipIt.types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SipIt.orders.Services
{
    public interface ICustomerOrders
    {
        IEnumerable<Order> GetCustomerOrdersAsync(int customerId);
        Task<Order> GetOrdersAsync();
    }
}
