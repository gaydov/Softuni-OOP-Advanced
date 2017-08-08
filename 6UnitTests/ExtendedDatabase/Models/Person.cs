using System;

namespace ExtendedDatabase.Models
{
    public class Person
    {
        public Person(string username, long id)
        {
            this.Username = username;
            this.Id = id;
        }

        public string Username { get; }

        public long Id { get; }
    }
}