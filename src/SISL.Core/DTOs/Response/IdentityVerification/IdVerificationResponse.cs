namespace SISL.Core.DTOs.Response.IdentityVerification
{
    public class IdVerificationResponse
    {
        public string JSONVersion { get; set; }
        public string SmileJobID { get; set; }
        public PartnerParams PartnerParams { get; set; }
        public string ResultType { get; set; }
        public string ResultText { get; set; }
        public string ResultCode { get; set; }
        public string IsFinalResult { get; set; }
        public Actions Actions { get; set; }
        public string Country { get; set; }
        public string IDType { get; set; }
        public string IDNumber { get; set; }
        public string ExpirationDate { get; set; }
        public string FullName { get; set; }
        public string DOB { get; set; }
        public string Photo { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public FullData FullData { get; set; }
        public string Source { get; set; }
        public string sec_key { get; set; }
        public long timestamp { get; set; }
    }

    public class FullData
    {
        public string firstname { get; set; }
        public string birthdate { get; set; }
        public string dateOfBirth { get; set; }
        public string DOB_Y { get; set; }
        public string gender { get; set; }
        public string sex { get; set; }
        public string pmiddlename { get; set; }
        public string title { get; set; }
        public string residence_Town { get; set; }
        public string pfirstname { get; set; }
        public string nin { get; set; }
        public string nok_lastname { get; set; }
        public string employmentstatus { get; set; }
        public string nspokenlang { get; set; }
        public string name { get; set; }
        public string othername { get; set; }
        public string otherName { get; set; }
        public string telephoneno { get; set; }
        public string surname { get; set; }
        public string LastName { get; set; }
        public string place { get; set; }
        public string state { get; set; }
        public string email { get; set; }
        public string height { get; set; }
        public string trackingId { get; set; }
        public string educationallevel { get; set; }
        public string profession { get; set; }
        public string birthcountry { get; set; }
        public string residencestatus { get; set; }
        public string middlename { get; set; }
        public string photo { get; set; }
        public string self_origin_state { get; set; }
        public string message { get; set; }
        public string residence_state { get; set; }
        public string ospokenlang { get; set; }
        public string centralID { get; set; }
        public string self_origin_place { get; set; }
        public string nationality { get; set; }
        public string self_origin_lga { get; set; }
        public string slip { get; set; }
        public bool success { get; set; }
        public string birthstate { get; set; }
        public string psurname { get; set; }
        public string maidenname { get; set; }
        public string residence_lga { get; set; }
        public string residence_AddressLine1 { get; set; }
    }

    public class Actions
    {
        public string Verify_ID_Number { get; set; }
        public string Return_Personal_Info { get; set; }
    }

    public class PartnerParams
    {
        public int job_type { get; set; }
        public string job_id { get; set; }
        public string user_id { get; set; }
    }
}