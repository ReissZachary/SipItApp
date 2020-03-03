using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace SipIt.customers.Services
{
    public class CustomerDataStore : ICustomerDataStore
    {

        private const string fileName = "customers.json";
        private const int RETRIES_ALLOWED = 5;
        ConcurrentDictionary<int, Customer> customers = new ConcurrentDictionary<int, Customer>();
        public CustomerDataStore()
        {
            if (File.Exists(fileName))
            {
                customers = deserializeCustomersAsync().Result;
            }
            else
            {
                AddSeedData();
            }

        }

        private async void AddSeedData()
        {
            Customer customer1 = new Customer()
            {
                Id = 1,
                FirstName = "James",
                LastName = "Jones",
                Email = "james.jones@mail.com"
            };
            Customer customer2 = new Customer()
            {
                Id = 2,
                FirstName = "Zachary",
                LastName = "Reiss",
                Email = "zachary.reiss@mail.com"
            };

            customers.AddOrUpdate(customer1.Id, customer1, (_id, _existingCustomer) => customer1);
            customers.AddOrUpdate(customer2.Id, customer2, (_id, _existing) => customer2);
            await serializeCustomersAsync(customers);
        }

        public async Task<int> AddAsync(Customer customer)
        {
            var newId = await doAddAsync(0, customer);
            await serializeCustomersAsync(customers);
            return newId; 
        }

        private async Task<int> doAddAsync(int timesTried, Customer customer)
        {
            int newId = customers.Count;
            if(timesTried > RETRIES_ALLOWED)
            {
                throw new RetrtiesExceededException("Unable to add customer");
            }
            if (customers.TryAdd(newId, customer))
            {
                customer.Id = newId;
                return await Task.FromResult(newId);
            }
            else
            {
                await Task.Delay(TimeSpan.FromMilliseconds(100 * timesTried));
                return await doAddAsync(timesTried + 1, customer);
            }
        }

        public async Task DeleteAsync(Customer customer)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Customer customer)
        {
            throw new NotImplementedException();
        }

        private async Task serializeCustomersAsync(ConcurrentDictionary<int, Customer> customerDictionary)
        {
            using (FileStream fs = File.Create(fileName))
            {
                await JsonSerializer.SerializeAsync(fs, customers);
            }
        }

        private async Task<ConcurrentDictionary<int, Customer>> deserializeCustomersAsync()
        {
            using (FileStream fs = File.OpenRead(fileName))
            {
                customers = await JsonSerializer.DeserializeAsync<ConcurrentDictionary<int, Customer>>(fs);
            }
            return customers;
        }
    }
}
