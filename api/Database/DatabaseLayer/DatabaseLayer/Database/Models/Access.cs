using System.Text.Json.Serialization;

namespace DatabaseLayer.Database.Models
{
    public class Access
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid TradePointID { get; set; }
        public virtual TradePoint? TradePoint { get; set; }

        [JsonIgnore]
        public Guid EmployeeID { get; set; }
        [JsonIgnore]
        public virtual Employee? Employee { get; set; }
    }
}
