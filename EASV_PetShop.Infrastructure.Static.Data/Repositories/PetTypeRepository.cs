using System.Collections.Generic;
using EASV_PetShop.Core.DomainService;
using EASV_PetShop.Core.Entity;

namespace ClassLibrary1Infrastructure.Repositories
{
    public class PetTypeRepository: IPetTypeRepository
    {

        public PetType Create(PetType petType)
        {
            petType.Id = FakeDB.id++;
            FakeDB.PetTypes.Add(petType);
            return petType;
        }

        public PetType GetPetType(string petTypeName)
        {
            foreach (var petType in FakeDB.PetTypes)
            {
                if (petType.Name.Equals(petType))
                {
                    return petType;
                }
            }

            return null;
        }
    }
}