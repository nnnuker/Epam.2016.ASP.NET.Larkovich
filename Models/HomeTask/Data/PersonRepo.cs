using System;
using HomeTask.Models;
using System.Collections.Generic;

namespace HomeTask.Data
{
    public class PersonRepo : IPersonRepo
	{
		private readonly List<Person> _personRepo;

		public PersonRepo()
		{
			_personRepo = new List<Person>()
			{
				new Person {FirstName = "Guybrush", LastName = "Threepwood", PersonId = 1},
				new Person {FirstName = "Arthas", LastName = "Menethil", PersonId = 2},
				new Person {FirstName = "Illidan", LastName = "Stormrage", PersonId = 3},
				new Person {FirstName = "Falstad", LastName = "Wildhammer", PersonId = 4},
				new Person {FirstName = "Garrosh", LastName = "Hellscream", PersonId = 5},
				new Person {FirstName = "Jaina", LastName = "Proudmoore", PersonId = 6},
			};
		}

        public void Add(Person person)
        {
            person.PersonId = _personRepo.Count + 1;
            _personRepo.Add(person);
        }

        public Person[] GetAll()
		{
			return _personRepo.ToArray();
		}
	}
}