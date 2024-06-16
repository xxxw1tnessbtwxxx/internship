namespace DatabaseLayer.Database.Models
{
    public class OpenedShift
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid TradePointID { get; set; }
        public virtual TradePoint? TradePoint { get; set; }
        public DateTime OpenedDate { get; set; } = DateTime.Now;
    }
}
