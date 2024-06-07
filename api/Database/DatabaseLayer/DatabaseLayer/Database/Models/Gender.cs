namespace DatabaseLayer.Database.Models
{
    public class Gender
    {
        public int Id { get; set; }
        public string GenderName { get; set; } = string.Empty;
        public virtual List<Employee>? Employees { get; set; } = [];
    }
}
