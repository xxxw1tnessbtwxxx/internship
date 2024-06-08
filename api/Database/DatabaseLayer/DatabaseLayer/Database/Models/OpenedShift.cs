namespace DatabaseLayer.Database.Models
{
    public class OpenedShift
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public DateTime OpenDate { get; set; } = DateTime.Now;
        public DateTime? CloseDate { get; set; }

        public Guid TradePointId { get; set; }
        public virtual TradePoint? TradePoint { get; set; }

    }



}
