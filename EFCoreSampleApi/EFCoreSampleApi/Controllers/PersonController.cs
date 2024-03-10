using EFCoreSampleApi.Entities.DTOs;         // PersonDTO |ishlashi uchun
using EFCoreSampleApi.Entities.Models;       // Person |ishlashi uchun
using EFCoreSampleApi.Repositories;          // IPersonRepository |ishlashi uchun
using Microsoft.AspNetCore.Mvc;              // ControllerBase |ishlashi uchun

namespace SampleDBApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _personRepository;

        public PersonController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        [HttpPost]
        public string Create(PersonDTO personDTO)
        {
            return _personRepository.Create(personDTO);
        }

        [HttpGet]
        public IEnumerable<Person> GetAll()
        {
            return _personRepository.GetAll();
        }

        [HttpPut]
        public string Update(int id, PersonDTO personDTO)
        {
            return _personRepository.Update(id, personDTO);
        }

        [HttpDelete]
        public string Delete(int id)
        {
            return _personRepository.Delete(id);
        }
    }
}
