using System.Collections.Generic;
using EASV_PetShop.Core.Entity;

namespace EASV_PetShop_RestAPi.Infrastructure.Data
{
    public class DBInitializer
    {
        public static void SeedDB(CustomerAppContext ctx)
        {
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();
            var cust = ctx.Customers.Add(new Customer()
            {
                FirstName = "asdfasd",
                Pets = new List<Pet>()
                {
                    new Pet()
                    {
                        Name = "sdfa"
                    }
                }
            }).Entity;
                    
            ctx.Customers.Add(new Customer()
            {
                FirstName = "asdfads"
            });
                    
            var pet = ctx.Pets.Add(new Pet()
            {
                Name = "asdfasd"
            }).Entity;
                    
            ctx.Pets.Add(new Pet()
            {
                Name = "asdfads"
            });
            ctx.SaveChanges();
        }
    }
}