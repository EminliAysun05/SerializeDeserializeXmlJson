using SerializerInClassroom.Models;

namespace SerializerInClassroom.Services.Abstractions
{
    public interface IPersonService
    {
        void Create(Person person);
        void Update(Person person);
        void Delete(int id);
        List<Person> GetAll();
        Person Get(int id);
    }
}

