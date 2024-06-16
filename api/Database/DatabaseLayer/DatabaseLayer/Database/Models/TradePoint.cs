using System.Text.Json.Serialization;

namespace DatabaseLayer.Database.Models
{
    public class TradePoint
    {
        public Guid ID { get; set; } = Guid.NewGuid();

        public string? PointName { get; set; }

        [JsonIgnore]
        public virtual List<Access>? Accesses { get; set; }

        [JsonIgnore]
        public virtual List<OpenedShift>? OpenedShifts { get; set; }
    }
}
