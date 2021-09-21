using System.Collections.Generic;
using EASV_PetShop.Core.Entity;

namespace ClassLibrary1Infrastructure
{
    public static class FakeDB
    {
        public static int id = 1;
        public static List<Customer> Customers = new List<Customer>();
        
        public static int petId = 1;
        public static List<Pet> Pets = new List<Pet>();
        
        public static int petTypeId = 1;
        public static List<PetType> PetTypes = new List<PetType>();
    }
}