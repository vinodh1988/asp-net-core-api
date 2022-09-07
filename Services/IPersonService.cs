using CrudAPI.Models;
using System.Collections.Generic;

namespace CrudAPI.Services
{
    public interface IPersonService
    {
        public IEnumerable<Person> GetPeople();

    }
}
