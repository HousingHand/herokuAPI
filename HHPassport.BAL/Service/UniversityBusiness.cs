using HHPassport.BAL.Interface;
using System;
using System.Collections.Generic;
using HHPassport.DAL.Models;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace HHPassport.BAL.Service
{
    public class UniversityBusiness : IUniversityBusiness
    {
        public int AddUpdateUniversity(UniversityModel model)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                int response = 0;
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPAddUpdateUniversity] @Id, @Name, @CreatedBy, @result", connection))
                    {
                        command.Parameters.AddWithValue("@Id", model.Id);
                        command.Parameters.AddWithValue("@Name", model.Name);
                        command.Parameters.AddWithValue("@CreatedBy", model.CreatedBy);
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

        public int ChangeStatus(int id, bool status)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                int response = 0;
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPChangeUniversityStatus] @Id, @Status, @Result", connection))
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

        public List<UniversityModel> GetAllUniversitesFrontEnd(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                List<UniversityModel> objUniversityList = new List<UniversityModel>();
                UniversityModel obj = null;
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPGetUniversity] @Id, @FrontEnd", connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        command.Parameters.AddWithValue("@FrontEnd", "Y");
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                obj = new UniversityModel();
                                obj.Id = Convert.ToInt32(reader["Id"].ToString());
                                obj.Name = reader["Name"].ToString();
                                obj.IsActive = Convert.ToBoolean(reader["IsActive"].ToString());
                                obj.CreatedDate = Convert.ToDateTime(reader["CreatedDate"].ToString());
                                objUniversityList.Add(obj);
                            }
                        }
                    }
                    connection.Close();
                    return objUniversityList;
                }
                catch (Exception ex)
                {
                    return new List<UniversityModel>();
                }
            }
        }


        public List<UniversityModel> GetAllUniversites(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                List<UniversityModel> objUniversityList = new List<UniversityModel>();
                UniversityModel obj = null;
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPGetUniversity] @Id", connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                obj = new UniversityModel();
                                obj.Id = Convert.ToInt32(reader["Id"].ToString());
                                obj.Name = reader["Name"].ToString();
                                obj.IsActive = Convert.ToBoolean(reader["IsActive"].ToString());
                                obj.CreatedDate = Convert.ToDateTime(reader["CreatedDate"].ToString());
                                objUniversityList.Add(obj);
                            }
                        }
                    }
                    connection.Close();
                    return objUniversityList;
                }
                catch (Exception ex)
                {
                    return new List<UniversityModel>();
                }
            }
        }
    }
}
