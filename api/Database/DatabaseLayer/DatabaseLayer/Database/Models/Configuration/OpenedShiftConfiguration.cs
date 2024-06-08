using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseLayer.Database.Models.Configuration
{
    public class OpenedShiftConfiguration : IEntityTypeConfiguration<OpenedShift>
    {
        public void Configure(EntityTypeBuilder<OpenedShift> builder)
        {
            builder.HasKey(o => o.Id);


            builder.HasOne(o => o.TradePoint);

            builder.Property(o => o.OpenDate).HasColumnType("timestamp without time zone");
            builder.Property(o => o.CloseDate).HasColumnType("timestamp without time zone");
        }
    }

}
