using CrudAPI.Models;
using System.Collections.Generic;

namespace CrudAPI.Services
{
    public class PeopleService : IPersonService
    {
        List<Person> list = new List<Person>() {
           new Person(){ Sno=1,Name= "Joseph", City="Paris"},
           new Person(){ Sno=2,Name="Justin", City="Sydney"},
           new Person() { Sno=3, Name="Eric", City="Berlin"}
        };

     

        public IEnumerable<Person> GetPeople() {



            return list;
        }

        public void Add(Person person)
        {
            list.Add(person);
        }

        public Person Get(int sno)
        {
            foreach (Person person in list) { 
              if(person.Sno == sno)
                    return person;
             
            }
            return null;
        }

        public bool Delete(Person p)
        {
         
            list.Remove(p);
            return true;
        }
    }
}
