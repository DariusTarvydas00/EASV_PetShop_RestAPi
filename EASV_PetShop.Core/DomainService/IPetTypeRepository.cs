using EASV_PetShop.Core.Entity;

namespace EASV_PetShop.Core.DomainService
{
    public interface IPetTypeRepository
    {
        PetType Create(PetType petType);
        PetType GetPetType(string petType);
    }
}