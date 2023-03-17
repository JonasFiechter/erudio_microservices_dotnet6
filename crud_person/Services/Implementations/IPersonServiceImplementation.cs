using crud_person.Model;
// Mocking
namespace crud_person.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        public Person Create(Person person)
        {
            return person;
        }

        public void Update()
        {
        }

        public Person FindByID(long id)
        {
            return new Person()
            {
                Id = id,
                FirstName = "Mark",
                LastName = "Mark",
                Address = "Ham st.",
                Gender = "Male"
            };
        }

        public List<Person> FindAll()
        {
            throw new NotImplementedException();
        }

        public void Delete(long id)
        {

        }
    }
}