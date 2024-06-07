using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.Database.Models.Configuration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.TradePoint)
                .WithMany(t => t.Employees)
                .HasForeignKey(e => e.TradePointId);
        }
    }
}
