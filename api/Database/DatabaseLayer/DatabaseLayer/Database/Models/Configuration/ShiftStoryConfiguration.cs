﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseLayer.Database.Models.Configuration
{
    public class ShiftStoryConfiguration : IEntityTypeConfiguration<ShiftStory>
    {
        public void Configure(EntityTypeBuilder<ShiftStory> builder)
        {
            builder.HasKey(s => s.ID);

            builder.HasOne(s => s.TradePoint);

            builder.HasOne(s => s.Employee);


            builder.Property(s => s.ComeDate).HasColumnType("timestamp without time zone");
            builder.Property(s => s.LeaveDate).HasColumnType("timestamp without time zone");
        }
    }


}
