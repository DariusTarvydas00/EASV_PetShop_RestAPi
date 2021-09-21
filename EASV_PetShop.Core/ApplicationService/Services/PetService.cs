using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EASV_PetShop.Core.DomainService;
using EASV_PetShop.Core.Entity;

namespace EASV_PetShop.Core.ApplicationService.Services
{
    public class PetService: IPetService
    {
        readonly IPetRepository _petRepository;
        readonly ICustomerRepository _customerRepository;

        public PetService(IPetRepository petRepository, ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
            _petRepository = petRepository;
        }

        public List<Pet> GetAllPets()
        {
            return _petRepository.ReadAll().ToList();
        }

        public Pet CreatePet(Pet pet)
        {
            if (pet.Customer == null || pet.Customer.Id <= 0)
            {
                throw new InvalidDataException("To create Pet you need a Customer");
            }

            if (_customerRepository.ReadById(pet.Customer.Id) == null)
            {
                throw new InvalidDataException("Customer not Found");
            }

            return _petRepository.Create(pet);
        }

        public Pet NewPet(string name, PetType type, DateTime birthdate, DateTime soldDate, string color, double price, Customer customer)
        {
            var pet = new Pet()
            {
                Name = name,
                PetType = type,
                BirthDate = birthdate,
                SoldDate = soldDate,
                Color = color,
                Price = price
            };

            return pet;
        }

        public Pet DeletePet(int id)
        {
            return _petRepository.Delete(id);
        }

        public Pet FindPetById(int idForEdit)
        {
            return _petRepository.ReadById(idForEdit);
        }

        public Pet UpdatePet(Pet petUpdate)
        {
            var pet = FindPetById(petUpdate.Id);
            pet.Name = petUpdate.Name;
            pet.PetType = petUpdate.PetType;
            pet.BirthDate = petUpdate.BirthDate;
            pet.SoldDate = petUpdate.SoldDate;
            pet.Color = petUpdate.Color;
            pet.Price = petUpdate.Price;
            return pet;
        }

        public List<Pet> GetAllPetsByPrice()
        {
            var list = _petRepository.ReadAll();
            var queryContinued = list.OrderBy(pet => pet.Price);
            return queryContinued.ToList();
        }

        public IEnumerable<Pet> GetPetsByType(string petType)
        {
            var list = _petRepository.ReadAll();
            var queryContinued = list.Where(customer => customer.PetType.Equals(petType));
            return queryContinued;
        }
    }
}