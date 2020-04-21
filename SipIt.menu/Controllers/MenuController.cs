using Microsoft.AspNetCore.Mvc;
using SipIt.menu.Services;
using SipIt.types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SipIt.menu.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MenuController : ControllerBase
    {
        private readonly IMenuItems menuItems;

        public MenuController(IMenuItems menuItems)
        {
            this.menuItems = menuItems ?? throw new ArgumentNullException(nameof(menuItems));
        }

        [HttpGet]
        public IEnumerable<Drink> GetDrinks() => menuItems.GetDrinks();
        
    }
}
