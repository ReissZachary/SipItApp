using SipIt.customers.Controllers;
using SipIt.types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SipIt.api.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly CustomerController customerController;

        public CustomerService(CustomerController customerController)
        {
            this.customerController = customerController ?? throw new ArgumentNullException(nameof(customerController));
        }

        public void AddCustomer(Customer customer)
        {
            customerController.AddCustomer(customer);
        }

        public IEnumerable<Customer> GetAllCustomers() => customerController.GetCustomers();        
    }
}
