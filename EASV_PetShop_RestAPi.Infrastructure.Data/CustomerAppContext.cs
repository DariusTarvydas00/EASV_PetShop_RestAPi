using EASV_PetShop.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace EASV_PetShop_RestAPi.Infrastructure.Data
{
    public class CustomerAppContext: DbContext
    {
        public CustomerAppContext(DbContextOptions<CustomerAppContext> opt) : base(opt) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pet>().HasOne(pet => pet.Customer).WithMany(customer => customer.Pets).OnDelete(DeleteBehavior.SetNull);
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Pet> Pets { get; set; }
    }
}