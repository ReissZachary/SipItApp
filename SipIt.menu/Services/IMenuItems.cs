using SipIt.types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SipIt.menu.Services
{
    public interface IMenuItems
    {
        IEnumerable<Drink> GetDrinks();
    }
}
