using HHPassport.BAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HHPassport.DAL.Models;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Newtonsoft.Json;
using HHPassport.DAL.Helpers;
using System.Reflection;

namespace HHPassport.BAL.Service
{
    public class GurantorBusiness : IGurantorBusiness
    {
        readonly string appBaseAddress = ConfigurationManager.AppSettings["BaseAddress"].ToString();
        public GurantorApplicantFormVM GetGurantorApplicationDataById(int id, bool isHubspotCall = false)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                GurantorApplicantFormVM obj = null;
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPGetGurantorApplicationDataById]  @ID", connection))
                    {
                        command.Parameters.AddWithValue("@ID", id);
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                obj = new GurantorApplicantFormVM();
                                obj.ApplicantId = Convert.ToInt32(reader["ApplicantId"].ToString());
                                obj.user_id = Convert.ToString(reader["user_id"]);
                                obj.Name = Convert.ToString(reader["Name"]);
                                obj.Email = Convert.ToString(reader["Email"]);
                                obj.ContactNumber = Convert.ToString(reader["PhoneNumber"]);
                                obj.StudentFrom = Convert.ToString(reader["StudentFrom"]);
                                obj.IsDocuments = Convert.ToBoolean(String.IsNullOrEmpty(Convert.ToString(reader["IsDocuments"])) ? 0 : 1);
                                obj.StudentBefore = Convert.ToString(reader["StudentBefore"]);
                                if (!string.IsNullOrEmpty(Convert.ToString(reader["DateOfBirth"])))
                                {
                                    obj.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                                }
                                else
                                    obj.DateOfBirth = (DateTime?)null;
                                obj.Employment_Status = Convert.ToString(reader["Employment_Status"]);
                                obj.Income = Convert.ToString(reader["Income"]);
                                obj.UniversityId = !string.IsNullOrEmpty(Convert.ToString(reader["UniversityId"])) ? Convert.ToInt32(reader["UniversityId"]) : (int?)null;
                                obj.StudentStudyingId = string.IsNullOrEmpty(Convert.ToString(reader["StudentStudyingId"])) ? (int?)null : Convert.ToInt32(reader["StudentStudyingId"]);
                                obj.CourseId = !string.IsNullOrEmpty(Convert.ToString(reader["CourseId"])) ? Convert.ToInt32(reader["CourseId"]) : (int?)null;
                                obj.AgentId = !string.IsNullOrEmpty(Convert.ToString(reader["AgentId"])) ? Convert.ToInt32(reader["AgentId"]) : (int?)null;
                                obj.Address = Convert.ToString(reader["Address"]);
                                obj.RentAmt = !string.IsNullOrEmpty(Convert.ToString(reader["RentAmt"])) ? Convert.ToDecimal(reader["RentAmt"]) : (decimal?)null;
                                obj.RentType = Convert.ToString(reader["RentType"]);
                                obj.TenancyStartDate = !string.IsNullOrEmpty(Convert.ToString(reader["TenancyStartDate"])) ? Convert.ToDateTime(reader["TenancyStartDate"]) : (DateTime?)null;
                                obj.TenancyEndDate = !string.IsNullOrEmpty(Convert.ToString(reader["TenancyEndDate"])) ? Convert.ToDateTime(reader["TenancyEndDate"]) : (DateTime?)null;
                                obj.IdentityImage = Convert.ToString(reader["IdentityImage"]);
                                obj.IsActive = Convert.ToBoolean(reader["IsActive"]);
                                obj.IsDeleted = !string.IsNullOrEmpty(Convert.ToString(reader["IsDeleted"])) ? Convert.ToBoolean(reader["IsDeleted"]) : (bool?)null;
                                obj.DeletedDate = !string.IsNullOrEmpty(Convert.ToString(reader["DeletedDate"])) ? Convert.ToDateTime(reader["DeletedDate"]) : (DateTime?)null;
                                obj.CreatedBy = Convert.ToString(reader["CreatedBy"]);
                                obj.CreatedDate = !string.IsNullOrEmpty(Convert.ToString(reader["CreatedDate"])) ? Convert.ToDateTime(reader["CreatedDate"]) : (DateTime?)null;
                                obj.UpdatedBy = Convert.ToString(reader["UpdatedBy"]);
                                obj.UpdatedDate = !string.IsNullOrEmpty(Convert.ToString(reader["UpdatedDate"])) ? Convert.ToDateTime(reader["UpdatedDate"]) : (DateTime?)null;
                                obj.PostalCode = Convert.ToString(reader["PostalCode"]);
                                //obj.AgentName = Convert.ToString(reader["agentName"]);
                                obj.CosignerInfoModel = new GurantorCosignerVM();
                                if (!string.IsNullOrEmpty(Convert.ToString((reader["Id"]))))
                                {
                                    obj.CosignerInfoModel.Id = Convert.ToInt32(reader["Id"]);
                                    obj.CosignerInfoModel.ApplicantId = Convert.ToInt32(reader["ApplicantId"].ToString());
                                    obj.CosignerInfoModel.Email = Convert.ToString(reader["CoEmail"]);
                                    obj.CosignerInfoModel.FirstName = Convert.ToString(reader["CoFirstName"]);
                                    obj.CosignerInfoModel.LastName = Convert.ToString(reader["CoLastName"]);
                                    obj.CosignerInfoModel.PaymentType = Convert.ToString(reader["PaymentType"]);
                                    obj.CosignerInfoModel.PhoneNumber = Convert.ToString(reader["CoPhoneNumber"]);
                                    obj.CosignerInfoModel.Relation = Convert.ToString(reader["CoRelation"]);
                                    obj.CosignerInfoModel.CosignerGUID = Convert.ToString(reader["CosignerGUID"]);
                                }
                                obj.status = Convert.ToString(reader["ApplicantStatus"]);
                                obj.RejectedNotes = Convert.ToString(reader["RejectedNotes"]);
                                obj.RejectedReason = Convert.ToString(reader["RejectedReason"]);
                                if (!string.IsNullOrEmpty(Convert.ToString(reader["RejectedDate"])))
                                {
                                    obj.RejectedDate = Convert.ToDateTime(reader["RejectedDate"]);
                                }
                                obj.userType = Convert.ToString(reader["userType"]);
                                obj.AgentName = Convert.ToString(reader["ap_name"]);
                                obj.AgentFirstName = Convert.ToString(reader["ap_firstname"]);
                                obj.AgentLastName = Convert.ToString(reader["ap_lastname"]);
                                obj.accomoName = Convert.ToString(reader["ap_name"]);
                                obj.accomoEmail = Convert.ToString(reader["ap_email"]);
                                obj.accomoPhone = Convert.ToString(reader["ap_phone"]);
                                obj.accomoAddress = Convert.ToString(reader["ap_address"]);
                                obj.FirstName = Convert.ToString(reader["firstname"]);
                                obj.LastName = Convert.ToString(reader["lastname"]);
                                obj.nationality = Convert.ToString(reader["nationality"]);
                                obj.countryCode = Convert.ToString(reader["countryCode"]);

                                //obj.applicant_request_counter = Convert.ToInt16(reader["applicant_request_counter"]);
                                //obj.hfs_applicant_request_counter = Convert.ToInt16(reader["hfs_applicant_request_counter"]);


                                if (!String.IsNullOrEmpty(Convert.ToString(reader["AffiliateId"])))
                                {
                                    obj.AffiliateId = Convert.ToInt32(reader["AffiliateId"]);
                                }
                                obj.IsHubspotRenewalReady = Convert.ToInt32(reader["IsHubspotRenewalReady"]);
                                if (reader["isManualCountry"] is DBNull)
                                {
                                    obj.isManualCountry = string.Empty;
                                }
                                else
                                {
                                    obj.isManualCountry = Convert.ToString(reader["isManualCountry"]);
                                }

                                if (reader["isManulaaddress"] is DBNull || !Convert.ToBoolean(reader["isManulaaddress"]))
                                {
                                    obj.isManulaaddress = false;
                                    obj.isManualAccomo = false;
                                }
                                else
                                {
                                    obj.isManulaaddress = Convert.ToBoolean(reader["isManulaaddress"]);
                                    obj.isManualAccomo = true;

                                }

                                if (reader["apType"] is DBNull)
                                {
                                    obj.ApType = string.Empty;
                                }
                                else
                                {
                                    obj.ApType = Convert.ToString(reader["apType"]);
                                }
                                obj.AP_Status = reader["AP_Status"] is DBNull ? string.Empty : reader["AP_Status"].ToString();

                                obj.PolicyNumber = reader["PolicyNumber"] is DBNull ? string.Empty : reader["PolicyNumber"].ToString();
                            }

                        }
                    }
                    connection.Close();
                    return obj;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public List<GurantorApplicantFormVM> GetAllGurantorApplicationData(string policy_number, int? Applicant_Id, bool? Is_eligible, bool? Is_document, bool? Is_agent, bool? Is_cosigner, string user_id, int? agentId)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                List<GurantorApplicantFormVM> objList = new List<GurantorApplicantFormVM>();
                GurantorApplicantFormVM obj = null;
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPGetAllGurantorApplicationData_v2] @Policy_Number,@Applicant_Id, @Is_eligible, @Is_document,@Is_agent,@Is_cosigner,@User_id,@agent_id", connection))
                    {
                        if (string.IsNullOrEmpty(policy_number))
                            command.Parameters.AddWithValue("@policy_number", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("@policy_number", policy_number);

                        if (Applicant_Id.HasValue)
                            command.Parameters.AddWithValue("@Applicant_Id", Applicant_Id);
                        else
                            command.Parameters.AddWithValue("@Applicant_Id", DBNull.Value);

                        if (Is_eligible.HasValue)
                            command.Parameters.AddWithValue("@Is_eligible", Is_eligible);
                        else
                            command.Parameters.AddWithValue("@Is_eligible", DBNull.Value);

                        if (Is_document.HasValue)
                            command.Parameters.AddWithValue("@Is_document", Is_document);
                        else
                            command.Parameters.AddWithValue("@Is_document", DBNull.Value);

                        if (Is_agent.HasValue)
                            command.Parameters.AddWithValue("@Is_agent", Is_agent);
                        else
                            command.Parameters.AddWithValue("@Is_agent", DBNull.Value);


                        if (Is_cosigner.HasValue)
                            command.Parameters.AddWithValue("@Is_cosigner", Is_cosigner);
                        else
                            command.Parameters.AddWithValue("@Is_cosigner", DBNull.Value);

                        if (!string.IsNullOrEmpty(user_id))
                            command.Parameters.AddWithValue("@User_id", user_id);
                        else
                            command.Parameters.AddWithValue("@User_id", DBNull.Value);

                        if (agentId.HasValue)
                            command.Parameters.AddWithValue("@agent_id", agentId);
                        else
                            command.Parameters.AddWithValue("@agent_id", DBNull.Value);

                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                obj = new GurantorApplicantFormVM();
                                obj.status = reader["status"] is DBNull ? string.Empty : reader["status"].ToString();
                                //obj.status = "H";
                                obj.ApplicantId = Convert.ToInt32(reader["ApplicantId"].ToString());
                                obj.ApplicantGUID = Convert.ToString(reader["ApplicantGUID"]);
                                obj.Name = Convert.ToString(reader["Name"]);
                                obj.Email = Convert.ToString(reader["Email"]);
                                obj.ContactNumber = Convert.ToString(reader["PhoneNumber"]);
                                obj.StudentFrom = Convert.ToString(reader["StudentFrom"]);
                                obj.IsDocuments = obj.status == "H" ? true : Convert.ToBoolean(reader["IsDocuments"]); obj.StudentBefore = Convert.ToString(reader["StudentBefore"]);
                                if (!string.IsNullOrEmpty(Convert.ToString(reader["DateOfBirth"])))
                                {
                                    obj.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                                }
                                else
                                {
                                    obj.DateOfBirth = (DateTime?)null;

                                }
                                obj.Employment_Status = Convert.ToString(reader["Employment_Status"]);
                                obj.Income = Convert.ToString(reader["Income"]);
                                obj.UniversityId = !string.IsNullOrEmpty(Convert.ToString(reader["UniversityId"])) ? Convert.ToInt32(reader["UniversityId"]) : (int?)null;
                                obj.StudentStudyingId = string.IsNullOrEmpty(Convert.ToString(reader["StudentStudyingId"])) ? (int?)null : Convert.ToInt32(reader["StudentStudyingId"]);
                                obj.CourseId = !string.IsNullOrEmpty(Convert.ToString(reader["CourseId"])) ? Convert.ToInt32(reader["CourseId"]) : (int?)null;
                                obj.AgentId = !string.IsNullOrEmpty(Convert.ToString(reader["AgentId"])) ? Convert.ToInt32(reader["AgentId"]) : (int?)null;
                                obj.Address = Convert.ToString(reader["Address"]);
                                obj.RentAmt = !string.IsNullOrEmpty(Convert.ToString(reader["RentAmt"])) ? Convert.ToDecimal(reader["RentAmt"]) : (decimal?)null;
                                obj.RentType = Convert.ToString(reader["RentType"]);
                                obj.TenancyStartDate = !string.IsNullOrEmpty(Convert.ToString(reader["TenancyStartDate"])) ? Convert.ToDateTime(reader["TenancyStartDate"]) : (DateTime?)null;
                                obj.TenancyEndDate = !string.IsNullOrEmpty(Convert.ToString(reader["TenancyEndDate"])) ? Convert.ToDateTime(reader["TenancyEndDate"]) : (DateTime?)null;
                                obj.IdentityImage = Convert.ToString(reader["IdentityImage"]);
                                obj.IsActive = Convert.ToBoolean(reader["IsActive"]);
                                obj.IsDeleted = !string.IsNullOrEmpty(Convert.ToString(reader["IsDeleted"])) ? Convert.ToBoolean(reader["IsDeleted"]) : (bool?)null;
                                obj.DeletedDate = !string.IsNullOrEmpty(Convert.ToString(reader["DeletedDate"])) ? Convert.ToDateTime(reader["DeletedDate"]) : (DateTime?)null;
                                obj.CreatedBy = Convert.ToString(reader["CreatedBy"]);
                                obj.CreatedDate = !string.IsNullOrEmpty(Convert.ToString(reader["CreatedDate"])) ? Convert.ToDateTime(reader["CreatedDate"]) : (DateTime?)null;
                                obj.UpdatedBy = Convert.ToString(reader["UpdatedBy"]);
                                obj.UpdatedDate = !string.IsNullOrEmpty(Convert.ToString(reader["UpdatedDate"])) ? Convert.ToDateTime(reader["UpdatedDate"]) : (DateTime?)null;
                                obj.PolicyNumber = Convert.ToString(reader["Policy_Number"]);
                                obj.CosignerInfoModel = new GurantorCosignerVM();
                                if (!string.IsNullOrEmpty(Convert.ToString((reader["Id"]))))
                                {
                                    obj.CosignerInfoModel.Id = Convert.ToInt32(reader["Id"]);
                                    obj.CosignerInfoModel.ApplicantId = Convert.ToInt32(reader["ApplicantId"].ToString());
                                    obj.CosignerInfoModel.Email = Convert.ToString(reader["CoEmail"]);
                                    obj.CosignerInfoModel.FirstName = Convert.ToString(reader["FirstName"]);
                                    obj.CosignerInfoModel.LastName = Convert.ToString(reader["LastName"]);
                                    obj.CosignerInfoModel.PaymentType = Convert.ToString(reader["PaymentType"]);
                                    obj.CosignerInfoModel.PhoneNumber = Convert.ToString(reader["CoPhoneNumber"]);
                                    obj.CosignerInfoModel.Relation = Convert.ToString(reader["Relation"]);
                                    obj.CosignerInfoModel.CosignerGUID = Convert.ToString(reader["CosignerGUID"]);
                                }
                                obj.PaymentAmount = (reader["PaymentAmount"] is DBNull ? 0 : Convert.ToDecimal(reader["PaymentAmount"]));
                                obj.PaymentStatus = Convert.ToString(reader["PaymentStatus"]);
                                obj.PaymentType = Convert.ToString(reader["PaymentType"]);
                                obj.user_id = Convert.ToString(reader["user_id"]);
                                obj.IsEligible = string.IsNullOrEmpty(Convert.ToString(reader["IsEligible"])) ? false : Convert.ToBoolean(reader["IsEligible"]);
                                obj.IsCosigner = obj.status == "H" ? true : string.IsNullOrEmpty(Convert.ToString(reader["is_coSigner"])) ? false : Convert.ToBoolean(reader["is_coSigner"]);
                                obj.is_rejected_by_cosigner = obj.status == "H" ? "N" : Convert.ToString(reader["is_rejected_by_cosigner"]);
                                obj.is_cosigner_rejected_by_hh = obj.status == "H" ? "N" : Convert.ToString(reader["is_cosigner_rejected_by_hh"]);
                                obj.cosigner_rejected_reason = Convert.ToString(reader["cosigner_rejected_reason"]);
                                obj.cosigner_rejected_notes = Convert.ToString(reader["cosigner_rejected_notes"]);

                                if (reader["cosigner_rejected_date"] is DBNull)
                                {
                                    obj.cosigner_rejected_date = null;
                                }
                                else
                                {
                                    obj.cosigner_rejected_date = Convert.ToDateTime(reader["cosigner_rejected_date"]);
                                }

                                obj.IsAgent = obj.status == "H" ? true : string.IsNullOrEmpty(Convert.ToString(reader["is_Agent"])) ? false : Convert.ToBoolean(reader["is_Agent"]);
                                obj.IsPayment = obj.status == "H" ? true : Convert.ToBoolean(reader["isPayment"]);

                                int counter = 0;

                                if (obj.IsEligible == true)
                                    counter += 20;
                                if (obj.IsDocuments == true)
                                    counter += 20;
                                if (obj.IsCosigner == true)
                                    counter += 20;
                                if (obj.IsAgent == true)
                                    counter += 20;
                                if (obj.IsPayment == true)
                                    counter += 20;

                                obj.TotalProgress = counter;
                                obj.is_documents_approved = obj.status == "H" ? true : string.IsNullOrEmpty(Convert.ToString(reader["is_documents_approved"])) ? false : Convert.ToBoolean(reader["is_documents_approved"]);
                                obj.is_cosigner_approved = obj.status == "H" ? true : string.IsNullOrEmpty(Convert.ToString(reader["is_cosigner_approved"])) ? false : Convert.ToBoolean(reader["is_cosigner_approved"]);
                                obj.is_Agent_approved = obj.status == "H" ? "Y" : Convert.ToString(reader["is_Agent_approved"]);
                                //obj.is_Agent_approved = "Y";
                                //obj.status = "H";
                                obj.is_document_rejected = string.IsNullOrEmpty(Convert.ToString(reader["is_document_rejected"])) ? false : Convert.ToBoolean(reader["is_document_rejected"]);
                                obj.userType = Convert.ToString(reader["user_type"]);

                                obj.AgentFirstName = Convert.ToString(reader["AgentFirstName"]);

                                obj.AgentLastName = Convert.ToString(reader["AgentLastName"]);


                                obj.AP_Status = string.IsNullOrEmpty(Convert.ToString(reader["ap_status"])) ? "" : Convert.ToString(reader["ap_status"]);
                                obj.AP_RejectedReason = string.IsNullOrEmpty(Convert.ToString(reader["ap_rejectedreason"])) ? "" : Convert.ToString(reader["ap_rejectedreason"]);
                                obj.AP_RejectedDate = string.IsNullOrEmpty(Convert.ToString(reader["ap_rejecteddate"])) ? "" : Convert.ToString(reader["ap_rejecteddate"]);
                                obj.AP_RejectedNotes = string.IsNullOrEmpty(Convert.ToString(reader["ap_rejectednotes"])) ? "" : Convert.ToString(reader["ap_rejectednotes"]);
                                obj.AffiliateId = Convert.ToInt32(reader["AffiliateId"]);

                                if (obj.AffiliateId > 0)
                                {
                                    obj.AffilateModel = new AffiliateModel();
                                    obj.AffilateModel.affiliate_id = Convert.ToInt32(reader["affiliate_id"].ToString());
                                    obj.AffilateModel.affiliate_name = reader["affiliate_name"].ToString();
                                    obj.AffilateModel.email = (reader["email"].ToString());
                                    obj.AffilateModel.affiliate_code = (reader["affiliate_code"].ToString());
                                    obj.AffilateModel.Affiliate_link = reader["Affiliate_link"].ToString();
                                    obj.AffilateModel.logo = ConfigurationManager.AppSettings["BaseAddress"] + reader["logo"].ToString();
                                    obj.AffilateModel.country = reader["country"].ToString();
                                    obj.AffilateModel.IsActive = Convert.ToBoolean(reader["IsActive"].ToString());
                                    obj.AffilateModel.description = reader["Description"].ToString();
                                    obj.AffilateModel.AP_Partners = reader["AP_Partners"].ToString();
                                    obj.AffilateModel.Uni_Partners = reader["Uni_Partners"].ToString();
                                    obj.AffilateModel.IsAPPayingFee = Convert.ToBoolean(reader["IsAPPayingFee"].ToString());
                                    obj.AffilateModel.IsAffiliateImpactPricing = Convert.ToBoolean(reader["IsAffiliateImpactPricing"].ToString());
                                    obj.AffilateModel.PricingType = reader["PricingType"].ToString();
                                    obj.AffilateModel.FixedMonthlyPrice = Convert.ToDecimal(reader["FixedMonthlyPrice"].ToString());
                                    obj.AffilateModel.FixedOneTimePrice = Convert.ToDecimal(reader["FixedOneTimePrice"].ToString());
                                    obj.AffilateModel.PercentMonthlyPrice = Convert.ToDecimal(reader["PercentMonthlyPrice"].ToString());
                                    obj.AffilateModel.PercentOneTimePrice = Convert.ToDecimal(reader["PercentOneTimePrice"].ToString());
                                    obj.AffilateModel.IsDoc = Convert.ToBoolean(reader["IsDoc"].ToString());
                                    obj.AffilateModel.ProofOfAddress = Convert.ToBoolean(reader["ProofOfAddress"].ToString());
                                    obj.AffilateModel.PhotoId = Convert.ToBoolean(reader["PhotoId"].ToString());
                                    obj.AffilateModel.RegistrationForm = Convert.ToBoolean(reader["RegistrationForm"].ToString());
                                    obj.AffilateModel.ProofOfIncome = Convert.ToBoolean(reader["ProofOfIncome"].ToString());
                                    obj.AffilateModel.ProofOfStudy = Convert.ToBoolean(reader["ProofOfStudy"].ToString());
                                    obj.AffilateModel.ProofOfNI = Convert.ToBoolean(reader["ProofOfNI"].ToString());
                                    obj.AffilateModel.IsMoreField = Convert.ToBoolean(reader["IsMoreField"].ToString());
                                    obj.AffilateModel.AnyProofId = reader["AnyProofId"].ToString();
                                    obj.AffilateModel.OtherProofId = reader["OtherProofId"].ToString();
                                    obj.AffilateModel.IsCosigner = Convert.ToBoolean(reader["IsCosigner"].ToString());
                                    obj.AffilateModel.IsAffiliateRebate = Convert.ToBoolean(reader["IsAffiliateRebate"].ToString());
                                    obj.AffilateModel.IsLimitedUse = Convert.ToBoolean(reader["IsLimitedUse"].ToString());
                                    obj.AffilateModel.No_Of_Max_Uses = Convert.ToInt32(reader["No_Of_Max_Uses"].ToString());
                                    obj.AffilateModel.CreatedOn = Convert.ToDateTime(reader["CreatedOn"].ToString());
                                    obj.CreatedBy = reader["CreatedBy"].ToString();
                                }
                                obj.IsHubspotRenewalReady = Convert.ToInt32(reader["IsHubspotRenewalReady"]);
                            }
                            objList.Add(obj);
                        }

                    }
                    connection.Close();
                    return objList;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public int UpdateCosignerInformation(int ApplicantId, bool Not_student, bool Not_Living_In_Cosigned_Property, bool Full_Time_Employed)
        {
            int response = 0;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPUpdateCosignerInformation]  @ApplicantId, @Not_student, @Not_Living_In_Cosigned_Property, @Full_Time_Employed", connection))
                    {
                        command.Parameters.AddWithValue("@ApplicantId", ApplicantId);
                        command.Parameters.AddWithValue("@Not_student", Not_student);
                        command.Parameters.AddWithValue("@Not_Living_In_Cosigned_Property", Not_Living_In_Cosigned_Property);
                        command.Parameters.AddWithValue("@Full_Time_Employed", Full_Time_Employed);
                        response = Convert.ToInt32(command.ExecuteScalar());
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    response = 0;
                }
            }
            return response;
        }
        public int InsertGurantorRenewProcess(GurantorApplicantFormVM model)
        {

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                int response = 0;
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[InsertGurantortRenewProcess]  @UserId, @Name, @Email, @Phonenumber, @CreatedBy,  @Result", connection))
                    {

                        command.Parameters.AddWithValue("@UserId", model.user_id);
                        command.Parameters.AddWithValue("@Name", model.Name == null ? string.Empty : model.Name);
                        command.Parameters.AddWithValue("@Email", model.Email == null ? string.Empty : model.Email);
                        command.Parameters.AddWithValue("@Phonenumber", model.ContactNumber == null ? string.Empty : model.ContactNumber);
                        command.Parameters.AddWithValue("@CreatedBy", model.CreatedBy);

                        command.Parameters.Add("@Result", SqlDbType.Int);
                        command.Parameters["@Result"].Direction = ParameterDirection.Output;
                        response = Convert.ToInt32(command.ExecuteScalar());
                    }
                    connection.Close();
                    return response;
                }
                catch (Exception ex)
                {
                    return 0;
                }
            }
        }

        public int getApplicationCounter(int AgentID, char ApplicationType)
        {
            int retVal = 0;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPGetApplicationCounter] @AgentId, @ApplicationType,  @Result", connection))
                    {
                        command.Parameters.AddWithValue("@AgentId", AgentID);
                        command.Parameters.AddWithValue("@ApplicationType", ApplicationType);
                        command.Parameters.Add("@Result", SqlDbType.Int);
                        command.Parameters["@Result"].Direction = ParameterDirection.Output;
                        retVal = Convert.ToInt32(command.ExecuteScalar());
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    retVal = 0;
                }
            }
            return retVal;
        }

        public int AddUpdateGurantorApplicationForm(GurantorApplicantFormVM model)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                int response = 0;
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPAddUpdateGurantorApplicantForm_v2] @ApplicantId,@UserId, @Name, @Email, @Phonenumber, @StudentForm, @IsDocuments, @StudentBefore, @DateOfBirth, @UniversityId, @StudentStyudingId, @CourseId, @AgentId, @Address, @RentAmt, @RentType, @TenancyStartDate, @TenancyEndDate, @IdentityImage, @DocumentsPath, @CreatedBy, @GurantorCosignerJsonStr, @PostalCode, @StepId,@PaymentType,@PaymentAmount, @PaymentStatus, @EmploymentStatus, @Income, @countryCode,@isManualCountry, @isManulaaddress, @AffiliateId,  @Result", connection))
                    {
                        command.Parameters.AddWithValue("@ApplicantId", model.ApplicantId);
                        command.Parameters.AddWithValue("@UserId", model.user_id);
                        command.Parameters.AddWithValue("@Name", model.Name == null ? string.Empty : model.Name);
                        command.Parameters.AddWithValue("@Email", model.Email == null ? string.Empty : model.Email);
                        command.Parameters.AddWithValue("@Phonenumber", model.ContactNumber == null ? string.Empty : model.ContactNumber);
                        command.Parameters.AddWithValue("@StudentForm", model.StudentFrom == null ? string.Empty : model.StudentFrom);
                        // command.Parameters.AddWithValue("@IsDocuments", model.IsDocuments == null ? string.Empty : model.StudentFrom);
                        if (model.IsDocuments == null)
                        {
                            command.Parameters.AddWithValue("@IsDocuments", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@IsDocuments", model.IsDocuments);
                        }

                        command.Parameters.AddWithValue("@StudentBefore", model.StudentBefore == null ? string.Empty : model.StudentBefore);
                        if (model.DateOfBirth == null)
                        {
                            command.Parameters.AddWithValue("@DateOfBirth", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@DateOfBirth", model.DateOfBirth);
                        }
                        if (model.UniversityId == null)
                            command.Parameters.AddWithValue("@UniversityId", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("@UniversityId", model.UniversityId);
                        if (model.StudentStudyingId == null)
                            command.Parameters.AddWithValue("@StudentStyudingId", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("@StudentStyudingId", model.StudentStudyingId);

                        if (model.CourseId == null)
                            command.Parameters.AddWithValue("@CourseId", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("@CourseId", model.CourseId);

                        if (model.AgentId == null)
                            command.Parameters.AddWithValue("@AgentId", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("@AgentId", model.AgentId);


                        command.Parameters.AddWithValue("@Address", model.Address == null ? string.Empty : model.Address);
                        command.Parameters.AddWithValue("@RentAmt", model.RentAmt == null ? 0 : model.RentAmt);
                        command.Parameters.AddWithValue("@RentType", model.RentType == null ? string.Empty : model.RentType);

                        if (model.TenancyStartDate == null)
                        {
                            command.Parameters.AddWithValue("@TenancyStartDate", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@TenancyStartDate", model.TenancyStartDate);
                        }

                        if (model.TenancyEndDate == null)
                        {
                            command.Parameters.AddWithValue("@TenancyEndDate", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@TenancyEndDate", model.TenancyEndDate);
                        }

                        command.Parameters.AddWithValue("@IdentityImage", model.IdentityImage == null ? string.Empty : model.IdentityImage);
                        command.Parameters.AddWithValue("@DocumentsPath", model.DocumentsPath == null ? string.Empty : model.DocumentsPath);
                        command.Parameters.AddWithValue("@CreatedBy", model.CreatedBy);
                        command.Parameters.AddWithValue("@GurantorCosignerJsonStr", model.CosignerInfoModel != null ? JsonConvert.SerializeObject(model.CosignerInfoModel) : string.Empty);

                        command.Parameters.AddWithValue("@PostalCode", model.PostalCode == null ? "" : model.PostalCode);
                        command.Parameters.AddWithValue("@StepId", model.StepID);

                        command.Parameters.AddWithValue("@PaymentType", model.PaymentType == null ? "" : model.PaymentType);
                        command.Parameters.AddWithValue("@PaymentAmount", model.PaymentAmount);
                        command.Parameters.AddWithValue("@PaymentStatus", model.PaymentStatus == null ? "" : model.PaymentStatus);
                        command.Parameters.AddWithValue("@EmploymentStatus", model.Employment_Status == null ? "" : model.Employment_Status);
                        command.Parameters.AddWithValue("@Income", model.Income == null ? "" : model.Income);
                        command.Parameters.AddWithValue("@countryCode", model.countryCode == null ? "" : model.countryCode);
                        command.Parameters.AddWithValue("@isManualCountry", model.isManualCountry == null ? "" : model.isManualCountry);
                        command.Parameters.AddWithValue("@isManulaaddress", model.isManulaaddress);
                        command.Parameters.AddWithValue("@AffiliateId", model.AffiliateId);

                        command.Parameters.Add("@Result", SqlDbType.Int);
                        command.Parameters["@Result"].Direction = ParameterDirection.Output;
                        response = Convert.ToInt32(command.ExecuteScalar());
                    }
                    connection.Close();
                    return response;
                }
                catch (Exception ex)
                {
                    CommonManager.LogError(MethodBase.GetCurrentMethod(), ex, JsonConvert.SerializeObject(model));
                    return 0;
                }
            }
        }




        public int UpdateGurantorApplicationDefaultStatus(string applicantID)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                int response = 0;
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPUpdateGurantorApplicationDefaultStatus] @ApplicantId, @Result", connection))
                    {
                        command.Parameters.AddWithValue("@ApplicantId", applicantID);


                        command.Parameters.Add("@Result", SqlDbType.Int);
                        command.Parameters["@Result"].Direction = ParameterDirection.Output;
                        response = Convert.ToInt32(command.ExecuteScalar());
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    response = 0;
                }

                return response;

            }

        }

        public int UpdateGurantorApplicationStatus(UpdateGurantorApplicantStatusVM obj)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                int response = 0;
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPUpdateGurantorApplicationStatus] @ApplicantId, @CosignerID, @Status, @Result", connection))
                    {
                        command.Parameters.AddWithValue("@ApplicantId", obj.ApplicantId);
                        command.Parameters.AddWithValue("@CosignerID", obj.CoSignerId);
                        command.Parameters.AddWithValue("@Status", obj.Satus);
                        command.Parameters.AddWithValue("@IsCosigner", obj.IsCosigner);

                        command.Parameters.Add("@Result", SqlDbType.Int);
                        command.Parameters["@Result"].Direction = ParameterDirection.Output;
                        response = Convert.ToInt32(command.ExecuteScalar());
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    response = 0;
                }
                return response;
            }
        }

        public GurantorFeesModel GetGurantorFees(string userId, bool IsFixed, decimal Monthly, decimal OneTime)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                GurantorFeesModel obj = null;
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[GetGuranotorFees_2] @ApplicantId, @IsFixed, @Monthly, @OneTime", connection))
                    {
                        command.Parameters.AddWithValue("@ApplicantId", userId);
                        command.Parameters.AddWithValue("@IsFixed", IsFixed);
                        command.Parameters.AddWithValue("@Monthly", Monthly);
                        command.Parameters.AddWithValue("@OneTime", OneTime);
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                obj = new GurantorFeesModel();
                                //obj.ST_TotalPayble = Convert.ToDecimal(reader["ST_TotalPayble"].ToString());
                                obj.PaybleAmt = Convert.ToDecimal(reader["Totalpayble"]);
                                obj.TotalOneOffPayble = Convert.ToDecimal(reader["TotalOneOffPayble"]);
                                // obj.ST_Upfront_Monthly_Amount = Convert.ToDecimal(reader["ST_Upfront_Monthly_Amount"]);
                                //obj.ST_Upfront_Weekly_Amount = Convert.ToDecimal(reader["ST_Upfront_Weekly_Amount"]);
                                obj.TotalMonthlyInstallment = Convert.ToDecimal(reader["TotalMonthlyInstallment"].ToString());
                                obj.TotalSaved = Convert.ToDecimal(reader["TotalSaved"]);
                                obj.DiscountPercentage = Convert.ToDecimal(reader["DiscountPercentage"]);
                                //obj.WP_Upfront_Monthly_Amount = Convert.ToDecimal(reader["WP_Upfront_Monthly_Amount"]);
                                //obj.WP_Upfront_Weekly_Amount = Convert.ToDecimal(reader["WP_Upfront_Weekly_Amount"]);

                                //  obj.WP_TotalPayble = Convert.ToDecimal(reader["WP_TotalPayble"]);
                                // obj.ST_Upfront = Convert.ToDecimal(reader["ST_Upfront"]);
                                /// obj.WP_Upfront = Convert.ToDecimal(reader["WP_Unfront"]);
                            }
                        }
                    }
                    connection.Close();
                    return obj;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public int UpdateGuranotorFees(GurantorFeesModel obj)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                int response = 0;
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[UpdateGuranotorFees] @TotalpaybleST,@TotalpaybleWP, @TotalpaybleUpfrontOfWP, @TotalpaybleUpfrontOfST, @Result", connection))
                    {
                        //command.Parameters.AddWithValue("@TotalpaybleST", obj.ST_TotalPayble);
                        //command.Parameters.AddWithValue("@TotalpaybleWP", obj.WP_TotalPayble);
                        //command.Parameters.AddWithValue("@TotalpaybleUpfrontOfWP", obj.WP_Upfront);
                        //command.Parameters.AddWithValue("@TotalpaybleUpfrontOfST", obj.ST_Upfront);
                        command.Parameters.Add("@Result", SqlDbType.Int);
                        command.Parameters["@Result"].Direction = ParameterDirection.Output;
                        response = Convert.ToInt32(command.ExecuteScalar());
                    }
                    connection.Close();
                    return response;
                }
                catch (Exception ex)
                {
                    return 0;
                }
            }
        }

        public int UploadCosignerDocuments(GurantorUploadDocumentsModel obj)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                int response = 0;
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[UPSUploadCosignerDocuments] @CosignerId, @FileType, @FilePath, @IsActive, @CreatedBy, @DocumentId, @Result", connection))
                    {
                        command.Parameters.AddWithValue("@CosignerId", obj.UploadedBy);
                        command.Parameters.AddWithValue("@FileType", obj.Type);
                        command.Parameters.AddWithValue("@FilePath", obj.FilePath);
                        command.Parameters.AddWithValue("@IsActive", true);
                        command.Parameters.AddWithValue("@CreatedBy", obj.UploadedBy);
                        command.Parameters.AddWithValue("@DocumentId", obj.DocumentId);

                        command.Parameters.Add("@Result", SqlDbType.Int);
                        command.Parameters["@Result"].Direction = ParameterDirection.Output;
                        response = Convert.ToInt32(command.ExecuteScalar());
                    }
                    connection.Close();
                    return response;
                }
                catch (Exception ex)
                {
                    CommonManager.LogError(MethodBase.GetCurrentMethod(), ex, JsonConvert.SerializeObject(obj));
                    return 0;
                }
            }
        }

        public int UploadGurantorDocuments(GurantorUploadDocumentsModel obj)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                int response = 0;
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[UPSUploadGurantorDocuments] @ApplicantID, @FileType, @FilePath, @IsActive, @CreatedBy,@DocumentId, @Result", connection))
                    {
                        command.Parameters.AddWithValue("@ApplicantID", obj.UploadedBy);
                        command.Parameters.AddWithValue("@FileType", obj.Type);
                        command.Parameters.AddWithValue("@FilePath", obj.FilePath);
                        command.Parameters.AddWithValue("@IsActive", false);
                        command.Parameters.AddWithValue("@CreatedBy", obj.UploadedBy);
                        command.Parameters.AddWithValue("@DocumentId", obj.DocumentId);
                        command.Parameters.Add("@Result", SqlDbType.Int);
                        command.Parameters["@Result"].Direction = ParameterDirection.Output;
                        response = Convert.ToInt32(command.ExecuteScalar());
                    }
                    connection.Close();
                    return response;
                }
                catch (Exception ex)
                {
                    CommonManager.LogError(MethodBase.GetCurrentMethod(), ex, JsonConvert.SerializeObject(obj));
                    return 0;
                }
            }
        }

        public List<GurantorUploadDocumentsModel> GetGurantorDocuments(string applicantId, string isDocumentfor = "")
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                GurantorUploadDocumentsModel obj = null;
                List<GurantorUploadDocumentsModel> listDocs = new List<GurantorUploadDocumentsModel>();
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPGetAllGurantorDocuments] @ApplicantID, @IsDocumentfor", connection))
                    {
                        command.Parameters.AddWithValue("@ApplicantID", applicantId);

                        command.Parameters.AddWithValue("@IsDocumentfor", isDocumentfor);
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                obj = new GurantorUploadDocumentsModel();
                                String strFilePath = reader["FilePath"].ToString() == null ? String.Empty : reader["FilePath"].ToString();

                                // strFilePath = "/Upload/53f1aa6c-acce-408f-935f-10bdb7583d10/Agent/Cover/637479911244984313.png";
                                if (!String.IsNullOrEmpty(strFilePath))
                                {
                                    Uri uriResult;
                                    bool result = Uri.TryCreate(strFilePath, UriKind.Absolute, out uriResult)
                                        && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
                                    if (!result)
                                    {
                                        strFilePath = appBaseAddress + strFilePath;
                                    }
                                }
                                obj.FilePath = strFilePath;
                                if (System.IO.Path.GetExtension(obj.FilePath) == ".pdf")
                                {
                                    obj.FilePath = appBaseAddress + ConfigurationManager.AppSettings["DefaultPdfIcon"].ToString();
                                }
                                obj.Status = Convert.ToString(reader["IsActive"]);
                                obj.Type = Convert.ToInt32(reader["FileType"]);
                                obj.UploadedBy = Convert.ToString(reader["CreatedBy"]);
                                obj.DocumentId = Convert.ToInt32(reader["DocumentId"]);
                                obj.RejectedReason = Convert.ToString(reader["RejectedReason"]);
                                obj.IsRejected = Convert.ToBoolean(reader["IsRejected"]);
                                listDocs.Add(obj);
                            }
                        }
                    }
                    connection.Close();
                    return listDocs;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public int DeleteGurantorFormDocuments(DeleteGurantorDocumentModel obj)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                int response = 0;
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPDeleteGurantorDocument] @ApplicantID, @DocumentId", connection))
                    {
                        command.Parameters.AddWithValue("@ApplicantID", obj.applicantId);
                        command.Parameters.AddWithValue("@DocumentId", obj.DocumentId);
                        response = Convert.ToInt32(command.ExecuteScalar());
                    }
                    connection.Close();
                    return response;
                }
                catch (Exception ex)
                {
                    return 0;
                }
            }
        }
        public GurantorCosignerVM GetCosignerByApplicationId(string ApplicationId)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                GurantorCosignerVM obj = null;
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPGetCosignerByApplicationId] @ApplicationId", connection))
                    {
                        command.Parameters.AddWithValue("@ApplicationId", ApplicationId);

                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                obj = new GurantorCosignerVM();
                                obj.ApplicantId = Convert.ToInt32(reader["ApplicantId"].ToString());
                                obj.CosignerGUID = Convert.ToString(reader["CosignerGUID"]);
                                obj.Email = Convert.ToString(reader["user_email"]);
                                obj.FirstName = Convert.ToString(reader["first_name"]);
                                obj.LastName = Convert.ToString(reader["last_name"]);
                                //obj.PaymentType = Convert.ToString(reader["PaymentType"]);
                                obj.PhoneNumber = Convert.ToString(reader["user_phone"]);
                                obj.Relation = Convert.ToString(reader["Relation"]);
                                obj.RejectedByCosigner = Convert.ToString(reader["RejectedByCosigner"]);
                                obj.RejectedByHH = Convert.ToString(reader["RejectedByHH"]);
                                obj.RejectedReason = Convert.ToString(reader["RejectedReason"]);
                                obj.RejectedNotes = Convert.ToString(reader["RejectedNotes"]);
                                obj.Termschecked = reader["Termschecked"] == null ? false : Convert.ToBoolean(reader["Termschecked"]);
                                obj.not_a_student = reader["not_a_student"] == null ? false : Convert.ToBoolean(reader["not_a_student"]);
                                obj.Not_Living_In_Cosigned_Property = reader["Not_Living_In_Cosigned_Property"] == null ? false : Convert.ToBoolean(reader["Not_Living_In_Cosigned_Property"]);
                                obj.Full_Time_Employed = reader["Full_Time_Employed"] == null ? false : Convert.ToBoolean(reader["Full_Time_Employed"]);
                            }
                        }
                    }
                    connection.Close();
                    return obj;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
        public GurantorCosignerVM GetCosignerInformation(string cosignerId)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                GurantorCosignerVM obj = null;
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPGetCosignerById] @CosignerId", connection))
                    {
                        command.Parameters.AddWithValue("@cosignerId", cosignerId);

                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                obj = new GurantorCosignerVM();
                                obj.ApplicantId = Convert.ToInt32(reader["ApplicantId"].ToString());
                                obj.CosignerGUID = Convert.ToString(reader["CosignerGUID"]);
                                obj.Email = Convert.ToString(reader["Email"]);
                                obj.FirstName = Convert.ToString(reader["FirstName"]);
                                obj.LastName = Convert.ToString(reader["LastName"]);
                                obj.PaymentType = Convert.ToString(reader["PaymentType"]);
                                obj.PhoneNumber = Convert.ToString(reader["PhoneNumber"]);
                                obj.Relation = Convert.ToString(reader["Relation"]);
                                obj.Id = Convert.ToInt32(reader["Id"]);
                                obj.isCosignerdocuments = Convert.ToBoolean(reader["isCosignerdocuments"]);
                            }
                        }
                    }
                    connection.Close();
                    return obj;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public int EditApplicantInfo(EditApplicant applicant)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                int response = 0;
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPUpdateApplicantInfo] @ApplicantID, @TenancyStartDate, @TenancyEndDate, @RentType, @RentAmt,@PropertyToRented, @Result", connection))
                    {
                        command.Parameters.AddWithValue("@ApplicantID", applicant.ApplicantId);
                        command.Parameters.AddWithValue("@TenancyStartDate", applicant.TenancyStartDate);
                        command.Parameters.AddWithValue("@TenancyEndDate", applicant.TenancyEndDate);
                        command.Parameters.AddWithValue("@RentType", applicant.RentType == "PM" ? "Monthly" : "Weekly");
                        command.Parameters.AddWithValue("@RentAmt", applicant.RentAmt);
                        command.Parameters.AddWithValue("@PropertyToRented", applicant.PropertyToRented);
                        command.Parameters.Add("@Result", SqlDbType.Int);
                        command.Parameters["@Result"].Direction = ParameterDirection.Output;
                        response = Convert.ToInt32(command.ExecuteScalar());
                    }
                    connection.Close();
                    return response;
                }
                catch (Exception ex)
                {
                    return 0;
                }
            }

        }

        public int ApproveRejectApplicant(ApprovedRejectApplicantModel applicant)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                int response = 0;
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPApproveRejectApplicant] @ApplicantID, @RejectedReason , @RejetedNotes, @Status,@AP_notice_email, @Property_let_type, @Default_type, @Result", connection))
                    {
                        command.Parameters.AddWithValue("@ApplicantID", applicant.ApplicantId);
                        command.Parameters.AddWithValue("@RejectedReason", applicant.RejectedReason == null ? string.Empty : applicant.RejectedReason);
                        command.Parameters.AddWithValue("@RejetedNotes", applicant.RejectedNotes == null ? string.Empty : applicant.RejectedNotes);
                        command.Parameters.AddWithValue("@Status", applicant.Status);
                        command.Parameters.AddWithValue("@AP_notice_email", applicant.AP_notice_email == null ? string.Empty : applicant.AP_notice_email);
                        command.Parameters.AddWithValue("@Property_let_type", applicant.Property_let_type == null ? string.Empty : applicant.Property_let_type);
                        command.Parameters.AddWithValue("@Default_type", applicant.Default_type == null ? string.Empty : applicant.Default_type);
                        command.Parameters.Add("@Result", SqlDbType.Int);
                        command.Parameters["@Result"].Direction = ParameterDirection.Output;
                        response = Convert.ToInt32(command.ExecuteScalar());
                    }
                    connection.Close();
                    return response;
                }
                catch (Exception ex)
                {
                    return 0;
                }
            }

        }


        //private List<GurantorUploadDocumentsModel> GetCosignerDocuments(string cosignerID)
        //{
        //    using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
        //    {
        //        GurantorUploadDocumentsModel obj = null;
        //        List<GurantorUploadDocumentsModel> listDocs = new List<GurantorUploadDocumentsModel>();
        //        try
        //        {
        //            connection.Open();
        //            using (SqlCommand command = new SqlCommand("Exec [dbo].[USPGetAllCosignerDocuments] @CosignerID", connection))
        //            {
        //                command.Parameters.AddWithValue("@CosignerID", cosignerID);

        //                SqlDataReader reader = command.ExecuteReader();
        //                if (reader.HasRows)
        //                {
        //                    while (reader.Read())
        //                    {
        //                        obj = new GurantorUploadDocumentsModel();
        //                        obj.FilePath = Convert.ToString(reader["FilePath"].ToString());
        //                        obj.Status = Convert.ToString(reader["IsActive"]);
        //                        obj.Type = Convert.ToInt32(reader["FileType"]);
        //                        obj.UploadedBy = Convert.ToString(reader["CreatedBy"]);
        //                        listDocs.Add(obj);
        //                    }
        //                }
        //            }
        //            connection.Close();
        //            return listDocs;
        //        }
        //        catch (Exception ex)
        //        {
        //            return null;
        //        }
        //    }
        //}

        //public int SaveGuarantorStudy(GurantortStudyModel obj)
        //{
        //    using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
        //    {
        //        int response = 0;
        //        try
        //        {
        //            connection.Open();
        //            using (SqlCommand command = new SqlCommand("Exec [dbo].[UPSSaveGuarantorStudy] @UserId,@Name, @Email,@PhoneNumber,@StudentBefore, @DateOfBirth, @UniversityId, @StudentStudyingId,@CourseId, @Result", connection))
        //            {
        //                command.Parameters.AddWithValue("@UserId", obj.UserId);
        //                command.Parameters.AddWithValue("@Name", obj.Name);
        //                command.Parameters.AddWithValue("@Email", obj.Email);
        //                command.Parameters.AddWithValue("@PhoneNumber", obj.PhoneNumber);
        //                command.Parameters.AddWithValue("@StudentBefore", obj.StudentBefore);
        //                command.Parameters.AddWithValue("@DateOfBirth", obj.DateOfBirth);
        //                command.Parameters.AddWithValue("@UniversityId", obj.UniversityId);
        //                command.Parameters.AddWithValue("@StudentStudyingId", obj.StudentStudyingId);
        //                command.Parameters.AddWithValue("@CourseId", obj.CourseId);

        //                command.Parameters.Add("@Result", SqlDbType.Int);
        //                command.Parameters["@Result"].Direction = ParameterDirection.Output;
        //                response = Convert.ToInt32(command.ExecuteScalar());
        //            }
        //            connection.Close();
        //            return response;
        //        }
        //        catch (Exception ex)
        //        {
        //            return 0;
        //        }
        //    }
        //}
        //public int SaveGurantorAccomodation(GurantorAccomodationModel obj)
        //{
        //    using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
        //    {
        //        int response = 0;
        //        try
        //        {
        //            connection.Open();
        //            using (SqlCommand command = new SqlCommand("Exec [dbo].[UPSGurantorAccomodation] @ApplicantId,@AgentId, @Address,@Postcode,@RentAmt, @RentType, @TenancyStartDate, @TenancyEndDate, @Result", connection))
        //            {

        //                command.Parameters.AddWithValue("@ApplicantId", obj.ApplicantId);
        //                command.Parameters.AddWithValue("@AgentId", obj.AgentId);
        //                command.Parameters.AddWithValue("@Address", obj.Address);
        //                command.Parameters.AddWithValue("@Postcode", obj.PostalCode);
        //                command.Parameters.AddWithValue("@RentAmt", obj.RentAmt);
        //                command.Parameters.AddWithValue("@RentType", obj.RentType);
        //                command.Parameters.AddWithValue("@TenancyStartDate", obj.TenancyStartDate);
        //                command.Parameters.AddWithValue("@TenancyEndDate", obj.TenancyEndDate);

        //                command.Parameters.Add("@Result", SqlDbType.Int);
        //                command.Parameters["@Result"].Direction = ParameterDirection.Output;
        //                response = Convert.ToInt32(command.ExecuteScalar());
        //            }
        //            connection.Close();
        //            return response;
        //        }
        //        catch (Exception ex)
        //        {
        //            return 0;
        //        }
        //    }
        //}

        public int CosignerNotInterested(int ApplicantId, String RejectedReason, String RejectedNotes)
        {
            int retval = 0;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPCosignerNotInterested]  @ApplicantID, @RejectedReason, @RejectedNotes, @Result", connection))
                    {
                        command.Parameters.AddWithValue("@ApplicantID", ApplicantId);
                        command.Parameters.AddWithValue("@RejectedReason", RejectedReason);
                        command.Parameters.AddWithValue("@RejectedNotes", RejectedNotes);
                        command.Parameters.Add("@Result", SqlDbType.Int);
                        command.Parameters["@Result"].Direction = ParameterDirection.Output;
                        retval = Convert.ToInt32(command.ExecuteScalar());
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    retval = 0;
                }
            }

            return retval;
        }

        public int UpdateGurantorRenewalStatus(int applicantId, int status)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                int response = 0;
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPUpdateGurantorRenewalStatus] @ApplicantId, @Status, @Result", connection))
                    {
                        command.Parameters.AddWithValue("@ApplicantId", applicantId);
                        command.Parameters.AddWithValue("@Status", status);
                        command.Parameters.Add("@Result", SqlDbType.Int);
                        command.Parameters["@Result"].Direction = ParameterDirection.Output;
                        response = Convert.ToInt32(command.ExecuteScalar());
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    response = 0;
                }
                return response;
            }
        }
    }
}

