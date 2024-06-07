using System.Text.Json.Serialization;

namespace DatabaseLayer.Database.Models
{
    public class TradePoint
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;

        [JsonIgnore]
        public virtual List<Employee>? Employees { get; set; }

    }
}
