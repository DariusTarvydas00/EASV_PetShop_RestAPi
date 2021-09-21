using System.Collections.Generic;
using EASV_PetShop.Core.ApplicationService;
using EASV_PetShop.Core.Entity;
using Microsoft.AspNetCore.Mvc;

namespace EASV_PetShop_RestAPi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PetController : ControllerBase
    {
        private readonly IPetService _petService;

        public PetController(IPetService petService)
        {
            _petService = petService;
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<Pet>> Get()
        {
            return _petService.GetAllPets();
        }
        
        [HttpGet("{id}")]
        public ActionResult<Pet> Get(int id)
        {
            return _petService.FindPetById(id);
        }

        [HttpPut("{id}")]
        public ActionResult<Pet> Put(int id, [FromBody] Pet pet)
        {
            if (id < 1 || id != pet.Id)
            {
                return BadRequest("Parameter Id and Pet Id must be same");
            }

            return Ok(_petService.UpdatePet(pet));
        }

        [HttpPost]
        public ActionResult<Pet> Post([FromBody] Pet pet)
        {
            if (string.IsNullOrEmpty(pet.Name))
            {
                return BadRequest("Name is required");
            }

            return _petService.CreatePet(pet);
        }

        [HttpDelete("{id}")]
        public ActionResult<Pet> Delete(int id)
        {
            var pet = _petService.DeletePet(id);
            if (pet == null)
            {
                return StatusCode(404, "Did not find pet with" + id);
            }

            return Ok($"Pet with Id: {id} is Deleted");
        }

    }
}