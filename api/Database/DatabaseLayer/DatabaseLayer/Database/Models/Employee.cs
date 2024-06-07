using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.Database.Models
{
    public class Employee
    {

        public Guid Id { get; set; } = Guid.NewGuid();

        public string Login { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public string? Surname { get; set; } = string.Empty;
        public string? Name { get; set; } = string.Empty;
        public string? Patronymic { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; } = string.Empty;

        public int? GenderId { get; set; }
        public virtual Gender? Gender { get; set; }
        public Guid? TradePointId { get; set; } = null!;
        public virtual TradePoint? TradePoint { get; set; }


    }

}
