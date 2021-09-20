using System.Collections.Generic;
using EASV_PetShop.Core.Entity;

namespace EASV_PetShop.Core.ApplicationService
{
    public interface IOwnerService
    {
        Owner NewOwner(string firsName, string lastName, string address, string phoneNumber, string email);
        Owner CreateOwner(Owner owner);
        Owner FindOwnerById(int id);
        List<Owner> GetAllOwner();
        public List<Owner> GetAllByFirstName(string name);
        Owner UpdateOwner(Owner ownerUpdate);
        Owner DeleteOwner(int id);
    }
}