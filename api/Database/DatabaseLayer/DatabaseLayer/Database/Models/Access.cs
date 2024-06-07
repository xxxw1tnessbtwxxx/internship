namespace DatabaseLayer.Database.Models
{
    public class Access
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid TradePointId { get; set; }
        public virtual TradePoint? TradePoint { get; set; }


        public Guid EmployeeId { get; set; }
        public virtual List<Employee>? Employees { get; set; }

    }

}
