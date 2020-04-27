namespace CouchbaseSample.Models
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Couchbase.Core;
    using Couchbase.Extensions.DependencyInjection;
    using Couchbase.N1QL;

    public class PeopleRepository : IPeopleRepository
    {
        private readonly IBucket peopleBucket;
        public PeopleRepository(IBucketProvider provider)
        {
            this.peopleBucket = provider.GetBucket("people-sample");
        }

        public async Task Create(Person newPerson)
        {
            var doc = new Couchbase.Document<Person>
            {
                Content = newPerson,
                Id = newPerson.Id
            };

            await peopleBucket.InsertAsync(doc);
        }

        public async Task Delete(string personId)
        {
            await this.peopleBucket.RemoveAsync(personId);
        }

        public async Task<IEnumerable<Person>> List()
        {
            var query = new QueryRequest("SELECT META().id, firstname, lastname from `people-sample`");
            return await this.peopleBucket.QueryAsync<Person>(query);
        }

        public async Task<Person> Read(string personId)
        {
            var person = await this.peopleBucket.GetAsync<Person>(personId);
            return person.Value;
        }

        public async Task Update(Person person)
        {
            var personDocument = new Couchbase.Document<Person>
            {
                Content = person,
                Id = person.Id
            };

            await this.peopleBucket.UpsertAsync<Person>(personDocument);
        }
    }
}