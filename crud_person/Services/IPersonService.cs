using crud_person.Model;

namespace crud_person.Services
{
    public interface IPersonService
    {
        Person Create(Person person);
        void Update();
        Person FindByID(long id);
        List<Person> FindAll();
        void Delete(long id);
    }
}