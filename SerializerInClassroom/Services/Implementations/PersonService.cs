using SerializerInClassroom.Models;
using SerializerInClassroom.Services.Abstractions;

namespace SerializerInClassroom.Services.Implementations
{
    public class PersonService : IPersonService
    {
        private readonly ISerializeService<Person> _serializeService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string _filePath;
        public PersonService(ISerializeService<Person> serializeService, IWebHostEnvironment webHostEnvironment)
        {
            _serializeService = serializeService;
            _webHostEnvironment = webHostEnvironment;
            _filePath = Path.Combine(_webHostEnvironment.WebRootPath, "documents", "people.json");
        }

        public void Create(Person person)
        {
            var people = GetAll();

            people.Add(person);

            _serializeService.WriteFile(people, _filePath);
        }

        public void Delete(int id)
        {
            var people = GetAll();

            var person = people.FirstOrDefault(x => x.Id == id);

            if (person is null)
                throw new Exception("Not found");

            people.Remove(person);

            _serializeService.WriteFile(people, _filePath);
        }

        public Person Get(int id)
        {
            var people = GetAll();

            var person = people.FirstOrDefault(x => x.Id == id);

            if (person is null)
                throw new Exception("Not found");

            return person;
        }

        public List<Person> GetAll()
        {
            var people = _serializeService.ReadFile(_filePath);

            return people;
        }

        public void Update(Person person)
        {
            var people = GetAll();

            var existPerson = people.FirstOrDefault(x => x.Id == person.Id);

            if (existPerson is null)
                throw new Exception("Not found");

            existPerson = person;

            _serializeService.WriteFile(people, _filePath);
        }
    }
}
