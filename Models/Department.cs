using System.Collections.Generic;

namespace CrudAPI.Models
{
    public class Department
    {
        public int Dno { get; set; }
        public string Name { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
