using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class PersonRepositories : IPerson
    {
        private List<Person> _repository { get; set; } = new List<Person>
        {
            new Person("samson@gmail.com", "samson123", new Role(RoleType.User.ToString())),
            new Person("daria@gmail.com", "dar123", new Role(RoleType.User.ToString())),
            new Person("sara@gmail.com", "sara123", new Role(RoleType.User.ToString())),
            new Person("bada@gmail.com", "bter12323d", new Role(RoleType.Admin.ToString())),
        };

        public List<Person> GetAll()
        {
            return _repository;
        }

        public Person GetByEmail(string email)
        {
            return _repository.FirstOrDefault(p => p.Email == email);
        }

        public void AddPerson(Person person)
        {
            _repository.Add(person);
        }


    }
}
