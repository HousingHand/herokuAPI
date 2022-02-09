using HHPassport.BAL.Interface;
using System;
using System.Collections.Generic;
using HHPassport.DAL.Models;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using HHPassport.DAL.Helpers;
using static HHPassport.DAL.Enums.EnumHelper;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
//using HH_PassportModel;

namespace HHPassport.BAL.Service
{
    public class UserBusiness : IUserBusiness
    {
        readonly string appBaseAddress = ConfigurationManager.AppSettings["BaseAddress"].ToString();
        public int AddUpdateUser(UserModel model, string ServiceIds)
        {
            if (model.Id == 0 && model.RoleName != RolesEnum.Agent.ToString() && model.RoleName!= RolesEnum.Admin.ToString())
            {
                string policyNumber = string.Empty;
                policyNumber = model.first_name[0].ToString().ToUpper() + model.last_name[0].ToString().ToUpper() + "-";
                string random = CommonManager.RandomString(6);
                model.policy_number = policyNumber + random;
            }

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                int response = 0;
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPAddUpdateUser] @Id, @UserId, @CompanyName, @FirstName, @MiddleName, @LastName, @EmailAddress, @PhoneNumber, @Address, @City, @State, @ZipCode, @Gender, @Origin, @Ethnicity, @Nationality, @DOB, @LanguagePreference, @AboutMe, @ProfilePic, @QRCode, @UserType, @SocialLoginAuthenticationKey, @ServiceIds, @policy_number, @Latitude, @Longitude, @WebsiteUrl, @Description, @Status, @Result", connection))
                    {
                        command.Parameters.AddWithValue("@Id", model.Id);
                        command.Parameters.AddWithValue("@UserId", model.user_id);
                        command.Parameters.AddWithValue("@CompanyName", model.company_name == null ? string.Empty : model.company_name);
                        command.Parameters.AddWithValue("@FirstName", model.first_name == null ? string.Empty : model.first_name);
                        command.Parameters.AddWithValue("@MiddleName", model.middle_initial == null ? DBNull.Value.ToString() : model.middle_initial);
                        command.Parameters.AddWithValue("@LastName", model.last_name == null ? DBNull.Value.ToString() : model.last_name);
                        command.Parameters.AddWithValue("@EmailAddress", model.user_email == null ? DBNull.Value.ToString() : model.user_email);
                        command.Parameters.AddWithValue("@PhoneNumber", model.user_phone == null ? DBNull.Value.ToString() : model.user_phone);
                        command.Parameters.AddWithValue("@Address", model.address == null ? DBNull.Value.ToString() : model.address);
                        command.Parameters.AddWithValue("@City", model.city == null ? 0 : model.city);
                        command.Parameters.AddWithValue("@State", model.state == null ? 0 : model.state);
                        command.Parameters.AddWithValue("@ZipCode", model.zip == null ? DBNull.Value.ToString() : model.zip);
                        command.Parameters.AddWithValue("@Gender", model.gender == null ? DBNull.Value.ToString() : model.gender);
                        command.Parameters.AddWithValue("@Origin", model.origin == null ? 0 : model.origin);
                        command.Parameters.AddWithValue("@Ethnicity", model.ethnicity == null ? 0 : model.ethnicity);
                        command.Parameters.AddWithValue("@Nationality", model.nationality == null ? string.Empty : model.nationality);
                        if (model.date_of_birth == null)
                        {
                            command.Parameters.AddWithValue("@DOB", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@DOB", model.date_of_birth);
                        }

                        command.Parameters.AddWithValue("@LanguagePreference", model.language_preferance == null ? string.Empty : model.language_preferance);
                        command.Parameters.AddWithValue("@AboutMe", model.About_me == null ? string.Empty : model.About_me);
                        command.Parameters.AddWithValue("@ProfilePic", model.profile_pic == null ? string.Empty : model.profile_pic);

                        command.Parameters.AddWithValue("@QRCode", model.QRCode == null ? string.Empty : model.QRCode);
                        command.Parameters.AddWithValue("@UserType", model.user_type == null ? string.Empty : model.user_type);
                        command.Parameters.AddWithValue("@SocialLoginAuthenticationKey", model.SocialLoginAuthenticationKey == null ? string.Empty : model.SocialLoginAuthenticationKey);
                        command.Parameters.AddWithValue("@ServiceIds", ServiceIds == null ? string.Empty : ServiceIds);
                        command.Parameters.AddWithValue("@policy_number", model.policy_number == null ? string.Empty : model.policy_number);

                        command.Parameters.AddWithValue("@Latitude", model.Latitude == null ? string.Empty : model.Latitude);
                        command.Parameters.AddWithValue("@Longitude", model.Longitude == null ? string.Empty : model.Longitude);
                        command.Parameters.AddWithValue("@WebsiteUrl", model.WebsiteUrl == null ? string.Empty : model.WebsiteUrl);
                        command.Parameters.AddWithValue("@Description", model.Description == null ? string.Empty : model.Description);

                        command.Parameters.AddWithValue("@Status", model.Status == null ? string.Empty : model.Status);


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
        public GurantorCosignerVM GetCosignerDetailByEmail(String Email_Id)
        {
            try
            {
                GurantorCosignerVM objCosigner = new GurantorCosignerVM();
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPGetCosignerDetailByEmail] @EmailId", connection))
                    {
                        command.Parameters.AddWithValue("@EmailId", Email_Id == null ? string.Empty : Email_Id);
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                objCosigner.ApplicantId = Convert.ToInt32(reader["ApplicantId"].ToString());
                                objCosigner.CosignerGUID = reader["COSIGNERGUId"].ToString();
                                objCosigner.User_id = reader["User_id"].ToString();

                                objCosigner.Relation = reader["RELATION"].ToString();
                                objCosigner.RejectedByCosigner = reader["RejectedByCosigner"].ToString();
                                objCosigner.RejectedByHH = reader["RejectedByHH"].ToString();
                                objCosigner.RejectedReason = reader["RejectedReason"].ToString() != DBNull.Value.ToString() ? reader["RejectedReason"].ToString() : string.Empty;
                                objCosigner.RejectedNotes = reader["RejectedNotes"].ToString() != DBNull.Value.ToString() ? reader["RejectedNotes"].ToString() : string.Empty;
                                objCosigner.Termschecked = Convert.ToBoolean(reader["Termschecked"].ToString() != DBNull.Value.ToString() ? reader["Termschecked"].ToString() : "0");
                                objCosigner.not_a_student = Convert.ToBoolean(reader["not_a_student"].ToString() != DBNull.Value.ToString() ? reader["not_a_student"].ToString() : "0");
                                objCosigner.Not_Living_In_Cosigned_Property = Convert.ToBoolean(reader["Not_Living_In_Cosigned_Property"].ToString() != DBNull.Value.ToString() ? reader["Not_Living_In_Cosigned_Property"].ToString() : "0");
                                objCosigner.Full_Time_Employed = Convert.ToBoolean(reader["Full_Time_Employed"].ToString() != DBNull.Value.ToString() ? reader["Full_Time_Employed"].ToString() : "0");
                                objCosigner.FirstName = reader["first_name"].ToString() != DBNull.Value.ToString() ? reader["first_name"].ToString() : string.Empty;
                                objCosigner.LastName = reader["last_name"].ToString() != DBNull.Value.ToString() ? reader["last_name"].ToString() : string.Empty;
                                objCosigner.Email = reader["user_email"].ToString();
                                objCosigner.PhoneNumber = reader["user_phone"].ToString() != DBNull.Value.ToString() ? reader["user_phone"].ToString() : string.Empty;
                                if (reader["TenancyStartDate"] is DBNull)
                                {
                                    objCosigner.TenancyStartDate = null;
                                }
                                else
                                {
                                    objCosigner.TenancyStartDate = Convert.ToDateTime(reader["TenancyStartDate"].ToString());
                                }

                                if (reader["TenancyEndDate"] is DBNull)
                                {
                                    objCosigner.TenancyEndDate = null;
                                }
                                else
                                {
                                    objCosigner.TenancyEndDate = Convert.ToDateTime(reader["TenancyEndDate"].ToString());
                                }

                                objCosigner.ApplicationIsActive = reader["IsActive"] is DBNull ? false : Convert.ToBoolean(reader["IsActive"].ToString());
                            }
                        }
                    }
                }

