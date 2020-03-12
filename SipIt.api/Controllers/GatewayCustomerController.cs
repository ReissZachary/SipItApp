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
    public class GatewayCustomerController
    {

        public GatewayCustomerController()
        {
        }

        [HttpPost]
        public void PostCustomer(Customer customer)
        {
        }
    }
}
