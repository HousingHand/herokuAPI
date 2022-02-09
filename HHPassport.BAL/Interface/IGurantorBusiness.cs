using HHPassport.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHPassport.BAL.Interface
{
    public interface IGurantorBusiness
    {
        GurantorApplicantFormVM GetGurantorApplicationDataById(int id, bool isHubspotCall = false);
        List<GurantorApplicantFormVM> GetAllGurantorApplicationData(string policy_number, int? Applicant_Id, bool? Is_eligible, bool? Is_document, bool? Is_agent, bool? Is_cosigner, string user_id, int? agentId);
        int AddUpdateGurantorApplicationForm(GurantorApplicantFormVM model);
        int InsertGurantorRenewProcess(GurantorApplicantFormVM model);
        int UpdateGurantorApplicationStatus(UpdateGurantorApplicantStatusVM obj);

        int getApplicationCounter(int AgentId, Char ApplicationType);

        int UpdateCosignerInformation(int applicantID, bool Not_student, bool Not_Living_In_Cosigned_Property, bool Full_Time_Employed);
        int UpdateGurantorApplicationDefaultStatus(string applicantID);
        GurantorFeesModel GetGurantorFees(string userId, bool IsFixed, decimal Monthly, decimal Onetime);
        int UpdateGuranotorFees(GurantorFeesModel obj);
        int UploadGurantorDocuments(GurantorUploadDocumentsModel obj);
        int UploadCosignerDocuments(GurantorUploadDocumentsModel obj);
        List<GurantorUploadDocumentsModel> GetGurantorDocuments(string applicantId, string isDocumentfor = "");
        int DeleteGurantorFormDocuments(DeleteGurantorDocumentModel obj);

        GurantorCosignerVM GetCosignerByApplicationId(string ApplicationId);

        GurantorCosignerVM GetCosignerInformation(string cosignerId);
        int EditApplicantInfo(EditApplicant applicant);
        int ApproveRejectApplicant(ApprovedRejectApplicantModel applicant);
        int CosignerNotInterested(int applicantId, String RejectedReason, String RejectedNotes);
        int UpdateGurantorRenewalStatus(int applicantId, int status);
    }
}
