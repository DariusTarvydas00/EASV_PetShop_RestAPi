using System;
using System.Collections.Generic;
using EASV_PetShop.Core.ApplicationService;
using EASV_PetShop.Core.Entity;

namespace EASV_PetShop.UI
{
    public class Printer: IPrinter
    {

        private readonly ICustomerService _customerService;
        private readonly IPetService _petService;
        private readonly IPetTypeService _petTypeService;
        private readonly IOwnerService _ownerService;
        private string[] _currentMenu;

        #region stringMenuItems
        
        private readonly string[] _mainMenu =
        {
            "Customer Menu:",
            "Pet Menu:",
            "Exit"
        };
        
        private readonly string[] _customerMenuItems =
        {
            "Show list of all Customers:",
            "Search Customer by Id:",
            "Create new Customer:",
            "Remove Customer:",
            "Update Customer information:",
            "Sort Customers by Name:",
            "Go Back"
        };

        private readonly string[] _petMenuItems =
        {
            "Show list of all Pets:",
            "Search Pets by Type:",
            "Add a new Pet:",
            "Remove Pet:",
            "Update Pet information:",
            "Sort Pets by Price:",
            "Get 5 cheapest available Pets:",
            "Go Back"
        };

        #endregion
        
        public Printer(ICustomerService customerService, IPetService petService, IPetTypeService petTypeService, IOwnerService ownerService)
        {
            _ownerService = ownerService;
            _customerService = customerService;
            _petService = petService;
            _petTypeService = petTypeService;
            _currentMenu = _mainMenu;
            InitData();
        }

        #region StartUI
        
        public void StartUi()
        {
            var selection = ShowMenu(_currentMenu);

            while (selection != 3 && _currentMenu == _mainMenu)
            {
                Console.Clear();
                switch (selection)
                {
                    case 1 :
                        _currentMenu = _customerMenuItems;
                        if (_currentMenu == _customerMenuItems)
                        {
                            selection = ShowMenu(_currentMenu);
                            while (selection != 7)
                            {
                                CustomerMenu(selection);
                                break;
                            }
                        }
                        break;
                    case 2 :
                        _currentMenu = _petMenuItems;
                        if (_currentMenu == _petMenuItems)
                        {
                            selection = ShowMenu(_currentMenu);
                            while (selection != 8)
                            {
                                PetMenu(selection);
                                break;
                            }
                        }
                        break;
                }

                _currentMenu = _mainMenu;
                selection = ShowMenu(_currentMenu);
            }
        }

        private int ShowMenu(string[] menuItems)
        {
            Console.WriteLine("Select what you want to do:\n ");
            for (int i = 0; i < menuItems.Length; i++)
            {
                Console.WriteLine($"{i+1}. {menuItems[i]}");
            }

            int selection;
            while (!int.TryParse(Console.ReadLine(), out selection) || selection > menuItems.Length || selection < 1)
            {
                Console.WriteLine("You need to select a number!");
            }
            return selection;
        }
        
        #endregion

        #region CustomerMenu
        
        private void CustomerMenu(int selection)
        {
            Console.Clear();
            _currentMenu = _customerMenuItems;
            switch (@selection)
            {
                case 1 :
                    ListCustomers();
                    break;
                case 2 :
                    var foundCustomer = _customerService.FindCustomerById(PrintFindById());
                    Console.WriteLine(foundCustomer.FirstName);
                    break;
                case 3 :
                    var firsName = AskQuestion("First Name:");
                    var lastName = AskQuestion("Last Name:");
                    var address = AskQuestion("Address:");
                    var phoneNumber = AskQuestion("Phone Number:");
                    var email = AskQuestion("Email:");
                    var customer = _customerService.NewCustomer(firsName, lastName, address, phoneNumber, email);
                    _customerService.CreateCustomer(customer);
                    break;
                case 4 :
                    var id = PrintFindById();
                    _customerService.DeleteCustomer(id);
                    break;
                case 5 :
                    var idForEdit = PrintFindById();
                    var customerToEdit = _customerService.FindCustomerById(idForEdit);
                    Console.WriteLine("Updating " + customerToEdit.FirstName);
                    var newFirsName = AskQuestion("First Name:");
                    var newLastName = AskQuestion("Last Name:");
                    var newAddress = AskQuestion("Address:");
                    var newPhoneNumber = AskQuestion("Phone Number:");
                    var newEmail = AskQuestion("Email:");
                    _customerService.UpdateCustomer(new Customer()
                    {
                        Id = idForEdit,
                        FirstName = newFirsName,
                        LastName = newLastName,
                        Address = newAddress,
                        PhoneNumber = newPhoneNumber,
                        Email = newEmail
                    });
                    break;
                case 6 :
                    var customerName = AskQuestion("Name:");
                    ListCustomersByName(customerName);
                    break;
            }
        }
        
        #endregion

        #region PetMenu
        
