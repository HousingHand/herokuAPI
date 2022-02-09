using HHPassport.BAL.Interface;
using System;
using System.Collections.Generic;
using HHPassport.DAL.Models;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace HHPassport.BAL.Service
{
    public class AmentiesBusiness : IAmentiesBusiness
    {
        public int AddUpdateAmenties(AmenitiesModel model)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                int response = 0;
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPAddUpdateAmenties] @Id, @Name, @CreatedBy, @Result", connection))
                    {
                        command.Parameters.AddWithValue("@Id", model.Id);
                        command.Parameters.AddWithValue("@Name", model.Name);
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

        public int ChangeStatus(int amenityId, bool status)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                int response = 0;
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPChangeAmenitiesStatus] @Id, @Status, @Result", connection))
                    {
                        command.Parameters.AddWithValue("@Id", amenityId);
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

        public List<AmenitiesModel> GetAllAmenities()
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                List<AmenitiesModel> objAmentiesList = new List<AmenitiesModel>();
                AmenitiesModel obj = null;
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPGetAllAmenties]", connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                obj = new AmenitiesModel();
                                obj.Id = Convert.ToInt32(reader["Id"].ToString());
                                obj.Name = reader["Name"].ToString();
                                obj.IsActive = Convert.ToBoolean(reader["IsActive"].ToString());
                                obj.CreatedDate = Convert.ToDateTime(reader["CreatedDate"].ToString());
                                if (reader["UpdatedOn"] is DBNull)
                                {
                                    obj.UpdatedOn = null;
                                }
                                else
                                {
                                    obj.UpdatedOn = Convert.ToDateTime(reader["UpdatedOn"].ToString());
                                }
                                objAmentiesList.Add(obj);
                            }
                        }
                    }
                    connection.Close();
                    return objAmentiesList;
                }
                catch (Exception ex)
                {
                    return new List<AmenitiesModel>();
                }
            }
        }

        public string GetAmenitiesTagByIds(string amenitiesIds)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                string response = string.Empty;
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPGetAmenitiesByIds] @AmenityIds, @Result", connection))
                    {
                        command.Parameters.AddWithValue("@AmenityIds", amenitiesIds);
                        command.Parameters.Add("@Result", SqlDbType.NVarChar, 2000);
                        command.Parameters["@Result"].Direction = ParameterDirection.Output;
                        response = command.ExecuteScalar().ToString();
                    }
                    connection.Close();
                    return response;
                }
                catch (Exception ex)
                {
                    return string.Empty;
                }
            }
        }
    }
}
