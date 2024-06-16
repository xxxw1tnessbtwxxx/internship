using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseLayer.Database.Models.Configuration
{
    public class OpenedShiftConfiguration : IEntityTypeConfiguration<OpenedShift>
    {
        public void Configure(EntityTypeBuilder<OpenedShift> builder)
        {
            builder.HasKey(o => o.Id);

            builder.HasOne(o => o.TradePoint)
                .WithMany(t => t.OpenedShifts)
                .HasForeignKey(o => o.TradePointID);

            builder.Property(o => o.OpenedDate).HasColumnType("timestamp without time zone");
        }
    }


}
