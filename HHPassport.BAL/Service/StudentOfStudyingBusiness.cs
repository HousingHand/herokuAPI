using HHPassport.BAL.Interface;
using System;
using System.Collections.Generic;
using HHPassport.DAL.Models;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace HHPassport.BAL.Service
{
    public class StudentOfStudyingBusiness : IStudentOfStudyingBusiness
    {
        public int AddUpdateStudentOfStudying(StudentStudyingModel model)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                int response = 0;
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPAddUpdateStudentStudying] @Id, @Name, @CreatedBy, @Result", connection))
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

        public int ChangeStatus(int id, bool status)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                int response = 0;
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPChangeStudentStudyingStatus] @Id, @Status, @Result", connection))
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

        public List<StudentStudyingModel> GetAllStudentOfStudyingListFrontEnd()
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                List<StudentStudyingModel> objStudentStudyingList = new List<StudentStudyingModel>();
                StudentStudyingModel obj = null;
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPGetAllStudentStudyingList] @FrontEnd", connection))
                    {
                        command.Parameters.AddWithValue("@FrontEnd", "Y");
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                obj = new StudentStudyingModel();
                                obj.Id = Convert.ToInt32(reader["Id"].ToString());
                                obj.Name = reader["Name"].ToString();
                                obj.IsActive = Convert.ToBoolean(reader["IsActive"].ToString());
                                obj.CreatedDate = Convert.ToDateTime(reader["CreatedDate"].ToString());
                                obj.IsDeleted = Convert.ToBoolean(reader["IsDeleted"].ToString());
                                if (reader["UpdatedDate"] is DBNull)
                                {
                                    obj.UpdatedDate = null;
                                }
                                else
                                {
                                    obj.UpdatedDate = Convert.ToDateTime(reader["UpdatedDate"].ToString());
                                }
                                objStudentStudyingList.Add(obj);
                            }
                        }
                    }
                    connection.Close();
                    return objStudentStudyingList;
                }
                catch (Exception ex)
                {
                    return new List<StudentStudyingModel>();
                }
            }
        }

        public List<StudentStudyingModel> GetAllStudentOfStudyingList()
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                List<StudentStudyingModel> objStudentStudyingList = new List<StudentStudyingModel>();
                StudentStudyingModel obj = null;
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPGetAllStudentStudyingList]", connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                obj = new StudentStudyingModel();
                                obj.Id = Convert.ToInt32(reader["Id"].ToString());
                                obj.Name = reader["Name"].ToString();                               
                                obj.IsActive = Convert.ToBoolean(reader["IsActive"].ToString());
                                obj.CreatedDate = Convert.ToDateTime(reader["CreatedDate"].ToString());
                                obj.IsDeleted = Convert.ToBoolean(reader["IsDeleted"].ToString());
                                if (reader["UpdatedDate"] is DBNull)
                                {
                                    obj.UpdatedDate = null;
                                }
                                else
                                {
                                    obj.UpdatedDate = Convert.ToDateTime(reader["UpdatedDate"].ToString());
                                }
                                objStudentStudyingList.Add(obj);
                            }
                        }
                    }
                    connection.Close();
                    return objStudentStudyingList;
                }
                catch (Exception ex)
                {
                    return new List<StudentStudyingModel>();
                }
            }
        }
    }
}
