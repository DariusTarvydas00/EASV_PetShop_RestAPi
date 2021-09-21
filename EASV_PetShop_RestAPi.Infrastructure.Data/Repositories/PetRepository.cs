using System.Collections.Generic;
using System.Linq;
using EASV_PetShop.Core.DomainService;
using EASV_PetShop.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace EASV_PetShop_RestAPi.Infrastructure.Data.Repositories
{
    public class PetRepository: IPetRepository
    {
        private readonly CustomerAppContext _ctx;

        public PetRepository(CustomerAppContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Pet> ReadAll()
        {
            return _ctx.Pets;
        }

        public Pet Create(Pet pet)
        {
            var pets = _ctx.Pets.Add(pet).Entity;
            _ctx.SaveChanges();
            return pets;
        }

        public Pet Delete(int id)
        {
            var petRemoved =_ctx.Remove(new Pet {Id = id}).Entity;
            _ctx.SaveChanges();
            return petRemoved;
        }

        public Pet ReadById(int id)
        {
            return _ctx.Pets.Include(pet => pet.Customer).FirstOrDefault(pet => pet.Id == id);
        }
    }
}