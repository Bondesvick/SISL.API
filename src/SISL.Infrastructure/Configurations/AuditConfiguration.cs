using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SISL.Core.Entities;

namespace SISL.Infrastructure.Configurations
{
    public class AuditConfiguration : IEntityTypeConfiguration<Audit>
    {
        public void Configure(EntityTypeBuilder<Audit> builder)
        {
            builder.ToTable("DRA_AUDIT_LOG", "MISUSER");

            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("ID");

            builder.Property(t => t.ActionType)
                .HasColumnName("ACTION_TYPE")
                .IsRequired()
                .HasMaxLength(15);

            builder.Property(t => t.ActionDate)
                .HasColumnName("ACTION_DATE")
                .IsRequired();

            builder.Property(t => t.ActionBy)
                .HasColumnName("ACTION_BY")
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(t => t.Description)
                .HasColumnName("DESCRIPTION")
                .IsRequired()
                .HasMaxLength(1500);
        }
    }
}