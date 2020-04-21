using Refit;
using SipIt.types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SipIt.api.Services
{
    
    public interface IMenuService
    {
        [Get("/menu")]
        IEnumerable<Drink> GetAllDrinks();
    }
}
