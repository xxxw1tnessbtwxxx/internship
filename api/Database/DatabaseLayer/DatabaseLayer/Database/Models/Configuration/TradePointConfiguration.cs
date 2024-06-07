using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseLayer.Database.Models.Configuration
{
    public class TradePointConfiguration : IEntityTypeConfiguration<TradePoint>
    {
        public void Configure(EntityTypeBuilder<TradePoint> builder)
        {
            builder.HasKey(t => t.Id);

            builder.HasMany(t => t.Employees)
                .WithOne(e => e.TradePoint)
                .HasForeignKey(e => e.TradePointId);
        }
    }
}
