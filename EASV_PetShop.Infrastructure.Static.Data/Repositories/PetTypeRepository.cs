using System.Collections.Generic;
using EASV_PetShop.Core.DomainService;
using EASV_PetShop.Core.Entity;

namespace ClassLibrary1Infrastructure.Repositories
{
    public class PetTypeRepository: IPetTypeRepository
    {
        private static int _id = 1;
        private static readonly List<PetType> PetTypes = new List<PetType>();
        private IPetTypeRepository _petTypeRepositoryImplementation;

        public PetType Create(PetType petType)
        {
            petType.Id = _id++;
            PetTypes.Add(petType);
            return petType;
        }

        public PetType GetPetType(string petTypeName)
        {
            foreach (var petType in PetTypes)
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