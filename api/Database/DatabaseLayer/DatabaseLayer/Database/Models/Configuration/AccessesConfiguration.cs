using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.Database.Models.Configuration
{
    public class AccessesConfiguration : IEntityTypeConfiguration<Access>
    {
        public void Configure(EntityTypeBuilder<Access> builder)
        {

            builder.HasKey(a => a.Id);

            builder.HasOne(a => a.TradePoint);

            builder.HasMany(a => a.Employees);

        }
    }
}
