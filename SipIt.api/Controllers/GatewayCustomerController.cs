using Microsoft.AspNetCore.Mvc;
using SipIt.api.Services;
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
        private readonly ICustomerService customerService;

        public GatewayCustomerController(ICustomerService customerService)
        {
            this.customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
        }

        [HttpPost]
        public async Task PostCustomer(Customer customer) => await customerService.AddCustomerAsync(customer);

        [HttpGet]
        public async Task<IEnumerable<Customer>> GetCustomers() => await customerService.GetAllCustomersAsync();   
    }
}
