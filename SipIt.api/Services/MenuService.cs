using SipIt.menu.Controllers;
using SipIt.types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SipIt.api.Services
{
    public class MenuService : IMenuService
    {
        private readonly MenuController menuController;

        public MenuService(MenuController menuController)
        {
            this.menuController = menuController ?? throw new ArgumentNullException(nameof(menuController));
        }
        public IEnumerable<Drink> GetAllDrinks() => menuController.GetDrinks();
       
    }
}
