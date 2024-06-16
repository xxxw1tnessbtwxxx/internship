using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseLayer.Database.Models.Configuration
{
    public class AccessConfiguration : IEntityTypeConfiguration<Access>
    {
        public void Configure(EntityTypeBuilder<Access> builder)
        {
            builder.HasKey(a => a.Id);

            builder.HasOne(a => a.TradePoint)
                .WithMany(t => t.Accesses)
                .HasForeignKey(t => t.TradePointID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }


}
