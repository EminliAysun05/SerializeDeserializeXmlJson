using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SerializerInClassroom.Models;
using SerializerInClassroom.Services.Abstractions;

namespace SerializerInClassroom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PeopleController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _personService.GetAll();

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create(Person person)
        {
            _personService.Create(person);

            return NoContent();
        }
    }
}
