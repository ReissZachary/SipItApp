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
    public class GatewayMenuController
    {
        private readonly IMenuService menuService;

        public GatewayMenuController(IMenuService menuService)
        {
            this.menuService = menuService ?? throw new ArgumentNullException(nameof(menuService));
        }

        [HttpGet]
        public async Task<IEnumerable<Drink>> GetAllDrinks() => await menuService.GetAllDrinksAsync();
    }
}

