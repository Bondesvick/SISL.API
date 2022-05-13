using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SISL.Core.Entities;

namespace SISL.Infrastructure.Configurations
{
    public class SislHistoryConfiguration : IEntityTypeConfiguration<SislHistory>
    {
        public void Configure(EntityTypeBuilder<SislHistory> builder)
        {
            //throw new NotImplementedException();
            builder.ToTable("SISL_HISTORY", "MISUSER");

            builder.HasKey(t => t.Id);

            builder.Property(e => e.Id)
                //.HasColumnType("NUMBER")
                .HasColumnName("ID");
            //.ValueGeneratedOnAdd();

            builder.Property(e => e.CustomerAccountId)
                //.HasColumnType("NUMBER")
                .HasColumnName("CUSTOMER_REQUEST_ID")
                .IsRequired();

            builder.Property(e => e.RequestId)
                .HasColumnName("REQUEST_ID")
                .HasMaxLength(50);

            builder.Property(e => e.Comment)
                .HasColumnName("COMMENT")
                .HasMaxLength(500);

            builder.Property(e => e.CommentDate)
                //.HasColumnType("DATE")
                .HasColumnName("COMMENT_DATE");

            builder.Property(e => e.CommentBy)
                .HasColumnName("COMMENT_BY")
                .HasMaxLength(100);

            builder.Property(e => e.LastUpdatedBy)
                .HasColumnName("LAST_UPDATED_BY")
                .HasMaxLength(100);

            builder.HasOne(d => d.CustomerAccount)
                .WithMany(p => p.SislHistories)
                .HasForeignKey(d => d.CustomerAccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SISL_HISTORY_ACCOUNT");
        }
    }
}