        private void PetMenu(int selection)
        {
            Console.Clear();
            _currentMenu = _petMenuItems;
            switch (selection)
            {
                case 1 :
                    ListPets();
                    break;
                case 2 :
                    ListPetsByType(AskQuestion("Pet Type: "));
                    break;
                case 3 :
                    var name = AskQuestion("Name:");
                    PetType type = _petTypeService.NewPetType(AskQuestion("Pet Type:"));
                    DateTime birthdate = Convert.ToDateTime(AskQuestion("Birth Date:"));
                    DateTime soldDate = Convert.ToDateTime(AskQuestion("Sold Date:"));
                    var color = AskQuestion("Color:");
                    double price = Convert.ToDouble(AskQuestion("Price:"));
                    Owner newOwner = _ownerService.CreateOwner(AddOwner()); 
                    var pet = _petService.NewPet(name,type,birthdate,soldDate,color,price,newOwner);
                    _petService.CreatePet(pet);
                    break;
                case 4 :
                    var id = PrintFindById();
                    _petService.DeletePet(id);
                    break;
                case 5 :
                    var idForEdit = PrintFindById();
                    var petToEdit = _petService.FindPetById(idForEdit);
                    Console.WriteLine("Updating " + petToEdit.Name);
                    var newName = AskQuestion("Name:");
                    PetType newPetType = _petTypeService.NewPetType(AskQuestion("Last Name:"));
                    DateTime newBirthDate = Convert.ToDateTime(AskQuestion("Address:"));
                    DateTime newSoldDate = Convert.ToDateTime(AskQuestion("Phone Number:"));
                    var newColor = AskQuestion("Email:");
                    Double newPrice = Convert.ToDouble(AskQuestion("Email:"));
                    Owner previousOwner = _ownerService.CreateOwner(AddOwner());
                    _petService.UpdatePet(new Pet()
                    {
                        Id = idForEdit,
                        Name = newName,
                        PetType = newPetType,
                        BirthDate = newBirthDate,
                        SoldDate = newSoldDate,
                        Color = newColor,
                        Price = newPrice,
                        Owner = previousOwner
                    });
                    break;
                case 6 :
                    ListPetsByPrice();
                    break;
                case 7 :
                    GetFiveCheapestPets();
                    break;
                        
            }
        }

        private Owner AddOwner()
        {
            var previousOwnerFirsName = AskQuestion("First Name:");
            var previousOwnerLastName = AskQuestion("Last Name:");
            var previousOwnerAddress = AskQuestion("Address:");
            var previousOwnerPhoneNumber = AskQuestion("Phone Number:");
            var previousOwnerEmail = AskQuestion("Email:");
            var previousOwner = _ownerService.NewOwner(previousOwnerFirsName,previousOwnerLastName,previousOwnerAddress,previousOwnerPhoneNumber,previousOwnerEmail);
            _ownerService.CreateOwner(previousOwner);
            return previousOwner;
        }

        private void GetFiveCheapestPets()
        {
            Console.WriteLine("\nList Of Five Cheapest Pets:");
            var pets = _petService.GetAllPetsByPrice();
            var cheapestPets = new List<Pet>();
            for (int i = 0; i < 5; i++)
            {
                cheapestPets.Add(pets[i]);
            }
            
            foreach (var pet in cheapestPets)
            {
                Console.WriteLine($"Id:{pet.Id} Name:{pet.Name} Type:{pet.PetType.Name} "+
                                  $"Birthdate:{pet.BirthDate} SoldDate:{pet.SoldDate} Color:{pet.Color} Price:{pet.Price}");
            }
        }

        #endregion

        #region PetPrinter
        
        private void ListPetsByType(string petType)
        {
            Console.WriteLine("\nList Of Pets by Type:");
            var pets = _petService.GetAllPets();
            foreach (var pet in pets)
            {
                if (pet.PetType.Name == petType)
                {
                    Console.WriteLine($"Id:{pet.Id} Name:{pet.Name} Type:{pet.PetType.Name} "+
                                      $"Birthdate:{pet.BirthDate} SoldDate:{pet.SoldDate} Color:{pet.Color} Price:{pet.Price}");
                    
                }
            }
        }
        
        private void ListPets()
        {
            Console.WriteLine("\nList Of Pets:");
            var pets = _petService.GetAllPets();
            foreach (var pet in pets)
            {
                Console.WriteLine($"Id:{pet.Id} Name:{pet.Name} Type:{pet.PetType.Name} "+
                                  $"Birthdate:{pet.BirthDate} SoldDate:{pet.SoldDate} Color:{pet.Color} Price:{pet.Price}");
                if (pet.Owner != null)
                {
                    Console.WriteLine($"Id:{pet.Owner.Id} First Name:{pet.Owner.FirstName} Last Name:{pet.Owner.LastName} "+
                                      $"Customer address:{pet.Owner.Address} Email:{pet.Owner.Email} Phone number:{pet.Owner.PhoneNumber}");
                    Console.WriteLine("");
                }
            }
        }
        
