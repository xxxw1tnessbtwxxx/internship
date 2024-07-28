using System.Text.Json.Serialization;

namespace DatabaseLayer.Database.Models
{
    public class ShiftStory
    {
        public Guid ID { get; set; } = Guid.NewGuid();
        public DateTime ComeDate { get; set; } = DateTime.Now;
        public DateTime? LeaveDate { get; set; }

        public Guid TradePointID { get; set; }
        public virtual TradePoint? TradePoint { get; set; }
        [JsonIgnore]
        public Guid EmployeeID { get; set; }
        [JsonIgnore]
        public virtual Employee? Employee { get; set; }

    }
}
