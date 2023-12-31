﻿using Microsoft.AspNetCore.Mvc;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Services.Interfaces;

namespace RestWithASPNETUdemy.Services
{
    public class PersonService : IPersonService
    {
        private volatile int count;

        public Person Create(Person person)
        {
            return person;
        }

        [HttpDelete]
        public void Delete(long id)
        {
            
        }

        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();
            for (int i = 0; i < 8; i++)
            {
                Person person = MockPerson(i);
                persons.Add(person);
            }

            return persons;
        }

        public Person FindById(long id)
        {
            return new Person
            {
                Id = 1,
                FirstName = "Cassius",
                LastName = "Torres",
                Address = "Nova Lima - Minas Gerais",
                Gender = "Male"
            };
        }

        [HttpPut]
        public Person Update(Person person)
        {
            return person;
        }

        private Person MockPerson(int i)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = $"Person Name {i}",
                LastName = $"Person LastName {i}",
                Address = $"Some Address {i}",
                Gender =  i % 1 == 0 ? "Male" : "Female"
            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }
    }
}
