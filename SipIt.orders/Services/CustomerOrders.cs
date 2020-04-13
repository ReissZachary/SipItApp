using SipIt.types;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace SipIt.orders.Services
{
    public class CustomerOrders : ICustomerOrders
    {
        private const string fileName = "orders.json";
        ConcurrentDictionary<int, Order> orders = new ConcurrentDictionary<int, Order>();

        public CustomerOrders()
        {
            if (File.Exists(fileName))
            {
                orders = deserializeOrdersAsync().Result;
            }
            else
            {
                AddSeedData();
            }
        }


        public async Task<int> AddOrderAsync(Order order)
        {
            order.OrderId = orders.Count;
            orders.AddOrUpdate(order.OrderId, order, (_id, _existing) => order);
            await serializeOrdersAsync(orders);
            return order.OrderId;
        }
        public async Task<IEnumerable<Order>> GetCustomerOrdersAsync(int customerId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await Task.FromResult(orders.Values);
        }
        private async void AddSeedData()
        {
            Drink drink1 = new Drink()
            {
                Id = 1,
                Category = "Dr. Pepper",
                Additions = { "Coconut", "cream" },
                Name = "Dirty Dr.Pepper"
            };

            
            Order firstOrder = new Order()
            {
                OrderId = 1,
                CustomerId = 2,
                Items = {drink1},
                Quantity = 1,
                Total = 4.50M,
                Date = DateTime.Now

            };

            orders.AddOrUpdate(firstOrder.OrderId, firstOrder, (_id, _existing) => firstOrder);
            await serializeOrdersAsync(orders);
        }
        private async Task<ConcurrentDictionary<int, Order>> deserializeOrdersAsync()
        {
            orders = new ConcurrentDictionary<int, Order>();
            using (FileStream fs = File.OpenRead(fileName))
            {
                foreach (var order in await JsonSerializer.DeserializeAsync<List<Order>>(fs))
                    orders.TryAdd(order.OrderId, order);
            }
            return orders;
        }

        private async Task serializeOrdersAsync(ConcurrentDictionary<int, Order> orders)
        {
            using (FileStream fs = File.Create(fileName))
            {
                await JsonSerializer.SerializeAsync(fs, orders.Values);
            }
        }
    }
}
