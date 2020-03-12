using Microsoft.AspNetCore.Mvc;
using SipIt.customers.Services;
using SipIt.types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SipIt.customers.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerDataStore dataStore;

        public CustomerController(ICustomerDataStore dataStore)
        {
            this.dataStore = dataStore ?? throw new ArgumentNullException(nameof(dataStore));
        }
        public void AddCustomer(Customer customer)
        {
            //call data store add customer..
        }

        [HttpGet]
        public IEnumerable<Customer> GetCustomers()
        {
            //return call get all customers from data store..
            return dataStore.GetCustomers();
        }
    }
}
