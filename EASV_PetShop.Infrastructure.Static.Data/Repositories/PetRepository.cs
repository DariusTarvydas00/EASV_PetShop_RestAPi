using System;
using System.Collections.Generic;
using EASV_PetShop.Core.ApplicationService.Services;
using EASV_PetShop.Core.DomainService;
using EASV_PetShop.Core.Entity;

namespace ClassLibrary1Infrastructure.Repositories
{
    public class PetRepository: IPetRepository
    {

        public PetRepository()
        {
            if (FakeDB.Pets.Count >= 1) return;
            var pet1 = new Pet()
            {
                Id = FakeDB.petId++,
                Name = "Kaira",
               // PetType = _petTypeService.NewPetType("Vokietis"),
                BirthDate = Convert.ToDateTime("1999.01.01"),
                SoldDate = Convert.ToDateTime("1999.02.02"),
                Color = "Black",
                Price = 421.20,
            };
            FakeDB.Pets.Add(pet1);
            
            var pet2 = new Pet()
            {
                Id = FakeDB.petId++,
                Name = "Enzo",
               // PetType = _petTypeService.NewPetType("Atejunas"),
                BirthDate = Convert.ToDateTime("1999.01.01"),
                SoldDate = Convert.ToDateTime("1999.02.02"),
                Color = "Hybrid",
                Price = 821.20
            };
            FakeDB.Pets.Add(pet2);
            
            var pet3 = new Pet()
            {
                Id = FakeDB.petId++,
                Name = "Tidfsgka",
               // PetType = _petTypeService.NewPetType("asd"),
                BirthDate = Convert.ToDateTime("1999.01.01"),
                SoldDate = Convert.ToDateTime("1999.02.02"),
                Color = "Hybrid",
                Price = 621.20,
            };
            FakeDB.Pets.Add(pet3);
            
            var pet4 = new Pet()
            {
                Id = FakeDB.petId++,
                Name = "Tisdfgfka",
              //  PetType = _petTypeService.NewPetType("Chihhgwsfuaha"),
                BirthDate = Convert.ToDateTime("1999.01.01"),
                SoldDate = Convert.ToDateTime("1999.02.02"),
                Color = "Hybrid",
                Price = 221.20,
                Customer = new Customer()
                {
                    FirstName = "asdfasdf",
                    LastName = "asdfasdf",
                    Address = "sdfasdfa",
                    PhoneNumber = "asdfasdf",
                    Pets = new List<Pet>()
                    {
                        Create(new Pet()
                        {
                            Name = "sdfadfa",
                        }),
                        Create(new Pet()
                        {
                            Name = "asdfasdf"
                        })
                    }
                }
            };
            FakeDB.Pets.Add(pet4);
            
            var pet5 = new Pet()
            {
                Id = FakeDB.petId++,
                Name = "Tikaa",
              //  PetType = _petTypeService.NewPetType("sadfa"),
                BirthDate = Convert.ToDateTime("1999.01.01"),
                SoldDate = Convert.ToDateTime("1999.02.02"),
                Color = "Hybrid",
                Price = 121.20
            };
            FakeDB.Pets.Add(pet5);
            
            var pet6 = new Pet()
            {
                Id = FakeDB.petId++,
                Name = "Tika",
              //  PetType = _petTypeService.NewPetType("Chihuaha"),
                BirthDate = Convert.ToDateTime("1999.01.01"),
                SoldDate = Convert.ToDateTime("1999.02.02"),
                Color = "Hybrid",
                Price = 921.20
            };
            FakeDB.Pets.Add(pet6);
        }

        public IEnumerable<Pet> ReadAll()
        {
            return FakeDB.Pets;
        }

        public Pet Create(Pet pet)
        {
            pet.Id = FakeDB.id++;
            FakeDB.Pets.Add(pet);
            return pet;
        }

        public Pet Delete(int id)
        {
            var petFound = this.ReadById(id);

            if (petFound != null)
            {
                FakeDB.Pets.Remove(petFound);
                return petFound;
            }

            return null;
        }

        public Pet ReadById(int id)
        {
            foreach (var pet in FakeDB.Pets)
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