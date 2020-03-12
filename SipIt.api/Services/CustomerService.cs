using SipIt.types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SipIt.api.Services
{
    public class CustomerService : ICustomerService
    {
        public CustomerService()
        {

        }

        public void AddCustomer(Customer customer)
        {
            //call to customer api
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            throw new NotImplementedException();
        }
    }
}
