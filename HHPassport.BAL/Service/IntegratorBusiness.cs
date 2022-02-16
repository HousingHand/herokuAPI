using HH_PassportModel;
using HHPassport.BAL.Interface;
using HHPassport.DAL.Helpers;
using HHPassport.DAL.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Web;


namespace HHPassport.BAL.Service
{
    public class IntegratorBusiness : IIntegratorBusiness
    {
        public LoginResponseModel tenant(TenantResponseModel tenantObj, string env, string token)
        {
            using (SqlConnection connection = new SqlConnection(HostBuilder.GetConnectionString(env)))
            {
                LoginResponseModel obj = null;
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPCreateTenant_v1] @first_name, @last_name, @phone_number, @nationality_text, @date_of_birth, @employment_status, @income, @email, @password, @phone_verified, @_id, @accomType, @name, @agent_name, @telephone, @address, @county_text, @county_id, @postcode, @fee, @duration, @start_date, @end_date, @CosignerFirstName, @CosignerLastName, @CosignerNationality,    @CosignerEmail, @CosignerPhone, @Relation, @CosignerAddress, @CosignerPassword, @Result", connection))
                    {
                        command.Parameters.AddWithValue("@first_name", tenantObj.personal_info.first_name == null ? "" : tenantObj.personal_info.first_name);
                        command.Parameters.AddWithValue("@last_name", tenantObj.personal_info.last_name == null ? "" : tenantObj.personal_info.last_name);
                        command.Parameters.AddWithValue("@phone_number", tenantObj.personal_info.phone_number == null ? "" : tenantObj.personal_info.phone_number);
                        command.Parameters.AddWithValue("@nationality_text", tenantObj.personal_info.nationality.text == null ? "" : tenantObj.personal_info.nationality.text);

                        if (tenantObj.personal_info.date_of_birth == null)
                        {
                            var col = command.Parameters.Add("@date_of_birth", SqlDbType.DateTime);
                            col.Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@date_of_birth", tenantObj.personal_info.date_of_birth);
                        }

                        command.Parameters.AddWithValue("@employment_status", tenantObj.personal_info.employment_status == null ? "" : tenantObj.personal_info.employment_status);
                        command.Parameters.AddWithValue("@income", tenantObj.personal_info.income == null ? "" : tenantObj.personal_info.income);
                        command.Parameters.AddWithValue("@email", tenantObj.account_info.email == null ? "" : tenantObj.account_info.email);
                        command.Parameters.AddWithValue("@password", tenantObj.account_info.password);
                        command.Parameters.AddWithValue("@phone_verified", tenantObj.account_info.phone_verified);
                        command.Parameters.AddWithValue("@_id", tenantObj.application_info.ap_details.ap._id);
                        command.Parameters.AddWithValue("@accomType", tenantObj.application_info.ap_details.ap.accomType
                            == null ? "" : tenantObj.application_info.ap_details.ap.accomType);
                        command.Parameters.AddWithValue("@name", tenantObj.application_info.ap_details.ap.name == null ? "" : tenantObj.application_info.ap_details.ap.name);
                        command.Parameters.AddWithValue("@agent_name", tenantObj.application_info.ap_details.ap.agent_name == null ? "" : tenantObj.application_info.ap_details.ap.agent_name);
                        command.Parameters.AddWithValue("@telephone", tenantObj.application_info.ap_details.ap.telephone == null ? "" : tenantObj.application_info.ap_details.ap.telephone);
                        command.Parameters.AddWithValue("@address", tenantObj.application_info.ap_details.property.address == null ? "" : tenantObj.application_info.ap_details.property.address);
                        command.Parameters.AddWithValue("@county_text", tenantObj.application_info.ap_details.property.county.text == null ? "" : tenantObj.application_info.ap_details.property.county.text);
                        command.Parameters.AddWithValue("@county_id", tenantObj.application_info.ap_details.property.county._id == null ? "" : tenantObj.application_info.ap_details.property.county._id);
                        command.Parameters.AddWithValue("@postcode", tenantObj.application_info.ap_details.property.postcode);
                        command.Parameters.AddWithValue("@fee", tenantObj.application_info.ap_details.rent.fee);
                        command.Parameters.AddWithValue("@duration", tenantObj.application_info.ap_details.rent.duration
                            == null ? "" : tenantObj.application_info.ap_details.rent.duration);
                        if (tenantObj.application_info.ap_details.rent.start_date == null)
                        {
                            var col = command.Parameters.Add("@start_date", SqlDbType.DateTime);
                            col.Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@start_date", tenantObj.application_info.ap_details.rent.start_date);
                        }

                        if (tenantObj.application_info.ap_details.rent.end_date == null)
                        {
                            var col = command.Parameters.Add("@end_date", SqlDbType.DateTime);
                            col.Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@end_date", tenantObj.application_info.ap_details.rent.end_date);
                        }


                        //cosignerInfo params
                        command.Parameters.AddWithValue("@CosignerFirstName", tenantObj.application_info.cosigner_info.first_name == null ? string.Empty : tenantObj.application_info.cosigner_info.first_name);
                        command.Parameters.AddWithValue("@CosignerLastName", tenantObj.application_info.cosigner_info.last_name == null ? string.Empty : tenantObj.application_info.cosigner_info.last_name);
                        command.Parameters.AddWithValue("@CosignerNationality", tenantObj.application_info.cosigner_info.nationality == null ? string.Empty : tenantObj.application_info.cosigner_info.nationality);
                        command.Parameters.AddWithValue("@CosignerEmail", tenantObj.application_info.cosigner_info.email == null ? string.Empty : tenantObj.application_info.cosigner_info.email);
                        command.Parameters.AddWithValue("@CosignerPhone", tenantObj.application_info.cosigner_info.phone == null ? string.Empty : tenantObj.application_info.cosigner_info.phone);
                        command.Parameters.AddWithValue("@Relation", tenantObj.application_info.cosigner_info.relation == null ? string.Empty : tenantObj.application_info.cosigner_info.relation);
                        command.Parameters.AddWithValue("@CosignerAddress", tenantObj.application_info.cosigner_info.address == null ? string.Empty : tenantObj.application_info.cosigner_info.address);
                        command.Parameters.AddWithValue("@CosignerPassword", tenantObj.application_info.cosigner_info.password == null ? string.Empty : tenantObj.application_info.cosigner_info.password);

                        command.Parameters.Add("@Result", SqlDbType.Int);
                        command.Parameters["@Result"].Direction = ParameterDirection.Output;
                        int response = Convert.ToInt32(command.ExecuteScalar());
                        obj = new LoginResponseModel();
                        obj = this.GetIntegrator(tenantObj.account_info.email, env, token);
                    }
                    connection.Close();
                    return obj;
                }
                catch (Exception ex)
                {
                    return obj;
                }
            }
        }
        public ResponseModel<string> UpdateTenant(string id, TenantResponseModel tenantObj, string env)
        {
            using (SqlConnection connection = new SqlConnection(HostBuilder.GetConnectionString(env)))
            {
                ResponseModel<string> obj = null;
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPUpdateTenantById] @_id, @first_name, @last_name, @phone_number, @nationality_text, @date_of_birth, @employment_status, @income, @Place_of_study, @type_of_study, @type_of_course, @year_of_study, @email, @phone_verified, @accomType, @name, @agent_name, @telephone, @address, @county_text, @postcode, @fee, @duration, @start_date, @end_date", connection))
                    {

                        command.Parameters.AddWithValue("@_id", id);
                        if (tenantObj.personal_info != null)
                        {
                            command.Parameters.AddWithValue("@first_name", tenantObj.personal_info.first_name == null ? "" : tenantObj.personal_info.first_name);
                            command.Parameters.AddWithValue("@last_name", tenantObj.personal_info.last_name == null ? "" : tenantObj.personal_info.last_name);
                            command.Parameters.AddWithValue("@phone_number", tenantObj.personal_info.phone_number == null ? "" : tenantObj.personal_info.phone_number);
                            command.Parameters.AddWithValue("@nationality_text", tenantObj.personal_info.nationality.text == null ? "" : tenantObj.personal_info.nationality.text);
                            if (tenantObj.personal_info.date_of_birth == null)
                            {
                                var col = command.Parameters.Add("@date_of_birth", SqlDbType.Decimal);
                                col.Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.AddWithValue("@date_of_birth", tenantObj.personal_info.date_of_birth);
                            }

                            //command.Parameters.AddWithValue("@date_of_birth", tenantObj.personal_info.date_of_birth == null ? "" : tenantObj.personal_info.date_of_birth);

                            command.Parameters.AddWithValue("@employment_status", tenantObj.personal_info.employment_status == null ? "" : tenantObj.personal_info.employment_status);
                            command.Parameters.AddWithValue("@Place_of_study", tenantObj.personal_info.place_of_study.text == null ? "" : tenantObj.personal_info.place_of_study.text);
                            command.Parameters.AddWithValue("@type_of_study", tenantObj.personal_info.type_of_study.text == null ? "" : tenantObj.personal_info.type_of_study.text);
                            command.Parameters.AddWithValue("@type_of_course", tenantObj.personal_info.type_of_course == null ? "" : tenantObj.personal_info.type_of_course);
                            command.Parameters.AddWithValue("@year_of_study", tenantObj.personal_info.year_of_study.text == null ? "" : tenantObj.personal_info.year_of_study.text);
                            command.Parameters.AddWithValue("@income", tenantObj.personal_info.income == null ? "" : tenantObj.personal_info.income);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@first_name", DBNull.Value);
                            command.Parameters.AddWithValue("@last_name", DBNull.Value);
                            command.Parameters.AddWithValue("@phone_number", DBNull.Value);
                            command.Parameters.AddWithValue("@nationality_text", DBNull.Value);
                            command.Parameters.AddWithValue("@date_of_birth", DBNull.Value);
                            command.Parameters.AddWithValue("@employment_status", DBNull.Value);
                            command.Parameters.AddWithValue("@Place_of_study", DBNull.Value);
                            command.Parameters.AddWithValue("@type_of_study", DBNull.Value);
                            command.Parameters.AddWithValue("@type_of_course", DBNull.Value);
                            command.Parameters.AddWithValue("@year_of_study", DBNull.Value);
                            command.Parameters.AddWithValue("@income", DBNull.Value);
                        }
                        if (tenantObj.account_info != null)
                        {
                            command.Parameters.AddWithValue("@phone_verified", tenantObj.account_info.phone_verified);

                            command.Parameters.AddWithValue("@email", tenantObj.account_info.email == null ? "" : tenantObj.account_info.email);

                        }
                        else
                        {
                            command.Parameters.AddWithValue("@phone_verified", 0);

                            command.Parameters.AddWithValue("@email", DBNull.Value);

                        }
                        if (tenantObj.application_info != null && tenantObj.application_info.ap_details != null && tenantObj.application_info.ap_details.ap != null)
                        {     //command.Parameters.AddWithValue("@_id", tenantObj.application_info.ap_details.ap._id);
                            command.Parameters.AddWithValue("@accomType", tenantObj.application_info.ap_details.ap.accomType == null ? "" : tenantObj.application_info.ap_details.ap.accomType);
                            command.Parameters.AddWithValue("@name", tenantObj.application_info.ap_details.ap.name == null ? "" : tenantObj.application_info.ap_details.ap.name);
                            command.Parameters.AddWithValue("@agent_name", tenantObj.application_info.ap_details.ap.agent_name == null ? "" : tenantObj.application_info.ap_details.ap.agent_name);
                            command.Parameters.AddWithValue("@telephone", tenantObj.application_info.ap_details.ap.telephone == null ? "" : tenantObj.application_info.ap_details.ap.telephone);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@accomType", DBNull.Value);
                            command.Parameters.AddWithValue("@name", DBNull.Value);
                            command.Parameters.AddWithValue("@agent_name", DBNull.Value);
                            command.Parameters.AddWithValue("@telephone", DBNull.Value);
                        }
                        if (tenantObj.application_info != null && tenantObj.application_info.ap_details != null && tenantObj.application_info.ap_details.property != null)
                        {
                            command.Parameters.AddWithValue("@address", tenantObj.application_info.ap_details.property.address == null ? "" : tenantObj.application_info.ap_details.property.address);
                            //command.Parameters.AddWithValue("@county_id", tenantObj.application_info.ap_details.property.county._id == null ? "" : tenantObj.application_info.ap_details.property.county._id);
                            command.Parameters.AddWithValue("@county_text", tenantObj.application_info.ap_details.property.county.text == null ? "" : tenantObj.application_info.ap_details.property.county.text);
                            command.Parameters.AddWithValue("@postcode", tenantObj.application_info.ap_details.property.postcode == null ? "" : tenantObj.application_info.ap_details.property.postcode);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@address", DBNull.Value);
                            //command.Parameters.AddWithValue("@county_id", tenantObj.application_info.ap_details.property.county._id == null ? DBNull.Value : tenantObj.application_info.ap_details.property.county._id);
                            command.Parameters.AddWithValue("@county_text", DBNull.Value);
                            command.Parameters.AddWithValue("@postcode", DBNull.Value);
                        }
                        if (tenantObj.application_info != null && tenantObj.application_info.ap_details != null && tenantObj.application_info.ap_details.rent != null)
                        {
                            command.Parameters.AddWithValue("@fee", tenantObj.application_info.ap_details.rent.fee);
                            command.Parameters.AddWithValue("@duration", tenantObj.application_info.ap_details.rent.duration == null ? "" : tenantObj.application_info.ap_details.rent.duration);
                            command.Parameters.AddWithValue("@start_date", tenantObj.application_info.ap_details.rent.start_date);
                            command.Parameters.AddWithValue("@end_date", tenantObj.application_info.ap_details.rent.end_date);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@fee", 0);
                            command.Parameters.AddWithValue("@duration", DBNull.Value);
                            command.Parameters.AddWithValue("@start_date", DBNull.Value);
                            command.Parameters.AddWithValue("@end_date", DBNull.Value);
                        }

                        int response = Convert.ToInt32(command.ExecuteScalar());
                        obj = new ResponseModel<string>();
                        obj.code = "ok";
                        obj.message = "Tenant info succesfully updated.";

                    }
                    connection.Close();
                    return obj;
                }
                catch (Exception ex)
                {
                    obj = new ResponseModel<string>();
                    obj.code = "failed";
                    obj.message = "Tenant info not succesfully updated.";
                    return obj;
                }
            }
        }

        public LoginResponseModel GetIntegrator(string email, string env, string token)
        {


            using (SqlConnection connection = new SqlConnection(HostBuilder.GetConnectionString(env)))
            {
                List<LoginResponseModel> objLoginResponse = new List<LoginResponseModel>();
                LoginResponseModel obj = null;
                //Data data = null;
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPTenantLogin] @email,@password", connection))
                    {
                        command.Parameters.AddWithValue("@email", email);
                        command.Parameters.AddWithValue("@password", "xyz");
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            // Task<string> Token = this.GetAuthorizeToken();
                            while (reader.Read())
                            {
                                obj = new LoginResponseModel();

                                obj.code = "created";
                                obj.message = "Tenant account has been succcessfully created!";
                                obj.data = new Data();
                                obj.data.account_info = new AccountInfo();
                                obj.data.personal_info = new PersonalInfo();
                                // obj.data.personal_info.nationality = new Nationality();
                                obj.data.personal_info.place_of_study = new PlaceOfStudy();
                                obj.data.personal_info.type_of_study = new TypeOfStudy();
                                obj.data.application_info = new ApplicationInfo();
                                obj.data.application_info.ap_details = new ApDetails();
                                obj.data.application_info.ap_details.rent = new Rent();
                                //obj.data.application_info.ap_details.rent.renewal = new Renewal();
                                obj.data.application_info.ap_details.ap = new Ap();
                                obj.data.application_info.ap_details.property = new Property();
                                obj.data.time_stamps = new TimeStamps();
                                obj.data.pre_payment_reminder_emails = new PrePaymentReminderEmails();
                                obj.data.pre_quote_reminder_emails = new PreQuoteReminderEmails();
                                obj.data.verification = new Verification();
                                obj.data.verification.ap = new Ap();
                                obj.data.verification.cosigner = new Cosigner();
                                obj.data.verification.tenant = new Tenant();
                                obj.data.verification.payment = new Payment();
                                obj.data.verification.contract = new Contract();
                                obj.data.verification.gd = new Gd();
                                obj.data.verification.ast = new Ast();
                                obj.data.application = new Application();
                                obj.data.quote_info = new QuoteInfo();
                                obj.data.future_quote_info = new FutureQuoteInfo();
                                obj.data.application_info.ap_details.property.county = new County();
                                obj.data._id = reader["_id"].ToString();
                                // obj.data.account_info.ref_no = reader["ref_no"].ToString();
                                //obj.data.account_info.agent_id = reader["_id"].ToString();
                                //  obj.data.account_info.country_code = reader["country_code"].ToString();
                                obj.data.account_info.email = reader["email"].ToString();
                                //obj.data.account_info.type = Convert.ToInt16(reader["type"].ToString());
                                //  obj.data.account_info.status = Convert.ToInt16(reader["status"]);
                                //  obj.data.account_info.agent_id = reader["agent_id"].ToString();
                                //obj.data.account_info.integrator = reader["integrator"].ToString();
                                //obj.data.account_info.source = Convert.ToInt16(reader["source"].ToString());
                                //obj.data.account_info.sponsorship = reader["sponsorship"].ToString();
                                //obj.data.personal_info.date_of_birth = Convert.ToDateTime(reader["date_of_birth"]);
                                obj.data.personal_info.first_name = reader["first_name"].ToString();
                                obj.data.personal_info.last_name = reader["last_name"].ToString();
                                obj.data.personal_info.phone_number = reader["phone_number"].ToString();
                                // obj.data.personal_info.nationality.text = reader["nationalitytext"].ToString();
                                obj.data.personal_info.place_of_study._id = reader["UniversityId"].ToString();
                                obj.data.personal_info.place_of_study.text = reader["UniversityText"].ToString();
                                obj.data.personal_info.type_of_study._id = reader["StudentStudyingId"].ToString();
                                obj.data.personal_info.type_of_study.text = reader["StudentStudingText"].ToString();
                                // obj.data.personal_info.type_of_course = reader["CourseId"].ToString();
                                obj.data.personal_info.type_of_course = reader["CourseText"].ToString();
                                // obj.data.application_info.ap_details.rent.fee = reader["fee"];
                                obj.data.application_info.ap_details.rent.duration = reader["duration"].ToString();
                                //obj.data.application_info.ap_details.rent.start_date = Convert.ToDateTime(reader["start_date"] !=null? reader["start_date"] :"" );
                                //obj.data.application_info.ap_details.rent.end_date = Convert.ToDateTime(reader["start_date"] != null ? reader["end_date"] : "");
                                obj.data.application_info.ap_details.ap._id = Convert.ToInt32(reader["ap_id"].ToString());
                                obj.data.application_info.ap_details.ap.name = reader["ag_name"].ToString();
                                obj.data.application_info.ap_details.ap.agent_name = reader["agent_name"].ToString();
                                obj.data.application_info.ap_details.ap.accomType = reader["accomType"].ToString();
                                obj.data.application_info.ap_details.ap.telephone = reader["telephone"].ToString();
                                obj.data.application_info.ap_details.property.county.text = reader["agCountrytext"].ToString();

                                obj.data.application_info.ap_details.property.postcode = reader["postcode"].ToString();
                                obj.data.application_info.ap_details.property.address = reader["address"].ToString();
                                obj.data.docs = this.GetGurantorDocuments(obj.data._id, env, "zzz");


                                //obj.token = Token.ToString();
                                //obj.data = Convert.ToBoolean(reader["is_active"].ToString());
                                obj.token = token;
                                //objLoginResponse.Add(obj);
                            }
                        }
                    }
                    connection.Close();
                    //return objUniversityList;
                    return obj;
                }
                catch (Exception ex)
                {
                    obj.code = "Unauthenticated";
                    obj.message = "Login failed! " + ex.Message;
                    obj.data = null;
                    obj.token = null;
                    return obj;
                }
            }
        }

        public List<docs> GetGurantorDocuments(string applicantId, string env, string isDocumentfor = "")
        {
            using (SqlConnection connection = new SqlConnection(HostBuilder.GetConnectionString(env)))
            {
                docs obj = null;
                List<docs> listDocs = new List<docs>();
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
                                obj = new docs();
                                obj.url = Convert.ToString(reader["FilePath"].ToString());
                                obj.status = Convert.ToInt16(reader["IsActive"]);
                                obj.type = Convert.ToInt32(reader["FileType"]);
                                obj.date_uploaded = Convert.ToDateTime(reader["CreatedDate"]);
                                obj.uploaded_by = Convert.ToInt32(reader["CreatedBy"]);
                                //obj.RejectedReason = Convert.ToString(reader["RejectedReason"]);
                                //obj.status = Convert.ToBoolean(reader["IsRejected"]);

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

        public ResponseModel<string> verify_email(string email, string env)
        {
            ResponseModel<string> response = new ResponseModel<string>();
            using (SqlConnection connection = new SqlConnection(HostBuilder.GetConnectionString(env)))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPVerify_email] @email", connection))
                    {
                        command.Parameters.AddWithValue("@email", email);
                        //command.Parameters.AddWithValue("@password", "xyz");
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            response.code = "Already Exist!";
                            response.message = "This email is already in use.";
                            response.data = email;
                        }
                        else
                        {
                            response.code = "ok";
                            response.message = "This email is valid to use.";
                            response.data = null;
                        }
                    }
                    connection.Close();
                    //return objUniversityList;
                    return response;
                }
                catch (Exception ex)
                {
                    response.code = "failed";
                    response.message = "Unable to find! " + ex.Message;
                    return response;
                }
            }

        }

        public ResponseModel<FindByEmailModel> find_by_email(string email, string env, string token)
        {

            ResponseModel<FindByEmailModel> response = new ResponseModel<FindByEmailModel>();
            using (SqlConnection connection = new SqlConnection(HostBuilder.GetConnectionString(env)))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPTenantFindByEmail] @email", connection))
                    {
                        command.Parameters.AddWithValue("@email", email);
                        SqlDataReader reader = command.ExecuteReader();
                        //DataTable dt = new DataTable();
                        //dt.Load(reader);
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                response.data = new FindByEmailModel();
                                response.code = "Already Exist!";
                                response.message = "This email is already in use.";
                                response.data.tenantId = reader["tenantId"].ToString();
                                response.data.token = token;
                            }
                        }
                        else
                        {
                            response.code = "No data found";
                            response.message = "No data found";
                            response.data = null;
                        }
                    }
                    connection.Close();
                    //return objUniversityList;
                    return response;
                }
                catch (Exception ex)
                {
                    response.code = "failed";
                    response.message = "Unable to find! " + ex.Message;
                    response.data = null;
                    return response;
                }
            }

        }

        public ResponseModel<PedDetails> TenantPDF(string id, string env)
        {
            ResponseModel<PedDetails> response = new ResponseModel<PedDetails>();
            using (SqlConnection connection = new SqlConnection(HostBuilder.GetConnectionString(env)))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPfetchPed] @_id", connection))
                    {
                        command.Parameters.AddWithValue("@_id", id);
                        //command.Parameters.AddWithValue("@password", "xyz");
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                response.code = "Already Exist!";
                                response.message = "Usefull Ped Info";
                                response.data = new PedDetails();
                                response.data.first_name = reader["first_name"].ToString();
                                response.data.last_name = reader["last_name"].ToString(); ;
                                response.data.email = reader["email"].ToString();
                                response.data._id = reader["_id"].ToString();
                                response.data.EndDate = reader["end_date"].ToString();
                                response.data.StartDate = reader["start_date"].ToString();
                                response.data.agent_id = reader["agent_id"].ToString();
                                response.data.agent_Name = reader["agent_name"].ToString();
                                response.data.phone_number = reader["phone_number"].ToString();
                            }
                        }
                        else
                        {
                            response.code = "ok";
                            response.message = " Data Not Found";
                            response.data = null;
                        }
                    }
                    connection.Close();
                    //return objUniversityList;
                    return response;
                }
                catch (Exception ex)
                {
                    response.code = "failed";
                    response.message = "Unable to find! " + ex.Message;
                    return response;
                }
            }
        }


        public int UploadDocuments(TenantDocumentModel list, string id)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                int response = 0;
                try
                {
                    connection.Open();

                    foreach (var obj in list.docs)
                    {
                        using (SqlCommand command = new SqlCommand("Exec [dbo].[UPSUploadGurantorDocuments] @ApplicantID, @FileType, @FilePath, @IsActive, @CreatedBy,@DocumentId, @Result", connection))
                        {
                            command.Parameters.AddWithValue("@ApplicantID", id);
                            command.Parameters.AddWithValue("@FileType", obj.type);
                            command.Parameters.AddWithValue("@FilePath", obj.url);
                            command.Parameters.AddWithValue("@IsActive", false);
                            command.Parameters.AddWithValue("@CreatedBy", obj.uploaded_by);
                            command.Parameters.AddWithValue("@DocumentId", 0);

                            command.Parameters.Add("@Result", SqlDbType.Int);
                            command.Parameters["@Result"].Direction = ParameterDirection.Output;
                            response = Convert.ToInt32(command.ExecuteScalar());

                        }
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


        public List<docs> GetDocuments(string applicantId)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                docs obj = null;
                List<docs> listDocs = new List<docs>();
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPGetAllGurantorDocuments] @ApplicantID, @IsDocumentfor", connection))
                    {
                        command.Parameters.AddWithValue("@ApplicantID", applicantId);

                        command.Parameters.AddWithValue("@IsDocumentfor", "");
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                obj = new docs();
                                obj.url = Convert.ToString(reader["FilePath"].ToString());
                                obj.status = Convert.ToInt32(reader["IsActive"]);
                                obj.type = Convert.ToInt32(reader["FileType"]);
                                obj.uploaded_by = Convert.ToInt32(reader["CreatedBy"]);
                                obj.date_uploaded = Convert.ToDateTime(reader["CreatedDate"]);
                                obj._id = Convert.ToString(reader["DocumentId"]);

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
        public int AddUpdateIntegrator(IntegratorModel model)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                int response = 0;
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPAddUpdateIntegrator] @Integrator_Id, @Name, @Contact_no, @Email, @Prod_key, @Sandbox_key, @CreatedBy, @Result", connection))
                    {
                        command.Parameters.AddWithValue("@Integrator_Id", model.Integrator_Id);
                        command.Parameters.AddWithValue("@Name", model.Name);
                        command.Parameters.AddWithValue("@Contact_no", model.Contact_no);
                        command.Parameters.AddWithValue("@Email", model.Email == null ? string.Empty : model.Email);
                        command.Parameters.AddWithValue("@Prod_key", model.Prod_key);
                        command.Parameters.AddWithValue("@Sandbox_key", model.Sandbox_key);
                        command.Parameters.AddWithValue("@CreatedBy", model.createdBy);
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

        public List<IntegratorModel> GetIntegratorList(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                IntegratorModel obj = null;
                List<IntegratorModel> objList = new List<IntegratorModel>();
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPGetIntegrators] @Id", connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                obj = new IntegratorModel();
                                obj.Integrator_Id = Convert.ToInt32(reader["Integrator_Id"].ToString());
                                obj.Name = reader["Name"].ToString();
                                obj.Email = reader["Email"].ToString();
                                obj.Contact_no = reader["Contact_no"].ToString();
                                obj.Prod_key = reader["Prod_key"].ToString();
                                obj.Sandbox_key = reader["Sandbox_key"].ToString();
                                obj.createdAt = Convert.ToDateTime(reader["createdAt"].ToString());
                                objList.Add(obj);
                            }
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

        public ResponseModel<PedDetails> Tenant_PedDetails(string id, string env)
        {
            ResponseModel<PedDetails> response = new ResponseModel<PedDetails>();
            using (SqlConnection connection = new SqlConnection(HostBuilder.GetConnectionString(env)))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPfetchPed] @_id", connection))
                    {
                        command.Parameters.AddWithValue("@_id", id);
                        //command.Parameters.AddWithValue("@password", "xyz");
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            response.code = "Already Exist!";
                            response.message = "Usefull Ped Info";
                            response.data = new PedDetails();
                            response.data.first_name = reader["first_name"].ToString();
                            response.data.last_name = reader["last_name"].ToString(); ;
                            response.data.email = reader["email"].ToString();
                            response.data._id = reader["_id"].ToString();
                            response.data.EndDate = reader["end_date"].ToString();
                            response.data.StartDate = reader["start_date"].ToString();
                            response.data.agent_id = reader["agent_id"].ToString();
                            response.data.agent_Name = reader["agent_name"].ToString();


                        }
                        else
                        {
                            response.code = "ok";
                            response.message = " Data Not Found";
                            response.data = null;
                        }
                    }
                    connection.Close();
                    //return objUniversityList;
                    return response;
                }
                catch (Exception ex)
                {
                    response.code = "failed";
                    response.message = "Unable to find! " + ex.Message;
                    return response;
                }
            }

        }

        public ResponseModel<PaymentInfo> GetTenantBalance(string id, string env)
        {


            using (SqlConnection connection = new SqlConnection(HostBuilder.GetConnectionString(env)))
            {
                //List<ResponseModel> objLoginResponse = new List<ResponseModel>();
                ResponseModel<PaymentInfo> obj = null;
                //Data data = null;
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[GetTenantBalance] @ApplicantId", connection))
                    {
                        command.Parameters.AddWithValue("@ApplicantId", id);
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            // Task<string> Token = this.GetAuthorizeToken();
                            while (reader.Read())
                            {
                                obj = new ResponseModel<PaymentInfo>();

                                obj.code = "ok";
                                obj.message = "Tenant balance successfully fetched";
                                obj.data = new PaymentInfo();
                                obj.data.total_amount_paid = Convert.ToInt16(reader["total_amount_paid"]);
                                obj.data.no_of_times_paid = Convert.ToInt16(reader["no_of_times_paid"]);
                                obj.data.remaining_balance = Convert.ToInt16(reader["remaining_balance"]);
                                obj.data.last_paid_amount = Convert.ToInt16(reader["last_paid_amount"]);
                                obj.data.is_subscription = Convert.ToInt16(reader["is_subscription"]);
                                obj.data.payment_incrementor = Convert.ToInt16(reader["payment_incrementor"]);
                                obj.data.failed_incrementor = Convert.ToInt16(reader["failed_incrementor"]);
                                obj.data.status = Convert.ToInt16(reader["status"]);

                            }
                        }
                    }
                    connection.Close();
                    return obj;
                }
                catch (Exception ex)
                {
                    obj.code = "Unauthenticated";
                    obj.message = "Login failed! " + ex.Message;
                    obj.data = null;
                    obj.token = null;
                    return obj;
                }
            }
        }

        public bool GetValidateRefNumber(string id, string refno)
        {
            bool isValid = false;
            string env = "";
            using (SqlConnection connection = new SqlConnection(HostBuilder.GetConnectionString(env)))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[GetValidateRefNumber] @id ,@refno", connection))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        command.Parameters.AddWithValue("@refno", refno);
                        object noofRecord = command.ExecuteScalar();
                        if (Convert.ToInt32(noofRecord) > 0)
                        {
                            isValid = true;
                        }

                    }
                    connection.Close();
                    return isValid;
                }
                catch (Exception ex)
                {
                    isValid = false;
                    return isValid;
                }

            }

        }


        public ResponseModel<string> CreateUpdateCosigner(string id, CosignerInfo cosignerObj, string env)
        {
            using (SqlConnection connection = new SqlConnection(HostBuilder.GetConnectionString(env)))
            {
                ResponseModel<string> obj = null;
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPCreateUpdateCosigner] @_id, @relation, @address, @nationality, @first_name, @last_name, @email, @phone_number", connection))
                    {

                        command.Parameters.AddWithValue("@_id", id);
                        command.Parameters.AddWithValue("@first_name", cosignerObj.first_name);
                        command.Parameters.AddWithValue("@last_name", cosignerObj.last_name);
                        command.Parameters.AddWithValue("@phone_number", cosignerObj.phone);
                        command.Parameters.AddWithValue("@nationality", cosignerObj.nationality);
                        command.Parameters.AddWithValue("@relation", cosignerObj.relation);
                        command.Parameters.AddWithValue("@email", cosignerObj.email);
                        command.Parameters.AddWithValue("@address", cosignerObj.address);
                        int response = Convert.ToInt32(command.ExecuteScalar());
                        obj = new ResponseModel<string>();
                        obj.code = "ok";
                        obj.message = "Tenant cosigner info has been succesfully updated!";

                    }
                    connection.Close();
                    return obj;
                }
                catch (Exception ex)
                {
                    obj = new ResponseModel<string>();
                    obj.code = "failed";
                    obj.message = "Tenant info not succesfully updated.";
                    return obj;
                }
            }
        }

    }
}
