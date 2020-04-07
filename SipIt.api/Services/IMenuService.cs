using SipIt.types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SipIt.api.Services
{
    public interface IMenuService
    {
        IEnumerable<Drink> GetAllDrinks();
    }
}
