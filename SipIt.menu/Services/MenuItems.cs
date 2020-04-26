using SipIt.types;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace SipIt.menu.Services
{
    public class MenuItems : IMenuItems
    {
        //This is just like what I did for customers...
        private const string fileName = "drinks.json";
        ConcurrentDictionary<int, Drink> drinks = new ConcurrentDictionary<int, Drink>();

        public MenuItems()
        {
            if (File.Exists(fileName))
            {
                drinks = deserializeDrinksAsync().Result;
            }
            else
            {
                //AddSeedData();
            }
        }

        //private async void AddSeedData()
        //{
        //    //for now, I wanted to test out 4 drinks...not sure if this is the best approach.
        //    Drink drink1 = new Drink()
        //    {
        //        Id = 1,
        //        Base = "Dr. Pepper",
        //        Additions = { "Coconut", "cream" },
        //        Name = "Dirty Dr.Pepper"
        //    };
        //    Drink drink2 = new Drink()
        //    {
        //        Id = 2,
        //        Base = "Sprite",
        //        Additions = { "Blue Coconut" },
        //        Name = "Cougar Juice"
        //    };
            
        //    Drink drink3 = new Drink()
        //    {
        //        Id = 3,
        //        Base = "Mt.Dew",
        //        Additions = { "Coconut", "Peach" },
        //        Name = "Maui Breeze"
        //    }; 
            
        //    Drink drink4 = new Drink()
        //    {
        //        Id = 4,
        //        Base = "Root Beer",
        //        Additions = { "Vanilla", "cream" },
        //        Name = "Vanilla Brew"
        //    };

            

        //    drinks.AddOrUpdate(drink1.Id, drink1, (_id, _existing) => drink1);
        //    drinks.AddOrUpdate(drink2.Id, drink2, (_id, _existing) => drink2);
        //    drinks.AddOrUpdate(drink3.Id, drink3, (_id, _existing) => drink3);
        //    drinks.AddOrUpdate(drink4.Id, drink4, (_id, _existing) => drink4);
        //    await serializeDrinksAsync(drinks);
        //}

        private async Task serializeDrinksAsync(ConcurrentDictionary<int, Drink> drinkDictionary)
        {
            using (FileStream fs = File.Create(fileName))
            {
                await JsonSerializer.SerializeAsync(fs, drinks.Values);
            }
        }

        private async Task<ConcurrentDictionary<int, Drink>> deserializeDrinksAsync()
        {
            drinks = new ConcurrentDictionary<int, Drink>();
            using (FileStream fs = File.OpenRead(fileName))
            {
                foreach (var drink in await JsonSerializer.DeserializeAsync<List<Drink>>(fs))
                    drinks.TryAdd(drink.Id, drink);
            }
            return drinks;
        }

        public IEnumerable<Drink> GetDrinks()
        {
            return drinks.Values;
        }
    }
}
