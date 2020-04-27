namespace CouchbaseSample.Models
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IPeopleRepository
    {
        Task Create(Person person);

        Task<Person> Read(string personId);

        Task Update(Person person);

        Task Delete(string personId);

        Task<IEnumerable<Person>> List();
    }
}