                return objCosigner;
            }
            catch (Exception ex)
            {
                return new GurantorCosignerVM();
            }

        }
        public int UpdateUserTypeAndNationality(string userId, string UserType, string Nationality, Boolean IsRenewal)
        {
            int RetVal = 0;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("Exec [dbo].[USPUpdateUserTypeAndNationality] @UserId, @UserType, @Nationality, @IsRenewal, @Result", connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId == null ? string.Empty : userId);
                    command.Parameters.AddWithValue("@UserType", UserType);
                    command.Parameters.AddWithValue("@Nationality", Nationality);
                    command.Parameters.AddWithValue("@IsRenewal", IsRenewal);
                    command.Parameters.Add("@Result", SqlDbType.Int);
                    command.Parameters["@Result"].Direction = ParameterDirection.Output;
                    RetVal = Convert.ToInt32(command.ExecuteScalar());
                }
                return RetVal;
            }
        }
        public List<UserModel> GetAllUsers(int id, string userId, string roleName, int pageIndex,
    int pageSize, string searchStr)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                List<UserModel> objAgentList = new List<UserModel>();
                UserModel obj = null;
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPGetUsers_v2] @Id, @UserId, @RoleName, @SearchStr, @PageNumber, @PageSize", connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        command.Parameters.AddWithValue("@UserId", userId == null ? string.Empty : userId);
                        command.Parameters.AddWithValue("@RoleName", roleName);
                        command.Parameters.AddWithValue("@SearchStr", searchStr == null ? string.Empty : searchStr.Replace(" ", ""));
                        command.Parameters.AddWithValue("@PageNumber", pageIndex == 0 ? 1 : pageIndex);
                        command.Parameters.AddWithValue("@PageSize", pageSize == 0 ? Convert.ToInt32(ConfigurationManager.AppSettings["PageSize"].ToString()) : pageSize);
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                obj = new UserModel();
                                obj.Id = Convert.ToInt32(reader["id"].ToString());
                                obj.user_id = reader["user_id"].ToString();
                                obj.ApplicationId = reader["Applicantid"].ToString();
                                obj.company_name = reader["company_name"].ToString() != DBNull.Value.ToString() ? reader["company_name"].ToString() : string.Empty;
                                obj.first_name = reader["first_name"].ToString() != DBNull.Value.ToString() ? reader["first_name"].ToString() : string.Empty;
                                obj.middle_initial = reader["middle_initial"].ToString() != DBNull.Value.ToString() ? reader["middle_initial"].ToString() : string.Empty;
                                obj.last_name = reader["last_name"].ToString() != DBNull.Value.ToString() ? reader["last_name"].ToString() : string.Empty;
                                obj.user_email = reader["user_email"].ToString() != DBNull.Value.ToString() ? reader["user_email"].ToString() : string.Empty;
                                obj.user_phone = reader["user_phone"].ToString() != DBNull.Value.ToString() ? reader["user_phone"].ToString() : string.Empty;
                                obj.address = reader["address"].ToString() != DBNull.Value.ToString() ? reader["address"].ToString() : string.Empty;
                                if (reader["city"] is DBNull)
                                {
                                    obj.city = 0;
                                }
                                else
                                {
                                    obj.city = Convert.ToInt32(reader["city"].ToString());
                                }
                                if (reader["state"] is DBNull)
                                {
                                    obj.state = 0;
                                }
                                else
                                {
                                    obj.state = Convert.ToInt32(reader["state"].ToString());
                                }

                                obj.zip = reader["zip"].ToString() != DBNull.Value.ToString() ? reader["zip"].ToString() : string.Empty;
                                obj.gender = reader["gender"].ToString() != DBNull.Value.ToString() ? reader["gender"].ToString() : string.Empty;
                                if (reader["origin"] is DBNull)
                                {
                                    obj.origin = 0;
                                }
                                else
                                {
                                    obj.origin = Convert.ToInt32(reader["origin"].ToString());
                                }
                                if (reader["ethnicity"] is DBNull)
                                {
                                    obj.ethnicity = 0;
                                }
                                else
                                {
                                    obj.ethnicity = Convert.ToInt32(reader["ethnicity"].ToString());
                                }

                                obj.nationality = reader["nationality"].ToString() != DBNull.Value.ToString() ? reader["nationality"].ToString() : string.Empty;
                                if (reader["date_of_birth"] is DBNull)
                                {
                                    obj.date_of_birth = null;
                                }
                                else
                                {
                                    obj.date_of_birth = Convert.ToDateTime(reader["date_of_birth"].ToString());
                                    obj.DOBStr = Convert.ToDateTime(reader["date_of_birth"].ToString()).ToShortDateString();
                                }
                                obj.language_preferance = reader["language_preferance"].ToString() != DBNull.Value.ToString() ? reader["language_preferance"].ToString() : string.Empty;
                                obj.About_me = reader["About_me"].ToString() != DBNull.Value.ToString() ? reader["About_me"].ToString() : string.Empty;
                                string strFilePath = reader["profile_pic"].ToString() != DBNull.Value.ToString() ? reader["profile_pic"].ToString() : string.Empty;
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

                                obj.profile_pic = strFilePath;

                                //obj.profile_pic = reader["profile_pic"].ToString() != DBNull.Value.ToString() ? reader["profile_pic"].ToString() : string.Empty;
                                obj.QRCode = reader["QRCode"].ToString() != DBNull.Value.ToString() ? reader["QRCode"].ToString() : string.Empty;
                                obj.user_type = reader["user_type"].ToString() != DBNull.Value.ToString() ? reader["user_type"].ToString() : string.Empty;
                                obj.SocialLoginAuthenticationKey = reader["SocialLoginAuthenticationKey"].ToString() != DBNull.Value.ToString() ? reader["SocialLoginAuthenticationKey"].ToString() : string.Empty;
                                obj.is_active = Convert.ToBoolean(reader["is_active"].ToString());
                                if (reader["created_on"] is DBNull)
                                {
                                    obj.created_on = null;
                                }
                                else
                                {
                                    obj.created_on = Convert.ToDateTime(reader["created_on"].ToString());
                                }

                                if (reader["last_login"] is DBNull)
                                {
                                    obj.last_login = null;
                                }
                                else
                                {
                                    obj.last_login = Convert.ToDateTime(reader["last_login"].ToString());
                                }

                                if (reader["modified_on"] is DBNull)
                                {
                                    obj.modified_on = null;
                                }
                                else
                                {
                                    obj.modified_on = Convert.ToDateTime(reader["modified_on"].ToString());
                                }

                                obj.policy_number = Convert.ToString(reader["policy_number"]);

                                obj.RoleName = reader["RoleName"].ToString();
                                obj.RoleID = reader["RoleId"].ToString();
                                obj.AgentInfo = new AgentInfoModel();
                                if (obj.RoleName == RolesEnum.Agent.ToString())
                                {
                                    obj.AgentInfo = GetAgentInfo(obj.user_id);
                                }
                                if (obj.city.Value > 0)
                                {
                                    if (CommonManager.getCities().Any(c => c.Id == obj.city.Value))
                                    {
                                        obj.CityName = CommonManager.getCities().Where(c => c.Id == obj.city.Value).Select(c => c.cityname).FirstOrDefault();
                                    }
                                }

                                if (obj.state.Value > 0)
                                {

                                    if (CommonManager.getStates().Any(c => c.Id == obj.state.Value))
                                    {
                                        obj.StateName = CommonManager.getStates().Where(c => c.Id == obj.state.Value).Select(c => c.statename).FirstOrDefault();
                                    }
                                }
                                obj.isdocuments = reader["is_document"].ToString();
                                obj.is_documents_approved = reader["is_approved_document"].ToString();
                                obj.Latitude = reader["Latitude"] is DBNull ? string.Empty : reader["Latitude"].ToString();
                                obj.Longitude = reader["Longitude"] is DBNull ? string.Empty : reader["Longitude"].ToString();
                                obj.WebsiteUrl = reader["WebsiteUrl"] is DBNull ? string.Empty : reader["WebsiteUrl"].ToString();
                                obj.Description = reader["Description"] is DBNull ? string.Empty : reader["Description"].ToString();
                                obj.TotalRows = Convert.ToInt32(reader["TotalRows"].ToString());
                                if (reader["TermsChecked"] is DBNull)
                                    obj.TermsCheckedByCo = false;
                                else
                                    obj.TermsCheckedByCo = Convert.ToBoolean(reader["TermsChecked"].ToString());

                                if (reader["LastLoginTime"] is DBNull)
                                {
                                    obj.last_login = null;
                                }
                                else
                                {
                                    obj.last_login = Convert.ToDateTime(reader["LastLoginTime"].ToString());

                                }
                                objAgentList.Add(obj);
                            }
                        }
                    }
                    connection.Close();
                    return objAgentList;
                }
                catch (Exception ex)
                {
                    return new List<UserModel>();
                }
            }
        }

        public List<UserModel> GetAgentByTitle(string searchStr)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                List<UserModel> objAgentList = new List<UserModel>();
                UserModel obj = null;
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPGetAgentByTitle]  @SearchStr ", connection))
                    {

                        command.Parameters.AddWithValue("@SearchStr", searchStr == null ? string.Empty : searchStr.Replace(" ", ""));

                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                obj = new UserModel();
                                obj.Id = Convert.ToInt32(reader["id"].ToString());
                                obj.first_name = reader["Title"].ToString() != DBNull.Value.ToString() ? reader["Title"].ToString() : string.Empty;
                                objAgentList.Add(obj);
                            }
                        }
                    }
                    connection.Close();
                    return objAgentList;
                }
                catch (Exception ex)
                {
                    return new List<UserModel>();
                }
            }
        }
        public int AddUpdateUserService(UserServiceNewModel obj)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                int response = 0;
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPAddUpdateUserService] @service_id, @user_id, @Result", connection))
                    {
                        command.Parameters.AddWithValue("@service_id", obj.service_id);
                        command.Parameters.AddWithValue("@user_id", obj.applicant_id);

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
        public int AddUpdateAgentInfo(AgentInfoModel model)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                int response = 0;
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPAddUpdateAgentInfo] @AgentId, @Title, @LogoPath, @CoverImagePath, @APType, @CreatedBy, @Result", connection))
                    {
                        command.Parameters.AddWithValue("@AgentId", model.AgentId);
                        command.Parameters.AddWithValue("@Title", model.Title);
                        command.Parameters.AddWithValue("@LogoPath", string.IsNullOrEmpty(model.LogoPath) ? string.Empty : model.LogoPath);
                        command.Parameters.AddWithValue("@APType", string.IsNullOrEmpty(model.AP_Type) ? string.Empty : model.AP_Type);
                        command.Parameters.AddWithValue("@CoverImagePath", string.IsNullOrEmpty(model.CoverImagePath) ? string.Empty : model.CoverImagePath);
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
                    CommonManager.LogError(MethodBase.GetCurrentMethod(), ex, JsonConvert.SerializeObject(model));
                    return 0;
                }
            }
        }
        public AgentInfoModel GetAgentInfo(string agentId)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                AgentInfoModel obj = new AgentInfoModel();
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPGetAgentInfo] @AgentId", connection))
                    {
                        command.Parameters.AddWithValue("@AgentId", agentId);
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                obj = new AgentInfoModel();
                                obj.Id = Convert.ToInt32(reader["id"].ToString());
                                obj.AgentId = reader["AgentId"].ToString();
                                obj.Title = reader["Title"].ToString();
                                obj.AP_Type = reader["APType"].ToString();
                                obj.LogoPath = reader["LogoPath"].ToString() != DBNull.Value.ToString() ? reader["LogoPath"].ToString() : string.Empty;
                                obj.CoverImagePath = reader["CoverImagePath"].ToString() != DBNull.Value.ToString() ? reader["CoverImagePath"].ToString() : string.Empty;

                                obj.IsPEDChecked = reader["IsPEDChecked"] is DBNull ? false : Convert.ToBoolean(reader["IsPEDChecked"]);

                                obj.IsTermsnAndConditionChecked = reader["IsTermsnAndConditionChecked"] is DBNull ? false : Convert.ToBoolean(reader["IsTermsnAndConditionChecked"]);
                            }
                        }
                    }
                    connection.Close();
                    return obj;
                }
                catch (Exception ex)
                {
                    return new AgentInfoModel();
                }
            }
        }
        //public int UpdateUserProfilePic(UserProfilePicModel obj)
        //{
        //    using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
        //    {
        //        int response = 0;
        //        try
        //        {
        //            connection.Open();
        //            using (SqlCommand command = new SqlCommand("Exec [dbo].[USPAddUpdateUserProfilePic] @user_id, @profile_pic, @Result", connection))
        //            {
        //                command.Parameters.AddWithValue("@user_id", obj.user_id);
        //                command.Parameters.AddWithValue("@profile_pic", obj.profile_pic);

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

        public List<CustomApplicantVM> GetApplicantList(string userId, bool isDashboard = false, string status = "")
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                List<CustomApplicantVM> objList = new List<CustomApplicantVM>();
                CustomApplicantVM obj = null;
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPGetApplicantList_v2] @UserId , @IsDashboard, @Status", connection))
                    {
                        command.Parameters.AddWithValue("@UserId", userId == null ? string.Empty : userId);
                        command.Parameters.AddWithValue("@IsDashboard", isDashboard);
                        command.Parameters.AddWithValue("@Status", status == null ? string.Empty : status);
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                obj = new CustomApplicantVM();
                                obj.ApplicantId = Convert.ToInt32(reader["ApplicantId"].ToString());
                                obj.ApplicantGUID = reader["ApplicantGUID"].ToString();
                                obj.ApplicantUserId = reader["ApplicantUserId"].ToString();
                                obj.AgentId = Convert.ToInt32(reader["AgentId"].ToString());
                                obj.Name = reader["Name"].ToString();
                                obj.Email = reader["Email"].ToString();
                                obj.Gender = reader["Gender"].ToString();
                                obj.Age = Convert.ToInt32(reader["Age"].ToString());
                                obj.PhoneNumber = reader["PhoneNumber"].ToString();
                                obj.StudentBefore = reader["StudentBefore"].ToString();
                                obj.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"].ToString());
                                obj.PostalCode = reader["PostalCode"].ToString();
                                obj.Address = reader["Address"].ToString();
                                obj.RentAmt = Convert.ToDecimal(reader["RentAmt"].ToString());
                                obj.RentType = reader["RentType"].ToString();
                                obj.TenancyStartDate = Convert.ToDateTime(reader["TenancyStartDate"].ToString());
                                obj.TenancyEndDate = Convert.ToDateTime(reader["TenancyEndDate"].ToString());
                                obj.ApplicationDate = Convert.ToDateTime(reader["ApplicationDate"].ToString());
                                obj.PolicyNumber = reader["PolicyNumber"].ToString();

                                obj.TenancyStartDateStr = reader["TenancyStartDateStr"] == null ? string.Empty : reader["TenancyStartDateStr"].ToString();
                                obj.TenancyEndDateStr = reader["TenancyEndDateStr"] == null ? string.Empty : reader["TenancyEndDateStr"].ToString();

                                obj.Status = reader["Status"].ToString();

                                obj.AP_Status = reader["AP_Status"].ToString();
                                obj.IsRejectedByCosigner = reader["IsRejectedByCosigner"].ToString();
                                obj.IsCosignerRejectedByHH = reader["IsCosignerRejectedByHH"].ToString();
                                obj.ApplicantDocumentStatus = reader["ApplicantDocumentStatus"].ToString();
                                obj.CosignerDocumentStatus = reader["CosignerDocumentStatus"].ToString();
                                obj.PaymentStatus = reader["PaymentStatus"].ToString();
                                obj.RejectedReason = reader["RejectedReason"].ToString();
                                obj.RejectedNotes = reader["RejectedNotes"].ToString();
                                obj.AP_RejectedReason = reader["AP_RejectedReason"].ToString();
                                obj.AP_RejectedNotes = reader["AP_RejectedNotes"].ToString();
                                obj.AP_notice_email = reader["AP_notice_email"].ToString();
                                obj.Property_let_type = reader["Property_let_type"].ToString();
                                obj.Default_type = reader["Default_type"].ToString();
                                if (reader["RejectedDate"] is DBNull)
                                {
                                    obj.RejectedDate = null;
                                }
                                else
                                {
                                    obj.RejectedDate = Convert.ToDateTime(reader["RejectedDate"].ToString());
                                }

                                if (reader["AP_RejectedDate"] is DBNull)
                                {
                                    obj.AP_RejectedDate = null;
                                }
                                else
                                {
                                    obj.AP_RejectedDate = Convert.ToDateTime(reader["Ap_RejectedDate"].ToString());
                                }

                                obj.IsDisabled = Convert.ToBoolean(reader["IsDisabled"].ToString());
                                obj.TendencyDurationInMonth = Convert.ToInt32(reader["TendencyDurationInMonth"].ToString());

                                obj.ProfileImg = reader["ProfileImg"].ToString();
                                if (obj.ProfileImg.IndexOf("assets") == 0)
                                {

                                }
                                else
                                {
                                    obj.ProfileImg = ConfigurationManager.AppSettings["BaseAddress"].ToString() + reader["ProfileImg"].ToString();
                                }

                                //obj.GurantorStatus = Convert.ToString(reader["GurantorStatus"]);
                                obj.Country = Convert.ToString(reader["Nationality"]);
                                obj.IsDefault = Convert.ToBoolean(reader["IsDefault"]);
                                obj.CosignerStatus = reader["CosignerStatus"] is DBNull ? string.Empty : reader["CosignerStatus"].ToString();
                                objList.Add(obj);
                            }
                        }
                    }
                    connection.Close();
                    return objList;
                }
                catch (Exception ex)
                {
                    return new List<CustomApplicantVM>();
                }
            }
        }

        public List<CustomApplicantVM> GetTenantApplicantList(string userId, DateTime? startDate, DateTime? endDate, string searchStr = "", int pagesize = 20, int currentPage = 1, Char Status = 'A')
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                List<CustomApplicantVM> objList = new List<CustomApplicantVM>();
                CustomApplicantVM obj = null;
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPGetTenantApplicantList_v1] @UserId , @StartDate, @EndDate, @Searchstr, @PageSize,@PageNumber, @Status", connection))
                    {
                        command.Parameters.AddWithValue("@UserId", userId);
                        if (startDate.HasValue)
                            command.Parameters.AddWithValue("@StartDate", startDate);
                        else
                            command.Parameters.AddWithValue("@StartDate", DBNull.Value);

                        if (endDate.HasValue)
                            command.Parameters.AddWithValue("@EndDate", endDate);
                        else
                            command.Parameters.AddWithValue("@EndDate", DBNull.Value);


                        command.Parameters.AddWithValue("@Searchstr", searchStr == null ? string.Empty : searchStr);
                        command.Parameters.AddWithValue("@PageSize", pagesize);
                        command.Parameters.AddWithValue("@PageNumber", currentPage);
                        command.Parameters.AddWithValue("@Status", Status);

                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                obj = new CustomApplicantVM();
                                obj.ApplicantId = Convert.ToInt32(reader["ApplicantId"].ToString());
                                obj.ApplicantGUID = reader["ApplicantGUID"].ToString();
                                obj.ApplicantUserId = reader["ApplicantUserId"].ToString();
                                ///obj.AgentId = Convert.ToInt32(reader["AgentId"].ToString());
                                obj.Name = reader["Name"].ToString();
                                obj.Email = reader["Email"].ToString();
                                obj.Gender = reader["Gender"].ToString();
                                if (reader["Age"] is DBNull)
                                {
                                    obj.Age = 0;
                                }
                                else
                                {
                                    obj.Age = Convert.ToInt32(reader["Age"].ToString());
                                }

                                obj.PhoneNumber = reader["PhoneNumber"].ToString();
                                obj.StudentBefore = reader["StudentBefore"].ToString();
                                if (reader["DateOfBirth"] is DBNull)
                                {
                                    obj.DateOfBirth = null;
                                }
                                else
                                {
                                    obj.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"].ToString());
                                }

                                obj.PostalCode = reader["PostalCode"].ToString();
                                obj.Address = reader["Address"].ToString();
                                obj.RentAmt = Convert.ToDecimal(reader["RentAmt"].ToString());
                                obj.RentType = reader["RentType"].ToString();
                                obj.TenancyStartDate = Convert.ToDateTime(reader["TenancyStartDate"].ToString());
                                obj.TenancyEndDate = Convert.ToDateTime(reader["TenancyEndDate"].ToString());
                                obj.ApplicationDate = Convert.ToDateTime(reader["ApplicationDate"].ToString());
                                obj.PolicyNumber = reader["PolicyNumber"].ToString();

                                obj.TenancyStartDateStr = reader["TenancyStartDateStr"] == null ? string.Empty : reader["TenancyStartDateStr"].ToString();
                                obj.TenancyEndDateStr = reader["TenancyEndDateStr"] == null ? string.Empty : reader["TenancyEndDateStr"].ToString();

                                obj.Status = reader["Status"].ToString();
                                obj.RejectedReason = reader["RejectedReason"].ToString();
                                obj.RejectedNotes = reader["RejectedNotes"].ToString();
                                if (reader["RejectedDate"] is DBNull)
                                {
                                    obj.RejectedDate = null;
                                }
                                else
                                {
                                    obj.RejectedDate = Convert.ToDateTime(reader["RejectedDate"].ToString());
                                }
                                obj.IsDisabled = Convert.ToBoolean(reader["IsDisabled"].ToString());
                                obj.TendencyDurationInMonth = Convert.ToInt32(reader["TendencyDurationInMonth"].ToString());

                                obj.ProfileImg = reader["ProfileImg"].ToString();
                                if (obj.ProfileImg.IndexOf("assets") == 0)
                                {

                                }
                                else
                                {
                                    obj.ProfileImg = ConfigurationManager.AppSettings["BaseAddress"].ToString() + reader["ProfileImg"].ToString();
                                }

                                obj.GurantorStatus = Convert.ToString(reader["GurantorStatus"]);
                                obj.Country = Convert.ToString(reader["Nationality"]);
                                obj.IsDefault = Convert.ToBoolean(reader["IsDefault"]);
                                obj.TenantType = reader["TenantType"].ToString();

                                objList.Add(obj);
                            }
                        }
                    }
                    connection.Close();
                    return objList;
                }
                catch (Exception ex)
                {
                    return new List<CustomApplicantVM>();
                }
            }
        }

        public AgentDashboardVM GetAgentDashboardData(string userId)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                List<CustomApplicantVM> objList = new List<CustomApplicantVM>();
                AgentDashboardVM obj = null;
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPGetAgentDashboardData_v1] @UserId ", connection))
                    {
                        command.Parameters.AddWithValue("@UserId", userId);

                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                obj = new AgentDashboardVM();
                                obj.TotalGuranteed = Convert.ToString(reader["TotalGuranteed"]);
                                obj.TotalInApplication = Convert.ToString(reader["TotalInApplication"]);
                                obj.TotalLiveTenenants = Convert.ToString(reader["TotalLiveTenenants"]);
                                obj.TotalWaiting = Convert.ToString(reader["TotalWaiting"]);
                            }
                        }
                    }
                    connection.Close();
                    return obj;
                }
                catch (Exception ex)
                {
                    return new AgentDashboardVM();
                }
            }
        }
        public List<RejectionModel> GetRejectionList()
        {
            List<RejectionModel> objModel = new List<RejectionModel>();
            objModel = CommonManager.getRejectedList();
            return objModel;
        }
        public List<CosignerRejectionModel> GetCosignerRejectionList()
        {
            List<CosignerRejectionModel> objModel = new List<CosignerRejectionModel>();
            objModel = CommonManager.GetCosignerRejectedList();
            return objModel;
        }
        public int UpdateProfileInfo(UserProfileVM model)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                int response = 0;
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPUpdateProfile] @Gender, @DOB, @ProfilePicPath, @Description, @Phone, @WebsiteUrl, @Address, @UserId,	@Latitude,@Longitude, @Result", connection))
                    {
                        command.Parameters.AddWithValue("@Gender", model.Gender);
                        command.Parameters.AddWithValue("@ProfilePicPath", model.ProfilePic == null ? string.Empty : model.ProfilePic);
                        command.Parameters.AddWithValue("@Description", model.Description == null ? string.Empty : model.Description);

                        command.Parameters.AddWithValue("@Phone", model.Mobile == null ? string.Empty : model.Mobile);
                        command.Parameters.AddWithValue("@WebsiteUrl", model.Website == null ? string.Empty : model.Website);
                        command.Parameters.AddWithValue("@Address", model.Address == null ? string.Empty : model.Address);
                        command.Parameters.AddWithValue("@Latitude", model.Latitude == null ? string.Empty : model.Latitude);
                        command.Parameters.AddWithValue("@Longitude", model.Longitude == null ? string.Empty : model.Longitude);
                        command.Parameters.AddWithValue("@UserId", model.UserId);
                        if (model.DOB == null)
                        {
                            command.Parameters.AddWithValue("@DOB", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@DOB", model.DOB);
                        }
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
        public int ArchieveTanent(int ApplicantID, Char status, Char TanentType)
        {
            int retVal = 0;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPArchieveTanent] @ApplicantID,@Status,@TanentType,@Result", connection))
                    {
                        command.Parameters.AddWithValue("@ApplicantID", ApplicantID);
                        command.Parameters.AddWithValue("@Status", status);
                        command.Parameters.AddWithValue("@TanentType", TanentType);
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
                return retVal;
            }
        }
        //public KeyValidatorModel IsValidKey(string key, string email)
        //{
        //    KeyValidatorModel objResponse = null;


        //    using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
        //    {
        //        try
        //        {
        //            connection.Open();
        //            using (SqlCommand command = new SqlCommand("Exec [dbo].[USPGetIntegratorKeyInfo] @Key,@email", connection))
        //            {
        //                command.Parameters.AddWithValue("@Key", key);
        //                command.Parameters.AddWithValue("@email", email);
        //                SqlDataReader reader = command.ExecuteReader();
        //                if (reader.HasRows)
        //                {
        //                    while (reader.Read())
        //                    {
        //                        objResponse = new KeyValidatorModel();
        //                        objResponse.user_id = Convert.ToString(reader["user_id"]);
        //                        objResponse.Sandbox_key = Convert.ToString(reader["Sandbox_key"]);
        //                        objResponse.Prod_key = Convert.ToString(reader["Prod_key"]);
        //                        objResponse.IsProduction = Convert.ToBoolean(reader["IsProduction"]);
        //                        objResponse.email = Convert.ToString(reader["email"]);
        //                    }
        //                }

        //            }

        //            connection.Close();
        //        }
        //        catch (Exception ex)
        //        {

        //        }
        //        return objResponse;
        //    }
        //}

        public List<UserModel> GetAffiliateAP(string affiliateCode, string searchStr)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                List<UserModel> objAgentList = new List<UserModel>();
                UserModel obj = null;
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPGetAffilateAP] @AffiliateCode, @SearchStr", connection))
                    {
                        command.Parameters.AddWithValue("@AffiliateCode", affiliateCode);
                        command.Parameters.AddWithValue("@SearchStr", !string.IsNullOrEmpty(searchStr) ? searchStr : string.Empty);
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                obj = new UserModel();
                                obj.Id = Convert.ToInt32(reader["id"].ToString());
                                obj.first_name = reader["title"].ToString() != DBNull.Value.ToString() ? reader["title"].ToString() : string.Empty;
                                //obj.middle_initial = reader["middle_initial"].ToString() != DBNull.Value.ToString() ? reader["middle_initial"].ToString() : string.Empty;
                                //obj.last_name = reader["last_name"].ToString() != DBNull.Value.ToString() ? reader["last_name"].ToString() : string.Empty;

                                objAgentList.Add(obj);
                            }

                        }
                    }
                    connection.Close();
                    return objAgentList;
                }
                catch (Exception ex)
                {
                    return new List<UserModel>();
                }
            }
        }

        public int UpdateAgentTermsAndCondition(bool isTermsChecked, bool isPEDChecked, string user_id)
        {

            int retVal = 0;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPUpdateAgentTermsAndCondition] @isTermsChecked,@isPEDChecked,@user_id,@Result", connection))
                    {
                        command.Parameters.AddWithValue("@isTermsChecked", isTermsChecked);
                        command.Parameters.AddWithValue("@isPEDChecked", isPEDChecked);
                        command.Parameters.AddWithValue("@user_id", user_id);
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
                return retVal;
            }
        }

        public int DeleteUserByEmail(string email)
        {
            try
            {
                int RetVal = 0;
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPDeleteUserByEmail] @Email, @Result", connection))
                    {
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.Add("@Result", SqlDbType.Int);
                        command.Parameters["@Result"].Direction = ParameterDirection.Output;
                        RetVal = Convert.ToInt32(command.ExecuteScalar());
                    }
                    return RetVal;
                }
            }
            catch (Exception ex)
            {
                CommonManager.LogError(MethodBase.GetCurrentMethod(), ex, email);
                return 0;
            }

        }
    }
}
