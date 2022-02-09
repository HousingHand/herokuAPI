using HHPassport.BAL.Interface;
using System;
using System.Collections.Generic;
using HHPassport.DAL.Models;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace HHPassport.BAL.Service
{
    public class ServiceBusiness : IServiceBusiness
    {
        public int AddUpdateService(ServiceModel model)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                int response = 0;
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPAddUpdateService] @serviceid, @service_name, @service_image,@service_description, @cost, @service_for, @free_with, @created_by, @result", connection))
                    {
                        command.Parameters.AddWithValue("@serviceid", model.serviceid);
                        command.Parameters.AddWithValue("@service_name", model.service_name);
                        command.Parameters.AddWithValue("@service_image", model.service_image == null ? DBNull.Value.ToString() : model.service_image);
                        command.Parameters.AddWithValue("@service_description", model.service_description == null ? DBNull.Value.ToString() : model.service_description);
                        command.Parameters.AddWithValue("@cost", model.cost == null ? 0 : model.cost);
                        command.Parameters.AddWithValue("@service_for", model.service_for == null ? string.Empty : model.service_for);
                        command.Parameters.AddWithValue("@free_with", model.free_with == null ? string.Empty : model.free_with);
                        command.Parameters.AddWithValue("@created_by", model.created_by);
                        command.Parameters.Add("@result", SqlDbType.Int);
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
        public int ChangeStatus(int serviceId, bool status)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                int response = 0;
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPChangeServiceStatus] @ServiceId, @Status, @Result", connection))
                    {
                        command.Parameters.AddWithValue("@ServiceId", serviceId);
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
        public List<ServiceModel> GetAllServices()
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                List<ServiceModel> objServiceList = new List<ServiceModel>();
                ServiceModel obj = null;
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPGetAllServices]", connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                obj = new ServiceModel();
                                obj.serviceid = Convert.ToInt32(reader["serviceid"].ToString());
                                obj.service_name = reader["service_name"].ToString();
                                obj.service_image = reader["service_image"].ToString();
                                obj.service_description = reader["service_description"].ToString();
                                obj.cost = Convert.ToDecimal(reader["cost"].ToString());
                                obj.is_active = Convert.ToBoolean(reader["is_active"].ToString());
                                obj.service_for = reader["service_for"].ToString();
                                obj.free_with = reader["free_with"].ToString() != DBNull.Value.ToString() ? reader["free_with"].ToString() : string.Empty;
                                obj.created_on = Convert.ToDateTime(reader["created_on"].ToString());
                                if (reader["last_modified_on"] is DBNull)
                                {
                                    obj.last_modified_on = null;
                                }
                                else
                                {
                                    obj.last_modified_on = Convert.ToDateTime(reader["last_modified_on"].ToString());
                                }
                                objServiceList.Add(obj);
                            }
                        }
                    }
                    connection.Close();
                    return objServiceList;
                }
                catch (Exception ex)
                {
                    return new List<ServiceModel>();
                }
            }
        }
        public List<UserServiceModel> GetUserServices(string userId)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                List<UserServiceModel> objServiceList = new List<UserServiceModel>();
                UserServiceModel obj = null;
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPGetUserServices] @UserId", connection))
                    {
                        command.Parameters.AddWithValue("@UserId", userId);
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                obj = new UserServiceModel();
                                obj.serviceId = Convert.ToInt32(reader["serviceid"].ToString());
                                obj.service_name = reader["service_name"].ToString();
                                obj.serviceCost = Convert.ToDecimal(reader["cost"].ToString());
                                obj.serviceImage = reader["service_image"].ToString();
                                obj.slug = reader["slug"].ToString();
                                obj.servicedescription = reader["service_description"].ToString();
                                objServiceList.Add(obj);
                            }
                        }
                    }
                    connection.Close();
                    return objServiceList;
                }
                catch (Exception ex)
                {
                    return new List<UserServiceModel>();
                }
            }
        }

        public List<UserAllServiceModel> GetAllUserServices(string userId)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                List<UserAllServiceModel> objServiceList = new List<UserAllServiceModel>();
                UserAllServiceModel obj = null;
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPGetUserAllServices] @UserId", connection))
                    {
                        command.Parameters.AddWithValue("@UserId", userId);
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                obj = new UserAllServiceModel();
                                obj.serviceId = Convert.ToInt32(reader["serviceid"].ToString());
                                obj.service_name = reader["service_name"].ToString();
                                obj.serviceCost = Convert.ToDecimal(reader["cost"].ToString());
                                obj.serviceImage = reader["service_image"].ToString();
                                obj.policy_number = reader["policy_number"].ToString();
                                obj.serviceDescription = reader["service_description"].ToString();
                                obj.policy_number = reader["policy_number"].ToString();
                                obj.coverUpto = reader["coverupto"].ToString();
                                obj.lastUpdated = reader["last_updated"].ToString();
                                obj.isServiceSelected = Convert.ToBoolean(reader["isServiceSelected"]);
                                obj.slug = reader["slug"].ToString();
                                objServiceList.Add(obj);
                            }
                        }
                    }
                    connection.Close();
                    return objServiceList;
                }
                catch (Exception ex)
                {
                    return new List<UserAllServiceModel>();
                }
            }
        }

    }
}
