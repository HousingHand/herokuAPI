using HHPassport.BAL.Interface;
using System;
using System.Collections.Generic;
using HHPassport.DAL.Models;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace HHPassport.BAL.Service
{
    public class CourseBusiness : ICourseBusiness
    {
        public int AddUpdateCourse(CourseModel model)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                int response = 0;
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPAddUpdateCourse] @Id, @StudentStudyingId, @Name, @CreatedBy, @Result", connection))
                    {
                        command.Parameters.AddWithValue("@Id", model.Id);
                        command.Parameters.AddWithValue("@StudentStudyingId", model.StudentStudyingId);
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
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPChangeCourseStatus] @Id, @Status, @Result", connection))
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

        public List<CourseModel> GetAllCoursesFrontEnd()
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                List<CourseModel> objCourseList = new List<CourseModel>();
                CourseModel obj = null;
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPGetAllCourses] @FrontEnd", connection))
                    {
                        command.Parameters.AddWithValue("@FrontEnd", "Y");
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                obj = new CourseModel();
                                obj.Id = Convert.ToInt32(reader["Id"].ToString());
                                obj.StudentStudyingId = Convert.ToInt32(reader["StudentStudyingId"].ToString());
                                obj.StudentStudyingName = reader["StudentStudyingName"].ToString();
                                obj.Name = reader["Name"].ToString();
                                obj.IsActive = Convert.ToBoolean(reader["IsActive"].ToString());
                                obj.CreatedDate = Convert.ToDateTime(reader["CreatedDate"].ToString());
                                if (reader["UpdatedDate"] is DBNull)
                                {
                                    obj.UpdatedDate = null;
                                }
                                else
                                {
                                    obj.UpdatedDate = Convert.ToDateTime(reader["UpdatedDate"].ToString());
                                }
                                objCourseList.Add(obj);
                            }
                        }
                    }
                    connection.Close();
                    return objCourseList;
                }
                catch (Exception ex)
                {
                    return new List<CourseModel>();
                }
            }
        }


        public List<CourseModel> GetAllCourses()
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                List<CourseModel> objCourseList = new List<CourseModel>();
                CourseModel obj = null;
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPGetAllCourses]", connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                obj = new CourseModel();
                                obj.Id = Convert.ToInt32(reader["Id"].ToString());
                                obj.StudentStudyingId = Convert.ToInt32(reader["StudentStudyingId"].ToString());
                                obj.StudentStudyingName = reader["StudentStudyingName"].ToString();
                                obj.Name = reader["Name"].ToString();
                                obj.IsActive = Convert.ToBoolean(reader["IsActive"].ToString());
                                obj.CreatedDate = Convert.ToDateTime(reader["CreatedDate"].ToString());
                                if (reader["UpdatedDate"] is DBNull)
                                {
                                    obj.UpdatedDate = null;
                                }
                                else
                                {
                                    obj.UpdatedDate = Convert.ToDateTime(reader["UpdatedDate"].ToString());
                                }
                                objCourseList.Add(obj);
                            }
                        }
                    }
                    connection.Close();
                    return objCourseList;
                }
                catch (Exception ex)
                {
                    return new List<CourseModel>();
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
