using CrudAPI.Models;
using System;
using System.Collections.Generic;

namespace CrudAPI.Services
{
    public interface IPersonService
    {
        public IEnumerable<Person> GetPeople();
        public void Add(Person person);
        public Person Get(int sno);

        public Boolean Delete(Person p);
    }
}
