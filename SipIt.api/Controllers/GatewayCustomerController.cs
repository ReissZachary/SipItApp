using Microsoft.AspNetCore.Mvc;
using SipIt.api.Services;
using SipIt.customers.Services;
using SipIt.types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SipIt.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GatewayCustomerController : ControllerBase
    {
        private readonly CustomerService customerService;

        public GatewayCustomerController(CustomerService customerService)
        {
            this.customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
        }

        [HttpPost]
        public void PostCustomer(Customer customer)
        {
            customerService.AddCustomer(customer);
        }

        [HttpGet]
        public IEnumerable<Customer> GetCustomers() => customerService.GetAllCustomers();   
    }
}
