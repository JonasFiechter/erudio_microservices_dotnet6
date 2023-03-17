using crud_person.Model;
// Mocking
namespace crud_person.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        public List<string> persons = new List<string>();
        private volatile int id;
        public Person Create(Person person)
        {
            var temp_id = this.IncrementAndGet();
            this.persons.Add($"new_person {temp_id}");

            Console.WriteLine($"Creating person {temp_id}");
            Console.WriteLine(persons.ToString());
            
            return person;
        }

        public Person Update(Person person)
        {
            return person;
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
            return new List<Person>();
        }

        public void Delete(long id)
        {

        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref id);
        }
    }
}