using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    public interface IPerson
    {

        public List<Person> GetAll();
        public Person GetByEmail(string email);

        public void AddPerson(Person person);

    }
}