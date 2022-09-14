using System.Text.Json.Serialization;

namespace CrudAPI.Models
{
    public class Employee
    {
        public int Eno { get; set; }
        public string Name { get; set; }
        public string City { get; set; }

        public int Dno { get; set; }
        [JsonIgnore]
        public Department Dept { get; set; }
    }
}
