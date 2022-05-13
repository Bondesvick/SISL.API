using System;
using System.Collections.Generic;

namespace SISL.Core.DTOs.Response
{
    public class CustomerAccountDto
    {
        public int Id { get; set; }
        public string SessionId { get; set; }

        public string CustAid { get; set; }
        public string Risk { get; set; }

        public string AccountType { get; set; }
        public string Title { get; set; }
        public string SureName { get; set; }
        public string FirstName { get; set; }
        public string OtherNames { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Sex { get; set; }
        public string MaritalStatus { get; set; }
        public string MothersMaidenName { get; set; }
        public string PermanentAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string LGA { get; set; }
        public string EmailAddress { get; set; }
        public string Telephone { get; set; }
        public string HomePhone { get; set; }
        public string Occupation { get; set; }
        public string CompName { get; set; }
        public string EmploymentType { get; set; }

        /// //////////////////////////////////
        public string BankAcctName { get; set; }

        public string BankAccNumber { get; set; }
        public string BVN { get; set; }
        public string IdType { get; set; }
        public string IdNumber { get; set; }
        public DateTime? MeansOfIDIssueDate { get; set; }
        public DateTime? MeansOfIDExpirationDate { get; set; }
        public string PoliticallyExposed { get; set; }
        public string PEPWho { get; set; }
        public string PoliticallyExposedPerson { get; set; }
        public string PositionHeld { get; set; }
        public DateTime? DateOfOffice { get; set; }
        /// /////////////////////////////////

        public string NextOfKin { get; set; }
        public string NextOfKinSurname { get; set; }
        public string NextOfKinOtherNames { get; set; }
        public string Relationship { get; set; }
        public string ContactAddress { get; set; }
        public string NextOfKinPhone { get; set; }
        public string NextOfKinEmail { get; set; }
        public string NOKNationality { get; set; }
        public string NextOfKinGender { get; set; }
        public DateTime? NOKDateOfBirth { get; set; }

        /// /////////////////////////////////
        public string AverageAnnualIncome { get; set; }

        public string SourceofInvestment { get; set; }
        public string PurposeofInvestment { get; set; }

        /// /////////////////////////////////
        public string OfficeEmail { get; set; }

        public string OfficePhoneNumber { get; set; }
        public string OfficialAddress { get; set; }

        /// /////////////////////////////////
        public string Nationality { get; set; }

        public string BankCode { get; set; }

        public string BranchCode { get; set; }

        /// /////////////////////////////////
        public string Status { get; set; }

        public bool IsNewRequest { get; set; }

        public string LastUpdatedBy { get; set; }
        public string SolId { get; set; }
        public string InitiatedBy { get; set; }
        public DateTime? InitiatedDate { get; set; }
        public string InitiatorIp { get; set; }
        public string ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public string ApproverIp { get; set; }
        public string ReasonForRework { get; set; }
        public ICollection<SislHistoryDto> SislHistories { get; set; }
        public ICollection<GetSislDocumentDto> SislDocuments { get; set; }
    }
}