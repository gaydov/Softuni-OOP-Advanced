using System;
using System.Collections.Generic;
using System.Linq;

namespace ExtendedDatabase.Models
{
    public class Db
    {
        private readonly IList<Person> people;

        public Db(params Person[] inputItems)
        {
            this.people = new List<Person>(inputItems);
        }

        // Indexer for the database
        public Person this[int i]
        {
            get { return this.people[i]; }
        }

        public void Add(Person person)
        {
            if (this.people.Any(p => p.Username.Equals(person.Username)))
            {
                throw new InvalidOperationException("Person with this username already exists.");
            }

            if (this.people.Any(p => p.Id == person.Id))
            {
                throw new InvalidOperationException("Person with this ID already exists.");
            }

            this.people.Add(person);
        }

        public void Remove()
        {
            if (this.people.Count == 0)
            {
                throw new InvalidOperationException("The database is already empty.");
            }

            this.people.Remove(this.people.Last());
        }

        public Person FindByUsername(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentNullException("Empty username provided.");
            }

            if (!this.people.Any(p => p.Username.Equals(username)))
            {
                throw new InvalidOperationException("No person with this username was found.");
            }

            return this.people.First(p => p.Username.Equals(username));
        }

        public Person FindById(long id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException("Id should be positive number.");
            }

            if (!this.people.Any(p => p.Id == id))
            {
                throw new InvalidOperationException("Person with this ID was not found.");
            }

            return this.people.First(p => p.Id == id);
        }
    }
}