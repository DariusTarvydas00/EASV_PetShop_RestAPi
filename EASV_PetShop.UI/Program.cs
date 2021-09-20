
using ClassLibrary1Infrastructure.Repositories;
using EASV_PetShop.Core.ApplicationService;
using EASV_PetShop.Core.ApplicationService.Services;
using EASV_PetShop.Core.DomainService;
using Microsoft.Extensions.DependencyInjection;

namespace EASV_PetShop.UI
{
    internal static class Program
    {
        private static void Main()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<ICustomerRepository, CustomerRepository>();
            serviceCollection.AddScoped<ICustomerService, CustomerService>();
            
            serviceCollection.AddScoped<IPetRepository, PetRepository>();
            serviceCollection.AddScoped<IPetService, PetService>();

            serviceCollection.AddScoped<IPetTypeRepository, PetTypeRepository>();
            serviceCollection.AddScoped<IPetTypeService, PetTypeService>();

            serviceCollection.AddScoped<IOwnerRepository, OwnerRepository>();
            serviceCollection.AddScoped<IOwnerService, OwnerSerivce>();
            
            serviceCollection.AddScoped<IPrinter, Printer>();
            
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var printer = serviceProvider.GetRequiredService<IPrinter>();
            printer.StartUi();
        }
        
    }
}