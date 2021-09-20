using System.Collections.Generic;
using EASV_PetShop.Core.DomainService;
using EASV_PetShop.Core.Entity;

namespace ClassLibrary1Infrastructure.Repositories
{
    public class OwnerRepository: IOwnerRepository
    {
        private static int _id = 1;
        private static readonly List<Owner> owners = new List<Owner>();
        
        public Owner Create(Owner owner)
        {
            owner.Id = _id++;
            owners.Add(owner);
            return owner;
        }

        public Owner ReadById(int id)
        {
            foreach (var owner in owners)
            {
                if (owner.Id == id)
                {
                    return owner;
                }
            }

            return null;
        }

        public IEnumerable<Owner> ReadAll()
        {
            return owners;
        }

        public Owner Update(Owner ownerUpdate)
        {
            var ownerFromDb = this.ReadById(ownerUpdate.Id);
            if (ownerFromDb != null)
            {
                ownerFromDb.FirstName = ownerUpdate.FirstName;
                ownerFromDb.LastName = ownerUpdate.LastName;
                ownerFromDb.Address = ownerUpdate.Address;
                ownerFromDb.Email = ownerUpdate.Email;
                ownerFromDb.PhoneNumber = ownerUpdate.PhoneNumber;
                return ownerFromDb;
            }

            return null;
        }

        public Owner Delete(int id)
        {
            var ownerFound = this.ReadById(id);

            if (ownerFound != null)
            {
                owners.Remove(ownerFound);
                return ownerFound;
            }

            return null;
        }
    }
}