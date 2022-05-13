using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SISL.Core.Entities;

namespace SISL.Infrastructure.Configurations
{
    public class CustomerAccountConfigurations : IEntityTypeConfiguration<CustomerAccount>
    {
        public void Configure(EntityTypeBuilder<CustomerAccount> builder)
        {
            builder.ToTable("SISL_CUSTOMER_ACCOUNT", "MISUSER");

            builder.HasKey(t => t.Id);

            builder.Property(e => e.Id)
                //.HasColumnType("NUMBER")
                .HasColumnName("ID");
            //.ValueGeneratedOnAdd();

            builder.Property(e => e.SessionId)
                .HasMaxLength(50)
                //.IsUnicode(false)
                .HasColumnName("SESSION_ID");

            builder.Property(e => e.CustAid)
                .HasMaxLength(50)
                //.IsUnicode(false)
                .HasColumnName("CUSTOMER_ID");

            builder.Property(e => e.Risk)
                .HasMaxLength(50)
                //.IsUnicode(false)
                .HasColumnName("RISK");

            builder.Property(e => e.AccountType)
                .HasMaxLength(50)
                //.IsUnicode(false)
                .HasColumnName("ACCOUNT_TYPE");

            builder.Property(e => e.Title)
                .HasMaxLength(50)
                //.IsUnicode(false)
                .HasColumnName("TITLE");

            builder.Property(e => e.SureName)
                .HasMaxLength(50)
                //.IsUnicode(false)
                .HasColumnName("SURE_NAME");

            builder.Property(e => e.FirstName)
                .HasMaxLength(50)
                //.IsUnicode(false)
                .HasColumnName("FIRST_NAME");

            builder.Property(e => e.OtherNames)
                .HasMaxLength(50)
                //.IsUnicode(false)
                .HasColumnName("OTHER_NAMES");

            builder.Property(e => e.DateOfBirth)
                //.HasColumnType("DATE")
                //.IsUnicode(false)
                .HasColumnName("DATE_OF_BIRTH");
            //.HasDefaultValue(DateTime.Now)
            //.IsRequired(false);

            builder.Property(e => e.Sex)
                //.HasMaxLength(50)
                //.HasColumnType("NUMBER")
                //.IsUnicode(false)
                .HasColumnName("SEX");

            builder.Property(e => e.MaritalStatus)
                .HasColumnName("MARITAL_STATUS");

            builder.Property(e => e.MothersMaidenName)
                .HasColumnName("MOTHERS_MAIDEN_NAME");

            builder.Property(e => e.PermanentAddress)
                .HasMaxLength(500)
                //.IsUnicode(false)
                .HasColumnName("PERMANENT_ADDRESS");

            builder.Property(e => e.City)
                .HasMaxLength(50)
                //.IsUnicode(false)
                .HasColumnName("CITY");

            builder.Property(e => e.State)
                .HasMaxLength(50)
                //.IsUnicode(false)
                .HasColumnName("STATE");

            builder.Property(e => e.Country)
                .HasMaxLength(50)
                //.IsUnicode(false)
                .HasColumnName("COUNTRY");

            builder.Property(e => e.LGA)
                .HasColumnName("LGA");

            builder.Property(e => e.EmailAddress)
                .HasMaxLength(200)
                //.IsUnicode(false)
                .HasColumnName("EMAIL_ADDRESS");

            builder.Property(e => e.Telephone)
                .HasMaxLength(50)
                //.IsUnicode(false)
                .HasColumnName("TELEPHONE");

            builder.Property(e => e.HomePhone)
                .HasColumnName("HOME_PHONE");

            builder.Property(e => e.Occupation)
                .HasColumnName("OCCUPATION");

            builder.Property(e => e.CompName)
                .HasMaxLength(50)
                //.IsUnicode(false)
                .HasColumnName("COMP_NAME");

            builder.Property(e => e.EmploymentType)
                .HasColumnName("EMPLOYMENT_TYPE");

            //////////////////////////////////////////

            builder.Property(e => e.BankAcctName)
                .HasMaxLength(200)
                //.IsUnicode(false)
                .HasColumnName("BANK_NAME");

            builder.Property(e => e.BankAccNumber)
                .HasMaxLength(50)
                //.IsUnicode(false)
                .HasColumnName("BANK_ACCOUNT_NUMBER");

            builder.Property(e => e.BVN)
                .HasColumnName("BVN");

            builder.Property(e => e.IdType)
                .HasColumnName("ID_TYPE");

            builder.Property(e => e.IdNumber)
                .HasColumnName("ID_NUMBER");

            builder.Property(e => e.MeansOfIDIssueDate)
                .HasColumnName("MEANS_OF_ID_ISSUE_DATE").IsRequired(false);

            builder.Property(e => e.MeansOfIDExpirationDate)
                .HasColumnName("MEANS_OF_ID_EXPIRATION_DATE").IsRequired(false);

            builder.Property(e => e.PoliticallyExposed)
                .HasColumnName("POLITICALLY_EXPOSED");

            builder.Property(e => e.PEPWho)
                .HasColumnName("PEP_WHO");

            builder.Property(e => e.PoliticallyExposedPerson)
                .HasColumnName("POLITICALLY_EXPOSED_PERSON");

            builder.Property(e => e.PositionHeld)
                .HasColumnName("POSITION_HELD");

            builder.Property(e => e.DateOfOffice)
                .HasColumnName("DATE_OF_OFFICE").IsRequired(false);

            ///////////////////////////////////////////////

            builder.Property(e => e.NextOfKin)
                .HasMaxLength(100)
                //.IsUnicode(false)
                .HasColumnName("NEXT_OF_KIN");

            builder.Property(e => e.NextOfKinSurname)
                .HasMaxLength(100)
                .HasColumnName("NOK_SURNAME");

            builder.Property(e => e.NextOfKinOtherNames)
                .HasMaxLength(100)
                .HasColumnName("NOK_OTHER_NAMES");

            builder.Property(e => e.Relationship)
                .HasMaxLength(100)
                .HasColumnName("NOK_RELATIONSHIP");

            builder.Property(e => e.ContactAddress)
                .HasMaxLength(100)
                .HasColumnName("NOK_CONTACT_ADDRESS");

            builder.Property(e => e.NextOfKinPhone)
                .HasMaxLength(100)
                .HasColumnName("NOK_PHONE");

            builder.Property(e => e.NextOfKinEmail)
                .HasMaxLength(100)
                .HasColumnName("NOK_EMAIL");

            builder.Property(e => e.NOKNationality)
                .HasMaxLength(100)
                .HasColumnName("NOK_NATIONALITY");

            builder.Property(e => e.NextOfKinGender)
                .HasMaxLength(100)
                .HasColumnName("NOK_GENDER");

            builder.Property(e => e.NOKDateOfBirth)
                .HasMaxLength(100)
                .HasColumnName("NOK_DATE_OF_BIRTH").IsRequired(false);

            //////////////////////////////////////

            builder.Property(e => e.AverageAnnualIncome)
                .HasMaxLength(100)
                .HasColumnName("AVERAGE_ANNUAL_INCOME");

            builder.Property(e => e.SourceofInvestment)
                .HasMaxLength(100)
                .HasColumnName("SOURCE_OF_INVESTMENT");

            builder.Property(e => e.PurposeofInvestment)
                .HasMaxLength(100)
                .HasColumnName("PURPOSE_OF_INVESTMENT");

            //////////////////////////////////////////////

            builder.Property(e => e.OfficeEmail)
                .HasMaxLength(100)
                .HasColumnName("OFFICE_MAIL");

            builder.Property(e => e.OfficePhoneNumber)
                .HasMaxLength(100)
                .HasColumnName("OFFICE_PHONE_NUMBER");

            builder.Property(e => e.OfficialAddress)
                .HasMaxLength(100)
                .HasColumnName("OFFICIAL_ADDRESS");

            /////////////////////////////////////////////////////

            builder.Property(e => e.Nationality)
                .HasMaxLength(100)
                //.IsUnicode(false)
                .HasColumnName("NATIONALITY");

            builder.Property(e => e.BankCode)
                .HasMaxLength(50)
                //.IsUnicode(false)
                .HasColumnName("BANK_CODE");

            builder.Property(e => e.BranchCode)
                .HasMaxLength(50)
                //.IsUnicode(false)
                .HasColumnName("BRANCH_CODE");

            //////////////////////////////////////////////

            builder.Property(e => e.Status)
                .HasMaxLength(50)
                //.IsUnicode(false)
                .HasColumnName("STATUS");

            builder.Property(e => e.IsNewRequest)
                //.HasColumnType("DECIMAL")
                //.IsUnicode(false)
                .HasColumnName("IS_NEW_REQUEST");

            builder.Property(e => e.LastUpdatedBy)
                .HasMaxLength(50)
                .HasColumnName("LAST_UPDATED_BY");

            builder.Property(e => e.SolId)
                .HasMaxLength(50)
                //.IsUnicode(false)
                .HasColumnName("SOL_ID");

            builder.Property(e => e.InitiatedBy)
                .HasMaxLength(50)
                //.IsUnicode(false)
                .HasColumnName("INITIATED_BY");

            builder.Property(e => e.InitiatedDate)
                //.HasColumnType("DATE")
                //.IsUnicode(false)
                .HasColumnName("INITIATED_DATE").IsRequired(false);

            builder.Property(e => e.InitiatorIp)
                .HasMaxLength(50)
                //.IsUnicode(false)
                .HasColumnName("INITIATOR_IP");

            builder.Property(e => e.ApprovedBy)
                .HasMaxLength(50)
                //.IsUnicode(false)
                .HasColumnName("APPROVED_BY");

            builder.Property(e => e.ApprovedDate)
                //.HasColumnType("DATE")
                //.IsUnicode(false)
                .HasColumnName("APPROVED_DATE").IsRequired(false);

            builder.Property(e => e.ApproverIp)
                .HasMaxLength(50)
                //.IsUnicode(false)
                .HasColumnName("APPROVER_IP");

            builder.Property(e => e.ReasonForRework)
                .HasMaxLength(50)
                //.IsUnicode(false)
                .HasColumnName("REASON_FOR_REWORK");
        }
    }
}