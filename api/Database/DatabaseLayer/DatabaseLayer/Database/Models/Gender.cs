using System.Text.Json.Serialization;

namespace DatabaseLayer.Database.Models
{
    public class Gender
    {
        public int ID { get; set; }
        public string? Name { get; set; }


        [JsonIgnore]
        public virtual List<Employee>? Employees { get; set; }
    }
}
