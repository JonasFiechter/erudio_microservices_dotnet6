using crud_person.Model;
// Mocking
namespace crud_person.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        public void Create()
        {
        }

        public void Update()
        {
        }

        public Person FindByID(long id)
        {
            return new Person
            {
                Id = 1,
                FirstName = "Lavre",
                LastName = "Jose",
                Address = "Some st. 122",
                Gender = "Male"
            };
        }

        public string FindAll()
        {
            // List<Person>; persons = new List<Person>();

            // for (int i = 0; i < 9; i++)
            // {
            //     persons.Add(person);
            // }

            return "persons";
        }

        public void Delete(long id)
        {

        }
    }
}