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
            builder.HasKey(e => e.ID);

            builder.HasOne(e => e.Gender)
                .WithMany(g => g.Employees)
                .HasForeignKey(e => e.GenderID)
                .OnDelete(DeleteBehavior.Cascade);

            

        }
    }



}
