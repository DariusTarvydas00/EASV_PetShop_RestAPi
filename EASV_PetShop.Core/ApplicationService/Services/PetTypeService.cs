using EASV_PetShop.Core.DomainService;
using EASV_PetShop.Core.Entity;

namespace EASV_PetShop.Core.ApplicationService.Services
{
    public class PetTypeService: IPetTypeService
    {
        private readonly IPetTypeRepository _petTypeRepository;

        public PetTypeService(IPetTypeRepository petTypeRepository)
        {
            _petTypeRepository = petTypeRepository;
        }


        public PetType CreatePetType(PetType petType)
        {
            return _petTypeRepository.Create(petType);
        }

        public PetType NewPetType(string name)
        {
            var petType = new PetType()
            {
                Name = name
            };

            return petType;
        }

        public PetType GetPetType(string petType)
        {
            return _petTypeRepository.GetPetType(petType);
        }
    }
}