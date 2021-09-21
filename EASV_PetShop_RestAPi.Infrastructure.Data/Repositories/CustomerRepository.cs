using System.Collections.Generic;
using System.Linq;
using EASV_PetShop.Core.DomainService;
using EASV_PetShop.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace EASV_PetShop_RestAPi.Infrastructure.Data.Repositories
{
    public class CustomerRepository: ICustomerRepository
    {
        private readonly CustomerAppContext _ctx;

        public CustomerRepository(CustomerAppContext ctx)
        {
            _ctx = ctx;
        }

        public Customer Create(Customer customer)
        {
            var cust = _ctx.Customers.Add(customer).Entity;
            _ctx.SaveChanges();
            return cust;
        }

        public Customer ReadById(int id)
        {
            return _ctx.Customers.FirstOrDefault(customer => customer.Id == id);
        }

        public IEnumerable<Customer> ReadAll()
        {
            return _ctx.Customers.ToList();
        }

        public Customer Update(Customer customerUpdate)
        {
            throw new System.NotImplementedException();
        }

        public Customer Delete(int id)
        {
            var custRemoved =_ctx.Remove(new Customer {Id = id}).Entity;
            _ctx.SaveChanges();
            return custRemoved;
        }

        public IEnumerable<Pet> ReadAllPets()
        {
            return _ctx.Pets.ToList();
        }

        public Customer ReadByIdIncludeOrders(int id)
        {
            return _ctx.Customers.Include(customer => customer.Pets).FirstOrDefault(customer => customer.Id == id);
        }
    }
}