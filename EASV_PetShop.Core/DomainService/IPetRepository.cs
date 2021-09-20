using System.Collections.Generic;
using EASV_PetShop.Core.Entity;

namespace EASV_PetShop.Core.DomainService
{
    public interface IPetRepository
    {
        IEnumerable<Pet> ReadAll();
        Pet Create(Pet pet);
        Pet Delete(int id);
        Pet ReadById(int id);
    }
}