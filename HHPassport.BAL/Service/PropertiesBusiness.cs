using HHPassport.BAL.Interface;
using HHPassport.DAL.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHPassport.BAL.Service
{
    public class PropertiesBusiness : IPropertiesBusiness
    {
        public int AddUpdateProperties(PropertyModel model)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                int response = 0;
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPAddUpdateAgentProperties] @Id, @Title, @Address, @Description, @Latitude, @Longitude, @Price, @PriceInterval, @DepositAmt, @Rooms, @Furnished, @MoveIn, @BedRoom, @BathRoom, @ContractLength, @AgentId, @AmentiesStr, @ImagesPath, @CreatedBy, @Result", connection))
                    {
                        command.Parameters.AddWithValue("@Id", model.Id);
                        command.Parameters.AddWithValue("@Title", model.Title);
                        command.Parameters.AddWithValue("@Address", model.Address);
                        command.Parameters.AddWithValue("@Description", model.Description);
                        command.Parameters.AddWithValue("@Latitude", model.Latitude);
                        command.Parameters.AddWithValue("@Longitude", model.Longitude);
                        command.Parameters.AddWithValue("@Price", model.Price);
                        command.Parameters.AddWithValue("@PriceInterval", model.PriceInterval);
                        command.Parameters.AddWithValue("@DepositAmt", model.DepositAmt);
                        command.Parameters.AddWithValue("@Rooms", model.Rooms);
                        command.Parameters.AddWithValue("@Furnished", model.Furnished);
                        command.Parameters.AddWithValue("@MoveIn", model.MoveIn);
                        command.Parameters.AddWithValue("@BedRoom", model.BedRoom);
                        command.Parameters.AddWithValue("@BathRoom", model.BathRoom);
                        command.Parameters.AddWithValue("@ContractLength", model.ContractLength);
                        command.Parameters.AddWithValue("@AgentId", model.AgentId);
                        command.Parameters.AddWithValue("@AmentiesStr", model.AmentiesStr);
                        command.Parameters.AddWithValue("@ImagesPath", model.ImagesPath);
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

        public int DeleteAgentLead(string applicantId)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                int response = 0;
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPDeleteAgentLead] @ApplicantId", connection))
                    {

                        command.Parameters.AddWithValue("@ApplicantId", applicantId);

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

        public int SaveAgentLead(string applicantId, string agentId)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                int response = 0;
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPAddUpdateAgentLead] @ApplicantId, @AgentId, @LeadStatus, @Result", connection))
                    {

                        command.Parameters.AddWithValue("@ApplicantId", applicantId);
                        command.Parameters.AddWithValue("@AgentId", agentId);

                        command.Parameters.AddWithValue("@LeadStatus", 'N');

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

        public int AgencyClicked(string applicantId, string agentId)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                int response = 0;
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPUpdateAgencyClicked] @ApplicantId, @AgentId, @Result", connection))
                    {
                        command.Parameters.AddWithValue("@ApplicantId", applicantId);
                        command.Parameters.AddWithValue("@AgentId", agentId);
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


        public int UpdateCosignerById(GurantorCosignerVM cosignerObj)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                int response = 0;
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPCreateUpdateCosignerById] @CosignerGUID, @ApplicantId, @relation, @first_name, @last_name, @email, @phone_number,@Result", connection))
                    {
                        command.Parameters.AddWithValue("@CosignerGUID", cosignerObj.CosignerGUID);
                        command.Parameters.AddWithValue("@ApplicantId", cosignerObj.ApplicantId);
                        command.Parameters.AddWithValue("@first_name", cosignerObj.FirstName);
                        command.Parameters.AddWithValue("@last_name", cosignerObj.LastName);
                        command.Parameters.AddWithValue("@phone_number", cosignerObj.PhoneNumber);
                        //command.Parameters.AddWithValue("@nationality", DBNull.Value);
                        command.Parameters.AddWithValue("@relation", cosignerObj.Relation);
                        command.Parameters.AddWithValue("@email", cosignerObj.Email);
                        //command.Parameters.AddWithValue("@address", DBNull.Value);
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
        public int AddUpdateSearchPropertiesCriteria(PropertySearchModel model)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                int response = 0;
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPAddUpdateSearchPropertiesCriteria] @UserId, @LocationName, @Latitude, @Longitude,@FarFrom, @PriceMin, @PriceMax, @PriceInterval, @Rooms, @Furnished, @RequiredTags, @Notes, @CreatedBy, @Result", connection))
                    {
                        command.Parameters.AddWithValue("@UserId", model.UserId);
                        command.Parameters.AddWithValue("@LocationName", model.LocationName == null ? string.Empty : model.LocationName);
                        command.Parameters.AddWithValue("@Latitude", model.Latitude == null ? string.Empty : model.Latitude);
                        command.Parameters.AddWithValue("@Longitude", model.Longitude == null ? string.Empty : model.Longitude);
                        command.Parameters.AddWithValue("@FarFrom", model.FarFrom);
                        command.Parameters.AddWithValue("@PriceMin", model.PriceMin);
                        command.Parameters.AddWithValue("@PriceMax", model.PriceMax);
                        command.Parameters.AddWithValue("@PriceInterval", model.PriceInterval);
                        command.Parameters.AddWithValue("@Rooms", model.Rooms);
                        command.Parameters.AddWithValue("@Furnished", model.Furnished == null ? string.Empty : model.Furnished);

                        command.Parameters.AddWithValue("@RequiredTags", model.RequiredTags == null ? string.Empty : model.RequiredTags);
                        command.Parameters.AddWithValue("@Notes", model.Notes == null ? string.Empty : model.Notes);

                        command.Parameters.AddWithValue("@CreatedBy", model.UserId);
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

        public int ChangeStatus(int id, bool status)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                int response = 0;
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPChangePropertyStatus] @Id, @Status, @Result", connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        command.Parameters.AddWithValue("@Status", status);
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

        public List<AgentPropertiesSerachResponseVM> GetAgentPropertiesListBySearchParams(string destinationLatitude, string destinationLongitude, string locationFar, string Interval, decimal budgetFrom, decimal budgetTo, int noOfRooms, string furnishedType, string amentyIds, string agentId)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                List<AgentPropertiesSerachResponseVM> objList = new List<AgentPropertiesSerachResponseVM>();
                AgentPropertiesSerachResponseVM obj = null;
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPGetPropertiesBySearchParms_v1] @DestinationLatitude, @DestinationLongitude, @LocationFar, @Interval, @BudgetFrom, @BudgetTo, @NoOfRooms, @FurnishedType, @AmenityIds, @AgentId", connection))
                    {
                        command.Parameters.AddWithValue("@DestinationLatitude", (!string.IsNullOrEmpty(destinationLatitude) ? destinationLatitude : string.Empty));
                        command.Parameters.AddWithValue("@DestinationLongitude", (!string.IsNullOrEmpty(destinationLongitude) ? destinationLongitude : string.Empty));
                        command.Parameters.AddWithValue("@LocationFar", (!string.IsNullOrEmpty(locationFar) ? locationFar : string.Empty));
                        command.Parameters.AddWithValue("@Interval", Interval);
                        command.Parameters.AddWithValue("@BudgetFrom", budgetFrom);
                        command.Parameters.AddWithValue("@BudgetTo", budgetTo);
                        command.Parameters.AddWithValue("@NoOfRooms", noOfRooms);
                        command.Parameters.AddWithValue("@FurnishedType", (!string.IsNullOrEmpty(furnishedType) ? furnishedType : string.Empty));
                        command.Parameters.AddWithValue("@AmenityIds", (!string.IsNullOrEmpty(amentyIds) ? amentyIds : string.Empty));
                        command.Parameters.AddWithValue("@AgentId", (!string.IsNullOrEmpty(agentId) ? agentId : string.Empty));
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                obj = new AgentPropertiesSerachResponseVM();
                                obj.AgentId = reader["AgentId"].ToString();
                                obj.AgentTitle = reader["AgentTitle"].ToString();
                                obj.AgentPhone = reader["AgentPhone"].ToString();
                                obj.AgentLogoPath = reader["AgentLogoPath"] == null ? DBNull.Value.ToString() : ConfigurationManager.AppSettings["AppBaseAddress"].ToString() + reader["AgentLogoPath"].ToString();
                                obj.AgentCoverImagePath = reader["AgentCoverImagePath"] == null ? DBNull.Value.ToString() : ConfigurationManager.AppSettings["AppBaseAddress"].ToString() + reader["AgentCoverImagePath"].ToString();

                                obj.AgentName = reader["AgentName"].ToString();
                                obj.AgentJoinedDate = reader["AgentJoinedDate"].ToString();
                                obj.AgentEmail = reader["AgentEmail"].ToString();
                                obj.AgentAddress = reader["AgentAddress"].ToString();

                                obj.AgentLatitude = Convert.ToDecimal(reader["AgentLatitude"].ToString());
                                obj.AgentLongitude = Convert.ToDecimal(reader["AgentLongitude"].ToString());
                                obj.AgentWebsiteUrl = reader["AgentWebsiteUrl"].ToString();
                                obj.AgentDescription = reader["AgentDescription"].ToString();

                                obj.PropertyId = Convert.ToInt32(reader["PropertyId"].ToString());
                                obj.PropertyTitle = reader["PropertyTitle"].ToString();
                                obj.PropertyAddress = reader["PropertyAddress"].ToString();
                                obj.PropertyPrice = Convert.ToDecimal(reader["PropertyPrice"].ToString());
                                obj.PriceInterval = reader["PriceInterval"].ToString();
                                obj.PropertyLatitude = Convert.ToDecimal(reader["PropertyLatitude"].ToString());
                                obj.PropertyLongitude = Convert.ToDecimal(reader["PropertyLongitude"].ToString());
                                obj.Rooms = Convert.ToInt32(reader["Rooms"].ToString());
                                obj.DepositAmt = Convert.ToDecimal(reader["DepositAmt"].ToString());
                                obj.BedRoom = Convert.ToInt32(reader["BedRoom"].ToString());
                                obj.BathRoom = Convert.ToInt32(reader["BathRoom"].ToString());
                                obj.MoveIn = reader["MoveIn"].ToString();
                                obj.ContractLength = reader["ContractLength"].ToString();
                                obj.Furnished = reader["Furnished"].ToString();
                                obj.Description = reader["Description"].ToString();
                                obj.DistanceInKm = Convert.ToDecimal(reader["DistanceInKm"].ToString());
                                obj.DistanceInMiles = Convert.ToDecimal(reader["DistanceInMiles"].ToString());
                                obj.AmenityIds = reader["AmenityIds"].ToString();
                                obj.AmenityNamesList = reader["AmenityNames"].ToString().Split(',').ToList();
                                var images = reader["PropertyImagesPath"].ToString();
                                obj.PropertyImagesPath = new List<string>();
                                List<string> objPropertyImagesList = new List<string>();
                                for (int i = 0; i < images.Split(',').Length; i++)
                                {
                                    obj.PropertyImagesPath.Add(ConfigurationManager.AppSettings["AppBaseAddress"].ToString() + images.Split(',')[i].ToString());
                                }

                                //obj.PropertyImagesPath = String.Join(", ", objPropertyImagesList);
                                obj.DefaultPropertyImage = ConfigurationManager.AppSettings["AppBaseAddress"].ToString() + reader["DefaultPropertyImage"].ToString();
                                objList.Add(obj);
                            }
                        }
                    }
                    connection.Close();
                    return objList;
                }
                catch (Exception ex)
                {
                    return new List<AgentPropertiesSerachResponseVM>();
                }
            }
        }

        public List<PropertyModel> GetAllAgentProperties(int id, string agentId)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                List<PropertyModel> objList = new List<PropertyModel>();
                PropertyModel obj = null;
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPGetAllAgentProperties] @Id, @AgentId", connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        command.Parameters.AddWithValue("@AgentId", agentId);
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                obj = new PropertyModel();
                                obj.Id = Convert.ToInt32(reader["Id"].ToString());
                                obj.Title = reader["Title"].ToString();
                                obj.Address = reader["Address"] == null ? DBNull.Value.ToString() : reader["Address"].ToString();
                                obj.Description = reader["Description"] == null ? DBNull.Value.ToString() : reader["Description"].ToString();
                                obj.Latitude = reader["Latitude"].ToString();
                                obj.Longitude = reader["Longitude"].ToString();
                                obj.Price = Convert.ToDecimal(reader["Price"].ToString());
                                obj.PriceInterval = reader["PriceInterval"].ToString();
                                obj.Rooms = Convert.ToInt32(reader["Rooms"].ToString());
                                obj.Furnished = reader["Furnished"].ToString();
                                obj.DepositAmt = Convert.ToDecimal(reader["DepositAmt"].ToString());
                                if (reader["MoveIn"] is DBNull)
                                {
                                    obj.MoveIn = null;
                                }
                                else
                                {
                                    obj.MoveIn = Convert.ToDateTime(reader["MoveIn"].ToString());
                                }
                                obj.BedRoom = Convert.ToInt32(reader["BedRoom"].ToString());
                                obj.BathRoom = Convert.ToInt32(reader["BathRoom"].ToString());
                                obj.ContractLength = reader["ContractLength"].ToString();
                                obj.AgentId = reader["AgentId"].ToString();
                                obj.IsActive = Convert.ToBoolean(reader["IsActive"].ToString());
                                obj.IsBusy = Convert.ToBoolean(reader["IsBusy"].ToString());
                                if (reader["BusyTill"] is DBNull)
                                {
                                    obj.BusyTill = null;
                                }
                                else
                                {
                                    obj.BusyTill = Convert.ToDateTime(reader["BusyTill"].ToString());
                                }
                                obj.CreatedOn = Convert.ToDateTime(reader["CreatedOn"].ToString());
                                obj.AmentiesStr = reader["Amenties"].ToString();
                                obj.ImagesPath = reader["Images"].ToString();
                                objList.Add(obj);
                            }
                        }
                    }
                    connection.Close();
                    return objList;
                }
                catch (Exception ex)
                {
                    return new List<PropertyModel>();
                }
            }
        }

        public PropertySearchModel GetHFSSearchHistory(string userId)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                PropertySearchModel obj = new PropertySearchModel();
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPGetHFSSerachHistory] @UserId", connection))
                    {
                        command.Parameters.AddWithValue("@UserId", userId);
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                obj = new PropertySearchModel();
                                obj.UserId = reader["UserId"].ToString();
                                obj.LocationName = reader["LocationName"].ToString();
                                obj.Latitude = reader["Latitude"].ToString();
                                obj.Longitude = reader["Longitude"].ToString();
                                obj.FarFrom = reader["FarFrom"].ToString();
                                obj.PriceMin = Convert.ToDecimal(reader["PriceMin"].ToString());
                                obj.PriceMax = Convert.ToDecimal(reader["PriceMax"].ToString());
                                obj.PriceInterval = reader["PriceInterval"].ToString();
                                obj.Furnished = reader["Furnished"].ToString();
                                obj.Rooms = Convert.ToInt32(reader["Rooms"].ToString());
                                obj.RequiredTags = reader["RequiredTags"].ToString();
                                obj.Notes = reader["Notes"].ToString();
                                obj.CreatedOn = Convert.ToDateTime(reader["CreatedDate"].ToString());
                                obj.CreatedBy = reader["CreatedBy"].ToString();
                            }
                        }
                    }
                    connection.Close();
                    return obj;
                }
                catch (Exception ex)
                {
                    return new PropertySearchModel();
                }
            }
        }

        public List<AgentResponseLeadModel> GetAgentLeads(string agentId, char status = 'N')
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                List<AgentResponseLeadModel> lst = new List<AgentResponseLeadModel>();
                AgentResponseLeadModel obj = new AgentResponseLeadModel();
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[GetAgentLeads_v2] @AgentID,@Status", connection))
                    {
                        command.Parameters.AddWithValue("@AgentID", agentId);
                        command.Parameters.AddWithValue("@Status", status);
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                obj = new AgentResponseLeadModel();
                                obj.name = reader["Name"].ToString();
                                obj.email = reader["user_email"].ToString();
                                obj.Gender = Convert.ToString(reader["Gender"]);
                                obj.address = Convert.ToString(reader["address"]);
                                obj.nationality = Convert.ToString(reader["nationality"]);
                                obj.dateofBirth = Convert.ToString(reader["date_of_Birth"]);
                                obj.Age = Convert.ToString(reader["Age"]);
                                //  obj.ProfilePic = ConfigurationManager.AppSettings["AngularAppBaseAddress"].ToString() + @"\"  + Convert.ToString(reader["Profile_Pic"]);
                                obj.ProfilePic = Convert.ToString(reader["Profile_Pic"]);
                                obj.description = Convert.ToString(reader["description"]);
                                obj.policyNumber = Convert.ToString(reader["policy_number"]);
                                obj.CustomerType = Convert.ToString(reader["CustomerType"]);

                                obj.LeadStatus = reader["LeadStatus"].ToString();

                                obj.UserId = reader["User_Id"].ToString();
                                obj.LocationName = reader["LocationName"].ToString();
                                obj.Latitude = reader["Latitude"].ToString();
                                obj.Longitude = reader["Longitude"].ToString();
                                obj.FarFrom = reader["FarFrom"].ToString();
                                obj.PriceMin = Convert.ToDecimal(reader["PriceMin"].ToString());
                                obj.PriceMax = Convert.ToDecimal(reader["PriceMax"].ToString());
                                obj.PriceInterval = reader["PriceInterval"].ToString();
                                obj.Furnished = reader["Furnished"].ToString();

                                obj.Rooms = Convert.ToInt32(reader["Rooms"].ToString());
                                obj.RequiredTags = reader["RequiredTags"].ToString();
                                obj.Notes = reader["Notes"].ToString();
                                obj.createdOn = Convert.ToString(reader["created_on"]);
                                obj.SearchedDate = Convert.ToDateTime(reader["SearchedDate"]);
                                obj.ApprovedLevel = Convert.ToString(reader["ApprovedLevel"]);
                                obj.Beds = Convert.ToString(reader["Beds"]);
                                obj.LeadDate = Convert.ToDateTime(reader["LeadDate"]);
                                obj.Amenities = Convert.ToString(reader["Amenities"]);

                                obj.TenenancyStartDate = Convert.ToString(reader["TenenancyStartDate"]);
                                obj.TenenancyEndDate = Convert.ToString(reader["TenenancyEndDate"]);
                                obj.Duration = Convert.ToString(reader["Duration"]) == string.Empty ? "N/A" : Convert.ToString(reader["Duration"]) + " Months";
                                obj.PhoneNumber = reader["PhoneNumber"].ToString();
                                obj.TenenancyEndDateStr = Convert.ToString(reader["TenenancyEndDateStr"]) == string.Empty ? "N/A" : Convert.ToString(reader["TenenancyEndDateStr"]);
                                obj.TenenancyStartDateStr = Convert.ToString(reader["TenenancyStartDateStr"]) == string.Empty ? "N/A" : Convert.ToString(reader["TenenancyStartDateStr"]);
                                if (reader["RentAmount"] is DBNull)
                                {
                                    obj.RentAmount = 0;
                                }
                                else
                                {
                                    obj.RentAmount = Convert.ToDecimal(reader["RentAmount"]);
                                }

                                obj.RentType = Convert.ToString(reader["RentType"]);
                                obj.CustomerTypeStr = Convert.ToString(reader["CustomerTypeStr"]);
                                obj.iStatus = Convert.ToString(reader["iStatus"]);
                                lst.Add(obj);
                            }
                        }
                    }
                    connection.Close();
                    return lst;
                }
                catch (Exception ex)
                {
                    return new List<AgentResponseLeadModel>();
                }
            }
        }

        public int ChangeAgentLeadStatus(string applicantId, string agentId, char status)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                int response = 0;
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPChangeAgentLeadStatus] @AgentID, @ApplicantId, @Status", connection))
                    {
                        command.Parameters.AddWithValue("@AgentID", agentId);
                        command.Parameters.AddWithValue("@Status", status);
                        command.Parameters.AddWithValue("@ApplicantId", applicantId);

                        response = Convert.ToInt32(command.ExecuteScalar());
                    }
                    connection.Close();
                    return response;
                }
                catch (Exception ex)
                {
                    return -1;
                }
            }
        }

        public int AddUpdateAgentPreferences(AgentPreferencesModel model)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                int response = 0;
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPAddUpdateAgentPreferences] @AgentId,@IsStudent,@IsWorkingProfessional,@NoOfRoom, @LocationName, @Latitude, @Longitude,@FarFrom, @PriceMin, @PriceMax, @PriceInterval, @RequiredTags, @Furnished, @CreatedBy, @Result", connection))
                    {
                        command.Parameters.AddWithValue("@AgentId", model.AgentID);
                        command.Parameters.AddWithValue("@IsStudent", model.IsStudent);
                        command.Parameters.AddWithValue("@IsWorkingProfessional", model.IsWorkingProfessional);
                        command.Parameters.AddWithValue("@NoOfRoom", model.NoofRoom);

                        command.Parameters.AddWithValue("@LocationName", model.LocationName == null ? string.Empty : model.LocationName);
                        command.Parameters.AddWithValue("@Latitude", model.Latitude == null ? string.Empty : model.Latitude);
                        command.Parameters.AddWithValue("@Longitude", model.Longitude == null ? string.Empty : model.Longitude);
                        command.Parameters.AddWithValue("@FarFrom", model.FarFrom);
                        command.Parameters.AddWithValue("@PriceMin", model.PriceMin);
                        command.Parameters.AddWithValue("@PriceMax", model.PriceMax);
                        command.Parameters.AddWithValue("@PriceInterval", model.PriceInterval);

                        command.Parameters.AddWithValue("@RequiredTags", model.RequiredTags == null ? string.Empty : model.RequiredTags);


                        command.Parameters.AddWithValue("@Furnished", model.Furnished == null ? string.Empty : model.Furnished);

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

        public AgentPreferencesModel GetAgentPreferences(string agentId)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                AgentPreferencesModel obj = new AgentPreferencesModel();
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPGetAgentPreferences] @AgentId", connection))
                    {
                        command.Parameters.AddWithValue("@AgentId", agentId);
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                obj = new AgentPreferencesModel();
                                obj.AgentID = reader["AgentID"].ToString();

                                obj.IsStudent = Convert.ToBoolean(reader["IsStudent"]);

                                obj.IsWorkingProfessional = Convert.ToBoolean(reader["IsWorkingProfessional"]);

                                obj.NoofRoom = Convert.ToString(reader["NoofRoom"]);

                                obj.LocationName = reader["LocationName"].ToString();
                                obj.Latitude = reader["Latitude"].ToString();
                                obj.Longitude = reader["Longitude"].ToString();
                                obj.FarFrom = reader["FarFrom"].ToString();
                                obj.PriceMin = Convert.ToDecimal(reader["PriceMin"].ToString());
                                obj.PriceMax = Convert.ToDecimal(reader["PriceMax"].ToString());
                                obj.PriceInterval = reader["PriceIterval"].ToString();
                                obj.Furnished = reader["Furnished"].ToString();
                                obj.RequiredTags = reader["RequiredTags"].ToString();
                                obj.CreatedBy = reader["CreatedBy"].ToString();
                            }
                        }
                    }
                    connection.Close();
                    return obj;
                }
                catch (Exception ex)
                {
                    return new AgentPreferencesModel();
                }
            }
        }

        public AgentStatsModel GetAgentStats(string agentId)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                AgentStatsModel obj = new AgentStatsModel();
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[GetAgentStats] @AgentId", connection))
                    {
                        command.Parameters.AddWithValue("@AgentId", agentId);
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                obj = new AgentStatsModel();
                                obj.AgentId = agentId;
                                obj.TotalLeads = Convert.ToInt32(reader["TotalLeads"]);
                                obj.NewLeads = Convert.ToInt32(reader["NewLeads"]);
                                obj.MissedLeads = Convert.ToInt32(reader["MissedLeads"]);
                                obj.ConvertedLeads = Convert.ToInt32(reader["ConvertedLeads"].ToString());
                                obj.SearchHits = Convert.ToInt32(reader["SearchHits"].ToString());
                                obj.AgencyClicks = Convert.ToInt32(reader["AgencyClicks"].ToString());
                                obj.PropertyViews = Convert.ToInt32(reader["PropertyViews"].ToString());
                                obj.Properties = Convert.ToInt32(reader["Properties"].ToString());
                            }
                        }
                    }
                    connection.Close();
                    return obj;
                }
                catch (Exception ex)
                {
                    return new AgentStatsModel();
                }

            }
        }

        public int ConvertedToCustomer(ConvertedCustomerModel obj)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                int response = 0;
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPConvertedToCustomer] @ApplicantId, @AgentId, @LeadStatus,@CustomerType, @RentAmount, @RentType ,@TenenancyStartDate,@TenenancyEndDate, @Result", connection))
                    {
                        command.Parameters.AddWithValue("@ApplicantId", obj.ApplicantId);
                        command.Parameters.AddWithValue("@AgentId", obj.AgentID);
                        command.Parameters.AddWithValue("@LeadStatus", obj.LeadStatus);
                        command.Parameters.AddWithValue("@CustomerType", obj.CustomerType);
                        command.Parameters.AddWithValue("@RentAmount", obj.RentAmount);
                        command.Parameters.AddWithValue("@RentType", obj.RentType);
                        command.Parameters.AddWithValue("@TenenancyStartDate", obj.TenenancyStartDate);
                        command.Parameters.AddWithValue("@TenenancyEndDate", obj.TenenancyEndDate);

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

        public List<AgentHfsPrefernceModel> GetAgentByPreference(string destinationLatitude, string destinationLongitude, string locationFar, string Interval, decimal budgetFrom, decimal budgetTo, int noOfRooms, string furnishedType, string amentyIds)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                List<AgentHfsPrefernceModel> objList = new List<AgentHfsPrefernceModel>();
                AgentHfsPrefernceModel obj = null;
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPGetAgentSearchByPreferences] @DestinationLatitude, @DestinationLongitude, @LocationFar, @Interval, @BudgetFrom, @BudgetTo, @NoOfRooms, @FurnishedType, @AmenityIds", connection))
                    {
                        command.Parameters.AddWithValue("@DestinationLatitude", (!string.IsNullOrEmpty(destinationLatitude) ? destinationLatitude : string.Empty));
                        command.Parameters.AddWithValue("@DestinationLongitude", (!string.IsNullOrEmpty(destinationLongitude) ? destinationLongitude : string.Empty));
                        command.Parameters.AddWithValue("@LocationFar", (!string.IsNullOrEmpty(locationFar) ? locationFar : string.Empty));
                        command.Parameters.AddWithValue("@Interval", Interval);
                        command.Parameters.AddWithValue("@BudgetFrom", budgetFrom);
                        command.Parameters.AddWithValue("@BudgetTo", budgetTo);
                        command.Parameters.AddWithValue("@NoOfRooms", noOfRooms);
                        command.Parameters.AddWithValue("@FurnishedType", (!string.IsNullOrEmpty(furnishedType) ? furnishedType : string.Empty));
                        command.Parameters.AddWithValue("@AmenityIds", (!string.IsNullOrEmpty(amentyIds) ? amentyIds : string.Empty));
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                obj = new AgentHfsPrefernceModel();
                                obj.ID = Convert.ToInt32(reader["Id"].ToString());
                                obj.AgentId = reader["AgentId"].ToString();
                                obj.Title = reader["Title"].ToString();
                                obj.Name = reader["Name"].ToString();
                                obj.Email = reader["Email"].ToString();
                                obj.PhoneNo = reader["PhoneNo"].ToString();
                                obj.WebsiteUrl = reader["WebsiteUrl"].ToString();
                                obj.Description = reader["Description"].ToString();
                                obj.CreatedDate = reader["CreatedDate"].ToString();
                                obj.LogoPath = string.IsNullOrEmpty(reader["LogoPath"].ToString()) ? ConfigurationManager.AppSettings["AppBaseAddress"].ToString() + ConfigurationManager.AppSettings["AgentDefaultLogoImg"].ToString() : ConfigurationManager.AppSettings["AppBaseAddress"].ToString() + reader["LogoPath"].ToString();
                                obj.CoverImagePath = string.IsNullOrEmpty(reader["CoverImagePath"].ToString()) ? ConfigurationManager.AppSettings["AppBaseAddress"].ToString() + ConfigurationManager.AppSettings["AgentDefaultCoverImg"].ToString() : ConfigurationManager.AppSettings["AppBaseAddress"].ToString() + reader["CoverImagePath"].ToString();
                                obj.IsStudent = Convert.ToBoolean(reader["IsStudent"].ToString());
                                obj.IsWorkingProfessional = Convert.ToBoolean(reader["IsWorkingProfessional"].ToString());
                                obj.NoOfRoom = reader["NoOfRoom"].ToString();
                                obj.LocationName = reader["LocationName"].ToString();
                                obj.Latitude = reader["Latitude"].ToString();
                                obj.Longitude = reader["Longitude"].ToString();
                                obj.FarFrom = reader["FarFrom"].ToString();
                                obj.PriceMin = Convert.ToDecimal(reader["PriceMin"].ToString());
                                obj.PriceMax = Convert.ToDecimal(reader["PriceMax"].ToString());
                                obj.PriceIterval = reader["PriceIterval"].ToString();
                                obj.AmenityIds = reader["RequiredTags"].ToString();
                                obj.Furnished = reader["Furnished"].ToString();
                                if (reader["AmenityNames"] is DBNull)
                                {
                                    obj.AmenityNames = string.Empty;
                                }
                                else
                                {
                                    obj.AmenityNames = reader["AmenityNames"].ToString();
                                }
                                objList.Add(obj);
                            }
                        }
                    }
                    connection.Close();
                    return objList;
                }
                catch (Exception ex)
                {
                    return new List<AgentHfsPrefernceModel>();
                }
            }
        }
    }
}
