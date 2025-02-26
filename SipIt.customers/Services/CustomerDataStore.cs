﻿using SipIt.types;
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
                FirstName = "SeedCustomer",
                LastName = "SeedCustomer",
                Email = "Seed.Customer@mail.com"
            };

            customers.AddOrUpdate(customer1.Id, customer1, (_id, _existingCustomer) => customer1);
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
            int newId = customers.Count + 1;
            if(timesTried > RETRIES_ALLOWED)
            {
                throw new RetrtiesExceededException("Unable to add customer");
            }
            if (customers.TryAdd(newId, customer))
            {
                customer.Id = newId;
                customers.AddOrUpdate(customer.Id, customer, (_id, _existing) => customer);
                //await serializeCustomersAsync(customers);
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
                await JsonSerializer.SerializeAsync(fs, customers.Values);
            }
        }

        private async Task<ConcurrentDictionary<int, Customer>> deserializeCustomersAsync()
        {
            customers = new ConcurrentDictionary<int, Customer>();
            using (FileStream fs = File.OpenRead(fileName))
            {
                foreach (var customer in await JsonSerializer.DeserializeAsync<List<Customer>>(fs))
                    customers.TryAdd(customer.Id, customer);
            }
            return customers;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return customers.Values;
        }
    }
}
