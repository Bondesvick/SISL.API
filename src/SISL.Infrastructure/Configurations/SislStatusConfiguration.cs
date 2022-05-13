using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SISL.Core.Entities;

namespace SISL.Infrastructure.Configurations
{
    public class SislStatusConfiguration : IEntityTypeConfiguration<SislStatus>
    {
        public void Configure(EntityTypeBuilder<SislStatus> builder)
        {
            builder.ToTable("SISL_STATUS", "MISUSER");

            builder.HasKey(t => t.Id);

            builder.Property(e => e.Id)
                //.HasColumnType("NUMBER")
                .HasColumnName("ID");

            builder.Property(e => e.status)
                .HasColumnName("STATUS")
                .HasMaxLength(50);

            builder.Property(e => e.SislHistoryId)
                //.HasColumnType("NUMBER")
                .HasColumnName("SISL_HISTORY_ID");

            builder.HasOne(d => d.SislHistory)
                .WithOne(p => p.SislStatus)
                .HasForeignKey<SislStatus>(d => d.SislHistoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SISL_HISTORY_STATUS");
        }
    }
}