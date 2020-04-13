using Microsoft.AspNetCore.Mvc;
using SipIt.orders.Services;
using SipIt.types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SipIt.orders.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ICustomerOrders customerOrders;

        public OrderController(ICustomerOrders customerOrders)
        {
            this.customerOrders = customerOrders ?? throw new ArgumentNullException(nameof(orders));
        }

        [HttpPost]
        public async Task AddOrderAsync(Order order)
        {
            await customerOrders.AddOrderAsync(order);
        }

        [HttpGet]
        public async Task<IEnumerable<Order>> GetOrdersAsync()
        {
             return await customerOrders.GetAllOrdersAsync();
        }

        //get orders by customer id
    }
}
