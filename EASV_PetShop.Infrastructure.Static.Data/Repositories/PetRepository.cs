using System.Collections.Generic;
using EASV_PetShop.Core.DomainService;
using EASV_PetShop.Core.Entity;

namespace ClassLibrary1Infrastructure.Repositories
{
    public class PetRepository: IPetRepository
    {
        private static int _id = 1;
        private static readonly List<Pet> Pets = new List<Pet>();

        public IEnumerable<Pet> ReadAll()
        {
            return Pets;
        }

        public Pet Create(Pet pet)
        {
            pet.Id = _id++;
            Pets.Add(pet);
            return pet;
        }

        public Pet Delete(int id)
        {
            var petFound = this.ReadById(id);

            if (petFound != null)
            {
                Pets.Remove(petFound);
                return petFound;
            }

            return null;
        }

        public Pet ReadById(int id)
        {
            foreach (var pet in Pets)
            {
                if (pet.Id == id)
                {
                    return pet;
                }
            }

            return null;
        }
    }
}