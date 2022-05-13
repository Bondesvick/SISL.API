using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SISL.Core.Entities;

namespace SISL.Infrastructure.Configurations
{
    public class SislDocumetConfigurations : IEntityTypeConfiguration<SislDocument>
    {
        public void Configure(EntityTypeBuilder<SislDocument> entity)
        {
            entity.ToTable("SISL_DOCS", "MISUSER");

            entity.HasKey(t => t.Id);

            entity.Property(e => e.Id)
                .HasColumnName("ID");

            entity.Property(e => e.CustomerAccountId)
                //.HasColumnType("NUMBER")
                .HasColumnName("CUSTOMER_ACCOUNT_ID")
                .IsRequired();

            entity.Property(e => e.ContentOrPath)
                .IsRequired()
            .HasColumnName("CONTENT_OR_PATH")
            .HasColumnType("CLOB");

            entity.Property(e => e.FileName)
                .IsRequired()
                .HasColumnName("FILE_NAME")
                .HasMaxLength(200);

            entity.Property(e => e.Title)
                .HasColumnName("TITLE")
                .HasMaxLength(250);

            entity.Property(e => e.ContentType)
                .IsRequired()
                .HasColumnName("DOCUMENT_CONTENT_TYPE")
                .HasMaxLength(200);

            entity.HasOne(d => d.CustomerAccount)
                .WithMany(p => p.SislDocuments)
                .HasForeignKey(d => d.CustomerAccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SISL_DOCS_CUSTOMER_ID");
        }
    }
}