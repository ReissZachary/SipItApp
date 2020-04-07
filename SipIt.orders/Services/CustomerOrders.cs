using SipIt.types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SipIt.orders.Services
{
    public class CustomerOrders : ICustomerOrders
    {
        public IEnumerable<Order> GetCustomerOrdersAsync(int customerId)
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetOrdersAsync()
        {
            throw new NotImplementedException();
        }
    }
}
