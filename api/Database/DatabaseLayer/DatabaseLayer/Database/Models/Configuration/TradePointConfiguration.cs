using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseLayer.Database.Models.Configuration
{
    public class TradePointConfiguration : IEntityTypeConfiguration<TradePoint>
    {
        public void Configure(EntityTypeBuilder<TradePoint> builder)
        {
            builder.HasKey(t => t.ID);
            builder.HasMany(t => t.Accesses)
                .WithOne(a => a.TradePoint)
                .HasForeignKey(a => a.TradePointID)
                .OnDelete(DeleteBehavior.Cascade);


         
        }
    }


}
