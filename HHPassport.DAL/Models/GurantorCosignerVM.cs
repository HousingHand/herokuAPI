using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHPassport.DAL.Models
{
    public class GurantorCosignerVM
    {
        public int Id { get; set; }

        public string CosignerGUID { get; set; }
        public int? ApplicantId { get; set; }

        public string User_id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Relation { get; set; }
        public string PaymentType { get; set; }
        public bool isCosignerdocuments { get; set; }

        public string LinkURL { get; set; }

        public string LinkText { get; set; }

        public string CoPassword { get; set; }
        public string ApplicantName { get; set; }

        public String RejectedByCosigner { get; set; }
        public String RejectedByHH { get; set; }
        public string RejectedReason { get; set; }
        public string RejectedNotes { get; set; }
        public bool Termschecked { get; set; }
        public bool not_a_student { get; set; }
        public bool Not_Living_In_Cosigned_Property { get; set; }
        public bool Full_Time_Employed { get; set; }

        public DateTime? TenancyStartDate { get; set; }

        public DateTime? TenancyEndDate { get; set; }

        public bool ApplicationIsActive { get; set; }
        public string TrackingCookieeId { get; set; }

    }


    public class EditApplicant
    {
        public string PropertyToRented { get; set; }
        public DateTime TenancyStartDate { get; set; }
        public DateTime TenancyEndDate { get; set; }
        public decimal RentAmt { get; set; }
        public string RentType { get; set; }
        public int ApplicantId { get; set; }

        public bool isAddressEdited { get; set; }
        public bool isTenancyStartDateEdited { get; set; }
        public bool isTenancyEndDateEdited { get; set; }
        public bool IsRentAmtEdited { get; set; }
        public bool IsRentTypeEdited { get; set; }
        public string TrackingCookieeId { get; set; }
    }

    public class ApprovedRejectApplicantModel
    {
        public int ApplicantId { get; set; }
        public string Status { get; set; }
        public string RejectedReason { get; set; }
        public string RejectedNotes { get; set; }
        public string AP_notice_email { get; set; }
        public string Property_let_type { get; set; }
        public string Default_type { get; set; }
        public string TrackingCookieeId { get; set; }
    }

    public class EditApplicantModel
    {      
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string ap_edited__accommodation_address { get; set; }
        public DateTime ap_edited_accommodation_start_date { get; set; }
        public DateTime ap_edited_accommodation_end_date { get; set; }
        public string ap_edited_rent_amount { get; set; }
        public string ap_edited__rent_duration { get; set; }

        public bool isAddressEdited { get; set; }
        public bool isTenancyStartDateEdited { get; set; }
        public bool isTenancyEndDateEdited { get; set; }
        public bool IsRentAmtEdited { get; set; }
        public bool IsRentTypeEdited { get; set; }
        public string email { get; set; }
        public string TrackingCookieeId { get; set; }
    }

    public class ApplicantHFSPropertiesModel
    {
        public string hfsLocation { get; set; }
        public string hfsDistanceFromLocation { get; set; }
        public string hfsBeds { get; set; }
        public string hfsFurnishings { get; set; }
        public string hfsExtra_notes { get; set; }
        public string hfsBudgetMinimum { get; set; }
        public string hfsBudgetMaximum { get; set; }
        public string hfsWeeklyOrMonthlyCost { get; set; }
    }
}
