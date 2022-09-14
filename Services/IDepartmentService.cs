using CrudAPI.Models;
using System.Collections.Generic;

namespace CrudAPI.Services
{
    public interface IDepartmentService
    {
        public IEnumerable<Department> GetDeparments();
    }
}
