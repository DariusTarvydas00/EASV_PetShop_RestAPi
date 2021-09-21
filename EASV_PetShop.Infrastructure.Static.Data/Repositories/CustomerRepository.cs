﻿using System.Collections.Generic;
using System.Linq;
using EASV_PetShop.Core.DomainService;
using EASV_PetShop.Core.Entity;

namespace ClassLibrary1Infrastructure.Repositories
{
    public class CustomerRepository: ICustomerRepository
    {

        public CustomerRepository()
        {
            if (FakeDB.Customers.Count >= 1) return;
            var customer1 = new Customer()
            {
                Id = FakeDB.id++,
                FirstName = "Bob",
                LastName = "Dylan",
                Address = "Bongo street 22",
                Email = "Bob@Dylan.com",
                PhoneNumber = "123456789"
            };
            FakeDB.Customers.Add(customer1);
            
            var customer2 = new Customer()
            {
                Id = FakeDB.id++,
                FirstName = "Ding",
                LastName = "Kong",
                Address = "Chris Cross street 41",
                Email = "Donk@Kong.com",
                PhoneNumber = "987654321"
            };
            FakeDB.Customers.Add(customer2);
        }

        public Customer Create(Customer customer)
        {
            customer.Id = FakeDB.id++;
            FakeDB.Customers.Add(customer);
            return customer;
        }

        public Customer ReadById(int id)
        {
            foreach (var customer in FakeDB.Customers)
            {
                if (customer.Id == id)
                {
                    return customer;
                }
            }

            return null;
        }

        public IEnumerable<Customer> ReadAll()
        {
            return FakeDB.Customers;
        }

        public Customer Update(Customer customerUpdate)
        {
            var customerFromDb = ReadById(customerUpdate.Id);
            if (customerFromDb == null) return null;
            
                customerFromDb.FirstName = customerUpdate.FirstName;
                customerFromDb.LastName = customerUpdate.LastName;
                customerFromDb.Address = customerUpdate.Address;
                customerFromDb.Email = customerUpdate.Email;
                customerFromDb.PhoneNumber = customerUpdate.PhoneNumber;
                return customerFromDb;
        }

        public Customer Delete(int id)
        {
            var customerFound = ReadById(id);

            if (customerFound != null)
            {
                FakeDB.Customers.Remove(customerFound);
                return customerFound;
            }

            return null;
        }
    }
}