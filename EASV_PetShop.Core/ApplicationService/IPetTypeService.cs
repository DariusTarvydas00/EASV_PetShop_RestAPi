using System;
using EASV_PetShop.Core.Entity;

namespace EASV_PetShop.Core.ApplicationService
{
    public interface IPetTypeService
    {
        PetType CreatePetType(PetType petType);

        PetType NewPetType(string name);

        PetType GetPetType(string petType);
    }
}