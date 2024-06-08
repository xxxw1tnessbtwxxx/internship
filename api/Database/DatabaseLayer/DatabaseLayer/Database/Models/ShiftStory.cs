namespace DatabaseLayer.Database.Models
{
    public class ShiftStory
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid TradePointId { get; set; }
        public virtual TradePoint? TradePoint { get; set; }
        public Guid EmployeeId { get; set; }
        public virtual Employee? Employee { get; set; }

        public DateTime ComeDate { get; set; } = DateTime.Now;
        public DateTime? LeaveDate { get; set; }

    }




}
