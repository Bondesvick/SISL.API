﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;
using SISL.Infrastructure.Data;

namespace SISL.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210514170814_misuser")]
    partial class misuser
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SISL.Core.Entities.Audit", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(19)")
                        .HasColumnName("ID")
                        .HasAnnotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ActionBy")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("NVARCHAR2(20)")
                        .HasColumnName("ACTION_BY");

                    b.Property<DateTime>("ActionDate")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("ACTION_DATE");

                    b.Property<string>("ActionType")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("NVARCHAR2(15)")
                        .HasColumnName("ACTION_TYPE");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1500)
                        .HasColumnType("NVARCHAR2(1500)")
                        .HasColumnName("DESCRIPTION");

                    b.HasKey("Id");

                    b.ToTable("DRA_AUDIT_LOG", "MISUSER");
                });

            modelBuilder.Entity("SISL.Core.Entities.CustomerAccount", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(19)")
                        .HasColumnName("ID")
                        .HasAnnotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccountType")
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR2(50)")
                        .HasColumnName("ACCOUNT_TYPE");

                    b.Property<string>("ApprovedBy")
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR2(50)")
                        .HasColumnName("APPROVED_BY");

                    b.Property<DateTime>("ApprovedDate")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("APPROVED_DATE");

                    b.Property<string>("ApproverIp")
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR2(50)")
                        .HasColumnName("APPROVER_IP");

                    b.Property<string>("BankAccNumber")
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR2(50)")
                        .HasColumnName("BANK_ACCOUNT_NUMBER");

                    b.Property<string>("BankAcctName")
                        .HasMaxLength(200)
                        .HasColumnType("NVARCHAR2(200)")
                        .HasColumnName("BANK_NAME");

                    b.Property<string>("BankCode")
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR2(50)")
                        .HasColumnName("BANK_CODE");

                    b.Property<string>("BranchCode")
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR2(50)")
                        .HasColumnName("BRANCH_CODE");

                    b.Property<string>("City")
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR2(50)")
                        .HasColumnName("CITY");

                    b.Property<string>("CompName")
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR2(50)")
                        .HasColumnName("COMP_NAME");

                    b.Property<string>("Country")
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR2(50)")
                        .HasColumnName("COUNTRY");

                    b.Property<string>("CustAid")
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR2(50)")
                        .HasColumnName("CUSTOMER_ID");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("DATE_OF_BIRTH");

                    b.Property<string>("EmailAddress")
                        .HasMaxLength(200)
                        .HasColumnType("NVARCHAR2(200)")
                        .HasColumnName("EMAIL_ADDRESS");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR2(50)")
                        .HasColumnName("FIRST_NAME");

                    b.Property<string>("InitiatedBy")
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR2(50)")
                        .HasColumnName("INITIATED_BY");

                    b.Property<DateTime>("InitiatedDate")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("INITIATED_DATE");

                    b.Property<string>("InitiatorIp")
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR2(50)")
                        .HasColumnName("INITIATOR_IP");

                    b.Property<bool>("IsNewRequest")
                        .HasColumnType("NUMBER(1)")
                        .HasColumnName("IS_NEW_REQUEST");

                    b.Property<string>("Nationality")
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR2(100)")
                        .HasColumnName("NATIONALITY");

                    b.Property<string>("NextOfKin")
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR2(100)")
                        .HasColumnName("NEXT_OF_KIN");

                    b.Property<string>("OtherNames")
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR2(50)")
                        .HasColumnName("OTHER_NAMES");

                    b.Property<string>("PermanentAddress")
                        .HasMaxLength(500)
                        .HasColumnType("NVARCHAR2(500)")
                        .HasColumnName("PERMANENT_ADDRESS");

                    b.Property<string>("SessionId")
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR2(50)")
                        .HasColumnName("SESSION_ID");

                    b.Property<int>("Sex")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("SEX");

                    b.Property<string>("SolId")
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR2(50)")
                        .HasColumnName("SOL_ID");

                    b.Property<string>("State")
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR2(50)")
                        .HasColumnName("STATE");

                    b.Property<string>("Status")
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR2(50)")
                        .HasColumnName("STATUS");

                    b.Property<string>("SureName")
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR2(50)")
                        .HasColumnName("SURE_NAME");

                    b.Property<string>("Telephone")
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR2(50)")
                        .HasColumnName("TELEPHONE");

                    b.Property<string>("Title")
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR2(50)")
                        .HasColumnName("TITLE");

                    b.HasKey("Id");

                    b.ToTable("SISL_CUSTOMER_ACCOUNT", "MISUSER");
                });

            modelBuilder.Entity("SISL.Core.Entities.SislDocument", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(19)")
                        .HasColumnName("ID")
                        .HasAnnotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ContentOrPath")
                        .IsRequired()
                        .HasColumnType("CLOB")
                        .HasColumnName("CONTENT_OR_PATH");

                    b.Property<string>("ContentType")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("NVARCHAR2(200)")
                        .HasColumnName("DOCUMENT_CONTENT_TYPE");

                    b.Property<long>("CustomerAccountId")
                        .HasColumnType("NUMBER(19)")
                        .HasColumnName("CUSTOMER_ACCOUNT_ID");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("NVARCHAR2(200)")
                        .HasColumnName("FILE_NAME");

                    b.Property<string>("Title")
                        .HasMaxLength(250)
                        .HasColumnType("NVARCHAR2(250)")
                        .HasColumnName("TITLE");

                    b.HasKey("Id");

                    b.HasIndex("CustomerAccountId");

                    b.ToTable("SISL_DOCS", "MISUSER");
                });

            modelBuilder.Entity("SISL.Core.Entities.SislHistory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(19)")
                        .HasColumnName("ID")
                        .HasAnnotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment")
                        .HasMaxLength(500)
                        .HasColumnType("NVARCHAR2(500)")
                        .HasColumnName("COMMENT");

                    b.Property<string>("CommentBy")
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR2(100)")
                        .HasColumnName("COMMENT_BY");

                    b.Property<DateTime>("CommentDate")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("COMMENT_DATE");

                    b.Property<long>("CustomerAccountId")
                        .HasColumnType("NUMBER(19)")
                        .HasColumnName("CUSTOMER_REQUEST_ID");

                    b.Property<string>("RequestId")
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR2(50)")
                        .HasColumnName("REQUEST_ID");

                    b.HasKey("Id");

                    b.HasIndex("CustomerAccountId");

                    b.ToTable("SISL_HISTORY", "MISUSER");
                });

            modelBuilder.Entity("SISL.Core.Entities.SislStatus", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(19)")
                        .HasColumnName("ID")
                        .HasAnnotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("SislHistoryId")
                        .HasColumnType("NUMBER(19)")
                        .HasColumnName("SISL_HISTORY_ID");

                    b.Property<string>("status")
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR2(50)")
                        .HasColumnName("STATUS");

                    b.HasKey("Id");

                    b.HasIndex("SislHistoryId")
                        .IsUnique();

                    b.ToTable("SISL_STATUS", "MISUSER");
                });

            modelBuilder.Entity("SISL.Core.Entities.SislDocument", b =>
                {
                    b.HasOne("SISL.Core.Entities.CustomerAccount", "CustomerAccount")
                        .WithMany("SislDocuments")
                        .HasForeignKey("CustomerAccountId")
                        .HasConstraintName("FK_SISL_DOCS_CUSTOMER_ID")
                        .IsRequired();

                    b.Navigation("CustomerAccount");
                });

            modelBuilder.Entity("SISL.Core.Entities.SislHistory", b =>
                {
                    b.HasOne("SISL.Core.Entities.CustomerAccount", "CustomerAccount")
                        .WithMany("SislHistories")
                        .HasForeignKey("CustomerAccountId")
                        .HasConstraintName("FK_SISL_HISTORY_ACCOUNT")
                        .IsRequired();

                    b.Navigation("CustomerAccount");
                });

            modelBuilder.Entity("SISL.Core.Entities.SislStatus", b =>
                {
                    b.HasOne("SISL.Core.Entities.SislHistory", "SislHistory")
                        .WithOne("SislStatus")
                        .HasForeignKey("SISL.Core.Entities.SislStatus", "SislHistoryId")
                        .HasConstraintName("FK_SISL_HISTORY_STATUS")
                        .IsRequired();

                    b.Navigation("SislHistory");
                });

            modelBuilder.Entity("SISL.Core.Entities.CustomerAccount", b =>
                {
                    b.Navigation("SislDocuments");

                    b.Navigation("SislHistories");
                });

            modelBuilder.Entity("SISL.Core.Entities.SislHistory", b =>
                {
                    b.Navigation("SislStatus");
                });
#pragma warning restore 612, 618
        }
    }
}
