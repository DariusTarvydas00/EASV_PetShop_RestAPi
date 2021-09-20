using System.Collections.Generic;
using System.Linq;
using EASV_PetShop.Core.DomainService;
using EASV_PetShop.Core.Entity;

namespace EASV_PetShop.Core.ApplicationService.Services
{
    public class OwnerSerivce: IOwnerService
    {
        private readonly IOwnerRepository _ownerRepository;

        public OwnerSerivce(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }

        public Owner NewOwner(string firsName, string lastName, string address, string phoneNumber, string email)
        {
            var owner = new Owner()
            {
                FirstName = firsName,
                LastName = lastName,
                Address = address,
                PhoneNumber = phoneNumber,
                Email = email
            };

            return owner;
        }

        public Owner CreateOwner(Owner owner)
        {
            return _ownerRepository.Create(owner);
        }

        public Owner FindOwnerById(int id)
        {
            return _ownerRepository.ReadById(id);
        }

        public List<Owner> GetAllOwner()
        {
            return _ownerRepository.ReadAll().ToList();
        }

        public List<Owner> GetAllByFirstName(string name)
        {
            var list = _ownerRepository.ReadAll();
            var queryContinued = list.Where(customer => customer.FirstName.Equals(name));
            queryContinued = queryContinued.OrderBy(customer => customer.FirstName);
            return queryContinued.ToList();
        }

        public Owner UpdateOwner(Owner ownerUpdate)
        {
            var owner = FindOwnerById(ownerUpdate.Id);
            owner.FirstName = ownerUpdate.FirstName;
            owner.LastName = ownerUpdate.LastName;
            owner.Address = ownerUpdate.Address;
            owner.PhoneNumber = ownerUpdate.PhoneNumber;
            owner.Email = ownerUpdate.Email;
            return owner;
        }

        public Owner DeleteOwner(int id)
        {
            return _ownerRepository.Delete(id);
        }
    }
}