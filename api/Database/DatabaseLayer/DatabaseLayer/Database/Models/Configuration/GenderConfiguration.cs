using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseLayer.Database.Models.Configuration
{
    public class GenderConfiguration : IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            builder.HasKey(g => g.Id);

            builder.HasMany(g => g.Employees)
                .WithOne(e => e.Gender)
                .HasForeignKey(e => e.GenderId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