        private void ListPetsByPrice()
        {
            Console.WriteLine("\nList Of Pets:");
            var pets = _petService.GetAllPetsByPrice();
            foreach (var pet in pets)
            {
                Console.WriteLine($"Id:{pet.Id} Name:{pet.Name} Type:{pet.PetType.Name} "+
                                  $"Birthdate:{pet.BirthDate} SoldDate:{pet.SoldDate} Color:{pet.Color} Price:{pet.Price}");
            }
        }
        
        #endregion

        #region CustomerPrinter

        private void ListCustomers()
        {
            Console.WriteLine("\nList Of Customers:");
            var customers = _customerService.GetAllCustomers();
            foreach (var customer in customers)
            {
                Console.WriteLine($"Id:{customer.Id} First Name:{customer.FirstName} Last Name:{customer.LastName} "+
                                  $"Customer address:{customer.Address} Email:{customer.Email} Phone number:{customer.PhoneNumber}");
            }
        }

        private void ListCustomersByName(string name)
        {
            Console.WriteLine("\nList Of Customers:");
            var customers = _customerService.GetAllCustomers();
            foreach (var customer in customers)
            {
                if (customer.FirstName == name)
                {
                    Console.WriteLine($"Id:{customer.Id} First Name:{customer.FirstName} Last Name:{customer.LastName} "+
                                      $"Customer address:{customer.Address} Email:{customer.Email} Phone number:{customer.PhoneNumber}");
                }
            }
        }

        private int PrintFindById()
        {
            Console.WriteLine("Insert Customer Id: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Please insert a number");
            }

            return id;
        }
        
        #endregion

        static string AskQuestion(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }

        #region DataInitialization

        private void InitData()
        {
            _customerService.CreateCustomer( new Customer
            {
                FirstName = "Bob",
                LastName = "Dylan",
                Address = "Bongo street 22",
                Email = "Bob@Dylan.com",
                PhoneNumber = "123456789"
            });

            _customerService.CreateCustomer( new Customer
            {
                FirstName = "Ding",
                LastName = "Kong",
                Address = "Chris Cross street 41",
                Email = "Donk@Kong.com",
                PhoneNumber = "987654321"
            });

            _petService.CreatePet(new Pet()
            {
                Name = "Kaira",
                PetType = _petTypeService.NewPetType("Vokietis"),
                BirthDate = Convert.ToDateTime("1999.01.01"),
                SoldDate = Convert.ToDateTime("1999.02.02"),
                Color = "Black",
                Price = 421.20,
                Owner = _ownerService.CreateOwner(new Owner()
                {
                    FirstName = "Ding",
                    LastName = "Kong",
                    Address = "Chris Cross street 41",
                    Email = "Donk@Kong.com",
                    PhoneNumber = "987654321" 
                })
            });
            
            _petService.CreatePet( new Pet()
            {
                Name = "Enzo",
                PetType = _petTypeService.NewPetType("Atejunas"),
                BirthDate = Convert.ToDateTime("1999.01.01"),
                SoldDate = Convert.ToDateTime("1999.02.02"),
                Color = "Hybrid",
                Price = 821.20
            });
            
            _petService.CreatePet( new Pet()
            {
                Name = "Tidfsgka",
                PetType = _petTypeService.NewPetType("asd"),
                BirthDate = Convert.ToDateTime("1999.01.01"),
                SoldDate = Convert.ToDateTime("1999.02.02"),
                Color = "Hybrid",
                Price = 621.20,
                Owner = _ownerService.CreateOwner(new Owner()
                {
                FirstName = "Ding",
                LastName = "Kong",
                Address = "Chris Cross street 41",
                Email = "Donk@Kong.com",
                PhoneNumber = "987654321" 
            })
            });
            
            _petService.CreatePet( new Pet()
            {
                Name = "Tisdfgfka",
                PetType = _petTypeService.NewPetType("Chihhgwsfuaha"),
                BirthDate = Convert.ToDateTime("1999.01.01"),
                SoldDate = Convert.ToDateTime("1999.02.02"),
                Color = "Hybrid",
                Price = 221.20
            });
            
            _petService.CreatePet( new Pet()
            {
                Name = "Tikaa",
                PetType = _petTypeService.NewPetType("sadfa"),
                BirthDate = Convert.ToDateTime("1999.01.01"),
                SoldDate = Convert.ToDateTime("1999.02.02"),
                Color = "Hybrid",
                Price = 121.20
            });
            
            _petService.CreatePet( new Pet()
            {
                Name = "Tika",
                PetType = _petTypeService.NewPetType("Chihuaha"),
                BirthDate = Convert.ToDateTime("1999.01.01"),
                SoldDate = Convert.ToDateTime("1999.02.02"),
                Color = "Hybrid",
                Price = 921.20
            });
        }
        
        #endregion
    }
}