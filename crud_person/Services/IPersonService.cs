using crud_person.Model;

namespace crud_person.Services
{
    public interface IPersonService
    {
        Person Create(Person person);
        Person Update(Person person);
        Person FindByID(long id);
        List<Person> FindAll();
        void Delete(long id);
    }
}