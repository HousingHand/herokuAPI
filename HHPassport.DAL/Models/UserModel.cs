using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHPassport.DAL.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string user_id { get; set; }
        public string company_name { get; set; }
        public string first_name { get; set; }
        public string middle_initial { get; set; }
        public string last_name { get; set; }
        public string user_email { get; set; }
        public string user_phone { get; set; }
        public string address { get; set; }
        public int? city { get; set; }
        public int? state { get; set; }
        public string zip { get; set; }
        public string gender { get; set; }
        public int? origin { get; set; }
        public int? ethnicity { get; set; }
        public string nationality { get; set; }
        public DateTime? date_of_birth { get; set; }
        public string language_preferance { get; set; }
        public string About_me { get; set; }
        public string profile_pic { get; set; }
        public string QRCode { get; set; }
        public string password { get; set; }
        public string user_type { get; set; }
        public string SocialLoginAuthenticationKey { get; set; }
        public bool? is_active { get; set; }
        public DateTime? created_on { get; set; }
        public DateTime? last_login { get; set; }
        public DateTime? modified_on { get; set; }
        public string RoleName { get; set; }

        public string RoleID { get; set; }
        public string policy_number { get; set; }
        public string coverupto { get; set; }

        public AgentInfoModel AgentInfo { get; set; }

        public string CityName { get; set; }
        public string StateName { get; set; }

        public string isdocuments { get; set; }
        public string is_documents_approved { get; set; }

        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string WebsiteUrl { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string DOBStr { get; set; }
        public int TotalRows { get; set; }

        public bool TermsCheckedByCo { get; set; }

        public string ApplicationId { get; set; }

        public List<UserModel> Users { get; set; }
    }
    public class RegisterViewModel
    {
        public UserModel UserInfo { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string RoleName { get; set; }
        public bool IsSendWelcomeEmail { get; set; }        
    }

    public class UserServiceNewModel
    {
        public string service_id { get; set; }
        public string applicant_id { get; set; }

    }

    public class AgentInfoModel
    {
        public int Id { get; set; }
        public string AgentId { get; set; }
        public string Phone { get; set; }
        public string Title { get; set; }
        public string LogoPath { get; set; }
        public string CoverImagePath { get; set; }
        public string Address { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public List<AgentPropertiesSerachResponseVM> AgentProperties { get; set; }
        public string AP_Type { get; set; }

        public bool IsTermsnAndConditionChecked { get; set; }
        public bool IsPEDChecked { get; set; }
    }

    //public class UserProfilePicModel
    //{
    //    public string user_id { get; set; }
    //    public string profile_pic { get; set; }

    //}

    public class CustomApplicantVM
    {
        public int ApplicantId { get; set; }
        public string ApplicantGUID { get; set; }
        public string ApplicantUserId { get; set; }
        public int AgentId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string StudentBefore { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string PostalCode { get; set; }
        public string Address { get; set; }
        public decimal? RentAmt { get; set; }
        public string RentType { get; set; }
        public DateTime? TenancyStartDate { get; set; }
        public DateTime? TenancyEndDate { get; set; }
        public DateTime? ApplicationDate { get; set; }
        public string PolicyNumber { get; set; }
        public string TenancyStartDateStr { get; set; }
        public string TenancyEndDateStr { get; set; }
        public string Status { get; set; }
        public string AP_Status { get; set; }
        public string IsRejectedByCosigner { get; set; }
        public string IsCosignerRejectedByHH { get; set; }
        public string ApplicantDocumentStatus { get; set; }
        public string CosignerDocumentStatus { get; set; }
        public string PaymentStatus { get; set; }

        public string RejectedReason { get; set; }
        public string RejectedNotes { get; set; }
        public DateTime? RejectedDate { get; set; }

        public string AP_RejectedReason { get; set; }
        public string AP_RejectedNotes { get; set; }
        public DateTime? AP_RejectedDate { get; set; }

        public string AP_notice_email { get; set; }
        public string Property_let_type { get; set; }
        public string Default_type { get; set; }

        public bool IsDisabled { get; set; }
        public int TendencyDurationInMonth { get; set; }
        public string ProfileImg { get; set; }

        public string GurantorStatus { get; set; }
        public string Country { get; set; }

        public bool IsDefault { get; set; }

        public String TenantType { get; set;}
        public string CosignerStatus { get; set; }


    }

    public class UserProfileVM
    {
        public string Gender { get; set; }
        public DateTime? DOB { get; set; }
        public string ProfilePic { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public string Mobile { get; set; }
        public string Website { get; set; }
        public string Address { get; set; }
        public string Longitude { get; set; }

        public string Latitude { get; set; }
    }

    public class AgentDashboardVM
    {
        public string TotalInApplication { get; set; }
        public string TotalWaiting { get; set; }
        public string TotalGuranteed { get; set; }
        public string TotalLiveTenenants { get; set; }
    }

    public class AgentDashboardVMw
    {
        public string TotalInApplication { get; set; }
        public string TotalWaiting { get; set; }
        public string TotalGuranteed { get; set; }
        public string TotalLiveTenenants { get; set; }
    }
    public class Errorresponse
    {
        [JsonProperty("error")]
        public string Error { get; set; }

        [JsonProperty("error_description")]
        public string error_description { get; set; }
    }

}
