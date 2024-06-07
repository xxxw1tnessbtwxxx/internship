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
        public string Surname { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Patronymic { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;

        public Guid TradePointId { get; set; }
        public virtual TradePoint? TradePoint { get; set; }


    }
}
