using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseLayer.Database.Models.Configuration
{
    public class GenderConfiguration : IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            builder.HasKey(g => g.ID);
            builder.HasMany(g => g.Employees)
                .WithOne(e => e.Gender)
                .HasForeignKey(e => e.GenderID)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }


}
