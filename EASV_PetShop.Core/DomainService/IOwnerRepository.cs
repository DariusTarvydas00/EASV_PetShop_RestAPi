using System.Collections.Generic;
using EASV_PetShop.Core.Entity;

namespace EASV_PetShop.Core.DomainService
{
    public interface IOwnerRepository
    {
        Owner Create(Owner customer);
        Owner ReadById(int id);
        IEnumerable<Owner> ReadAll();
        Owner Update(Owner ownerUpdate);
        Owner Delete(int id);
    }
}