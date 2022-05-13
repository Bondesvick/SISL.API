//using System;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata;

//#nullable disable

//namespace SISL.Infrastructure.Models
//{
//    public partial class ModelContext : DbContext
//    {
//        public ModelContext()
//        {
//        }

//        public ModelContext(DbContextOptions<ModelContext> options)
//            : base(options)
//        {
//        }

//        public virtual DbSet<Profile> Profiles { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseOracle("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=XEPDB1)));User Id=SYSTEM;Password=bondesvick");
//            }
//        }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            modelBuilder.HasAnnotation("Relational:Collation", "USING_NLS_COMP");

//            modelBuilder.Entity<Profile>(entity =>
//            {
//                entity.ToTable("PROFILE");

//                entity.Property(e => e.Id)
//                    .HasColumnType("NUMBER")
//                    .HasColumnName("ID");

//                entity.Property(e => e.Firstname)
//                    .HasMaxLength(50)
//                    .IsUnicode(false)
//                    .HasColumnName("FIRSTNAME");

//                entity.Property(e => e.Lastname)
//                    .HasMaxLength(50)
//                    .IsUnicode(false)
//                    .HasColumnName("LASTNAME");

//                entity.Property(e => e.Othernames)
//                    .HasMaxLength(50)
//                    .IsUnicode(false)
//                    .HasColumnName("OTHERNAMES");
//            });

//            modelBuilder.HasSequence("LOGMNR_DIDS$");

//            modelBuilder.HasSequence("LOGMNR_EVOLVE_SEQ$");

//            modelBuilder.HasSequence("LOGMNR_SEQ$");

//            modelBuilder.HasSequence("LOGMNR_UIDS$").IsCyclic();

//            modelBuilder.HasSequence("MVIEW$_ADVSEQ_GENERIC");

//            modelBuilder.HasSequence("MVIEW$_ADVSEQ_ID");

//            modelBuilder.HasSequence("ROLLING_EVENT_SEQ$");

//            OnModelCreatingPartial(modelBuilder);
//        }

//        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
//    }
//}