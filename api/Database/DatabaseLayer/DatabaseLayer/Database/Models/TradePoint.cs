namespace DatabaseLayer.Database.Models
{
    public class TradePoint
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        
        public string PointName { get; set; } = string.Empty;

        public virtual List<Employee>? Employees { get; set; } = [];
        
    }
}
