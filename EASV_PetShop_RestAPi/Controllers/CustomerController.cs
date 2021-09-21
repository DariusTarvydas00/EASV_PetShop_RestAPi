using System.Collections.Generic;
using EASV_PetShop.Core.ApplicationService;
using EASV_PetShop.Core.Entity;
using Microsoft.AspNetCore.Mvc;

namespace EASV_PetShop_RestAPi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Customer>> Get()
        {
            return _customerService.GetAllCustomers();
        }

        [HttpGet("{id}")]
        public ActionResult<Customer> Get(int id)
        {
            return _customerService.FindCustomerByIdIncludeOrders(id);
        }

        [HttpPut("{id}")]
        public ActionResult<Customer> Put(int id, [FromBody] Customer customer)
        {
            if (id < 1 || id != customer.Id)
            {
                return BadRequest("Parameter Id and Customer Id must be same");
            }

            return Ok(_customerService.UpdateCustomer(customer));
        }

        [HttpPost]
        public ActionResult<Customer> Post([FromBody] Customer customer)
        {
            if (string.IsNullOrEmpty(customer.FirstName))
            {
                return BadRequest("First Name is required");
            }

            return _customerService.CreateCustomer(customer);
        }

        [HttpDelete("{id}")]
        public ActionResult<Customer> Delete(int id)
        {
            var customer = _customerService.DeleteCustomer(id);
            if (customer == null)
            {
                return StatusCode(404, "Did not find customer with" + id);
            }

            return Ok($"Customer with Id: {id} is Deleted");
        }
    }
}