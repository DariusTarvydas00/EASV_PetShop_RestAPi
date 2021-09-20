using System;
using System.Collections.Generic;
using EASV_PetShop.Core.Entity;

namespace EASV_PetShop.Core.ApplicationService
{
    public interface IPetService
    {
        List<Pet> GetAllPets();
        Pet CreatePet(Pet pet);

        Pet NewPet(string name, PetType type, DateTime birthdate, DateTime soldDate, string color, double price,
            Owner newOwner);
        Pet DeletePet(int id);
        Pet FindPetById(int idForEdit);
        Pet UpdatePet(Pet pet);
        List<Pet> GetAllPetsByPrice();
        IEnumerable<Pet> GetPetsByType(string petType);
    }
}