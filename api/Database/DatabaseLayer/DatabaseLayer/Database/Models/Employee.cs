using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DatabaseLayer.Database.Models
{
    public class Employee
    {

        public Guid ID { get; set; } = Guid.NewGuid();

        public string Login { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string? Surname { get; set; }
        public string? Name { get; set; }
        public string? Patronymic { get; set; }
        public string? PhoneNumber { get; set; }

        public int GenderID { get; set; }
        public virtual Gender? Gender { get; set; }
        public virtual Access? Access { get; set; }
    }
}
