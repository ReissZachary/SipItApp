using Microsoft.AspNetCore.Mvc;
using SipIt.api.Services;
using SipIt.customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SipIt.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GatewayCustomerController
    {
        private readonly ICustomerService customerService;

        public GatewayCustomerController(ICustomerService customerService)
        {
            this.customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
        }

        [HttpPost]
        public void PostCustomer(Customer customer)
        {
            customerService.AddCustomer(customer);
        }
    }
}
