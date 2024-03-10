using EFCoreSampleApi.Entities.DTOs;             // UserDTO |ishlashi uchun
using EFCoreSampleApi.Entities.Models;           // Person |ishlashi uchun
using EFCoreSampleApi.Persistance;               // ApplicationDbContext | ishlashi uchun

namespace EFCoreSampleApi.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private ApplicationDbContext _context;

        public PersonRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public string Create(PersonDTO userDTO)
        {
                Person person = new Person()
                {
                    Name = userDTO.Name,
                    Age = userDTO.Age,
                };
                _context.Persons.Add(person);
                _context.SaveChanges();

                return "201: Created";
        }

        public string Delete(int id)
        {
            _context.Persons.Remove(_context.Persons.FirstOrDefault(x => x.Id == id)!);
            _context.SaveChanges();
            return "204: Deleted";
        }

        public IEnumerable<Person> GetAll()
        {
            return _context.Persons.ToList();
        }

        public string Update(int id, PersonDTO personDTO)
        {
            Person person = _context.Persons.FirstOrDefault(x => x.Id == id)!;
            person.Name= personDTO.Name;
            person.Age= personDTO.Age;
            _context.Persons.Update(person);
            _context.SaveChanges();

            return "200: Update";
        }
    }
}
