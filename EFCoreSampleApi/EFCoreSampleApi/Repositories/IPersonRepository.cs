using EFCoreSampleApi.Entities.DTOs;             // UserDTO |ishlashi uchun
using EFCoreSampleApi.Entities.Models;           // Person |ishlashi uchun

namespace EFCoreSampleApi.Repositories
{
    public interface IPersonRepository
    {
        public string Create(PersonDTO userDTO);
        public IEnumerable<Person> GetAll();
        public string Update(int id, PersonDTO personDTO);
        public string Delete(int id);
    }
}
