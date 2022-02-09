using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace HHPassport.DAL.Models
{
    public class GurantorApplicantFormVM
    {
        public int ApplicantId { get; set; }
        public string ApplicantGUID { get; set; }
        public string user_id { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public string StudentFrom { get; set; }
        public bool? IsDocuments { get; set; }
        public string StudentBefore { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? UniversityId { get; set; }
        public int? StudentStudyingId { get; set; }
        public int? CourseId { get; set; }
        public string Employment_Status { get; set; }
        public string Income { get; set; }
        public int? AgentId { get; set; }
        public string AgentEmail { get; set; }
        public string AgentName { get; set; }

        public string AgentFirstName { get; set; }
        public string AgentLastName { get; set; }

        public string CoEmail { get; set; }

        public string Address { get; set; }
        public decimal? RentAmt { get; set; }
        public string RentType { get; set; }
        public DateTime? TenancyStartDate { get; set; }
        public DateTime? TenancyEndDate { get; set; }
        public string IdentityImage { get; set; }
        public string DocumentsPath { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public bool IsEligible { get; set; }

        public bool IsAgent { get; set; }

        public bool IsCosigner { get; set; }

        public string is_rejected_by_cosigner { get; set; }
        public string is_cosigner_rejected_by_hh { get; set; }

        public string cosigner_rejected_reason { get; set; }
        public string cosigner_rejected_notes { get; set; }

        public DateTime? cosigner_rejected_date { get; set; }

        public GurantorCosignerVM CosignerInfoModel { get; set; }

        public int StepID { get; set; }

        public string PostalCode { get; set; }
        public string PaymentType { get; set; }
        public decimal PaymentAmount { get; set; }
        public string PaymentStatus { get; set; }  

        public bool IsPayment { get; set; }

        public int TotalProgress { get; set; }
        public bool is_documents_approved { get; set; }
        public bool is_cosigner_approved { get; set; }

        public bool is_document_rejected { get; set; }
        public String is_Agent_approved { get; set; }

        public bool isManualAccomo { get; set; }
        public string accomoName { get; set; }
        public string accomoPhone { get; set; }
        public string accomoAddress { get; set; }
        public string accomoEmail { get; set; }

        public string status { get; set; }
        public string RejectedReason { get; set; }

        public DateTime RejectedDate { get; set; }
        public string RejectedNotes { get; set; }
       public string userType { get; set; }

        public string nationality { get; set; }

        public string PolicyNumber { get; set; }

        public string ApType { get; set; }

        public string AP_Status { get; set; }
        public string AP_RejectedReason { get; set; }
        public string AP_RejectedDate { get; set; }
        public string AP_RejectedNotes { get; set; }
        public GurantorApplicantFormVM()
        {
            ApplicantGUID = "";
        }
        public bool isManulaaddress { get; set; }
        public string isManualCountry { get; set; }
        public string countryCode { get; set; }
        public int AffiliateId { get; set; }
        public AffiliateModel AffilateModel { get; set; }
        public int IsHubspotRenewalReady { get; set; }
        public string TrackingCookieeId { get; set; }
    }

    public class GurantortStudyModel
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public string StudentBefore { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? UniversityId { get; set; }
        public int? StudentStudyingId { get; set; }
        public int? CourseId { get; set; }


    }

    public class GurantorAccomodationModel
    {
        public int ApplicantId { get; set; }
        public int? AgentId { get; set; }
        public string Address { get; set; }
        public decimal? RentAmt { get; set; }
        public string RentType { get; set; }
        public DateTime? TenancyStartDate { get; set; }
        public DateTime? TenancyEndDate { get; set; }


        public string PostalCode { get; set; }

    }
    public class UpdateGurantorApplicantStatusVM
    {
        public int ApplicantId { get; set; }
        public int CoSignerId { get; set; }
        public string Satus { get; set; }
        public bool IsCosigner { get; set; }
    }
    public class GurantorFeesModel
    {
        //    public decimal ST_TotalPayble { get; set; }
        //    public decimal WP_TotalPayble { get; set; }

        //public decimal WP_Upfront { get; set; }
        //public decimal ST_Upfront { get; set; }

        //public decimal ST_Monthly_Amount { get; set; }

        //public decimal ST_Weekly_Amount { get; set; }
        //public decimal ST_Upfront_Monthly_Amount { get; set; }

        // public decimal ST_Upfront_Weekly_Amount { get; set; }

        //public decimal WP_Monthly_Amount { get; set; }
        //public decimal WP_Weekly_Amount { get; set; }

        //public decimal WP_Upfront_Monthly_Amount { get; set; }

        //public decimal WP_Upfront_Weekly_Amount { get; set; }

        public decimal PaybleAmt { get; set; }
        public decimal TotalOneOffPayble { get; set; }
        public decimal TotalMonthlyInstallment { get; set; }
        public decimal TotalSaved { get; set; }
        public decimal DiscountPercentage { get; set; }


    }

    public class DeleteGurantorDocumentModel
    {
        public string applicantId { get; set; }
        public int DocumentId { get; set; }
    }
    public class GurantorUploadDocumentsModel
    {
        public string UploadedBy { get; set; }
        public string Status { get; set; }
        public int Type { get; set; }
        public HttpPostedFileBase Files { get; set; }
        public string FilePath { get; set; }
        public int DocumentId { get; set; }

        public bool IsRejected { get; set; }
        public string RejectedReason { get; set;        }

        public string HubspotZipPath { get; set; }

        public bool IsActive { get; set; }
    }

  
}
