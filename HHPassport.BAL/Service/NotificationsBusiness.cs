using HHPassport.BAL.Interface;
using System;
using System.Collections.Generic;
using HHPassport.DAL.Models;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Newtonsoft.Json;
using static HHPassport.DAL.Models.ChatModel;

namespace HHPassport.BAL.Service
{
    public class NotificationsBusiness : INotificationsBusiness
    {
        public int AddUpdateNotification(NotificationModel model)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                int response = 0;
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPAddUpdateNotification] @Id, @Event, @NotificationText, @Mode, @CreatedBy, @result", connection))
                    {
                        command.Parameters.AddWithValue("@Id", model.notification_id);
                        command.Parameters.AddWithValue("@Event", model.event_name);
                        command.Parameters.AddWithValue("@NotificationText", model.notification_text == null ? DBNull.Value.ToString() : model.notification_text);
                        command.Parameters.AddWithValue("@Mode", model.mode == null ? string.Empty : model.mode);
                        command.Parameters.AddWithValue("@CreatedBy", model.created_by);
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

        public int ChangeStatus(int notificationId, bool status)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                int response = 0;
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPChangeNotificationStatus] @NotificationId, @Status, @Result", connection))
                    {
                        command.Parameters.AddWithValue("@NotificationId", notificationId);
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

        public List<NotificationModel> GetAllNotifications()
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                List<NotificationModel> objNotificationList = new List<NotificationModel>();
                NotificationModel obj = null;
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPGetAllNotifications]", connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                obj = new NotificationModel();
                                obj.notification_id = Convert.ToInt32(reader["notification_id"].ToString());
                                obj.event_name = reader["event"].ToString();
                                obj.notification_text = reader["notification_text"].ToString() == DBNull.Value.ToString() ? string.Empty : reader["notification_text"].ToString();
                                obj.mode = reader["mode"].ToString() == DBNull.Value.ToString() ? string.Empty : reader["mode"].ToString();
                                obj.is_active = Convert.ToBoolean(reader["is_active"].ToString());
                                obj.created_date = Convert.ToDateTime(reader["created_date"].ToString());
                                objNotificationList.Add(obj);
                            }
                        }
                    }
                    connection.Close();
                    return objNotificationList;
                }
                catch (Exception ex)
                {
                    return new List<NotificationModel>();
                }
            }
        }

        public List<MessageModel> GetChat(string fromUserId, string toUserId)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                List<MessageModel> objList = new List<MessageModel>();
                MessageModel obj = null;
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPGetChat] @FromUserID, @ToUserID", connection))
                    {
                        command.Parameters.AddWithValue("@FromUserID", fromUserId);
                        command.Parameters.AddWithValue("@ToUserID", toUserId);

                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                obj = new MessageModel();
                                obj.FromId = Convert.ToString(reader["FromId"]);
                                obj.ToId = Convert.ToString(reader["ToId"]);
                                obj.MessageText = Convert.ToString(reader["MessageText"]);
                                obj.MessageType = Convert.ToInt32(reader["MessageType"]);
                                obj.IsRead = Convert.ToBoolean(reader["IsRead"].ToString());
                                obj.DateSent = Convert.ToDateTime(reader["SentAt"]);
                                obj.SendDateStr = reader["SendDateStr"].ToString();
                                obj.FromUserName = Convert.ToString(reader["fromuser"]);
                                obj.ToUserName = Convert.ToString(reader["touser"]);
                                objList.Add(obj);
                            }
                        }
                    }
                    connection.Close();
                    return objList;
                }
                catch (Exception ex)
                {
                    return new List<MessageModel>();
                }
            }
        }

        public int SaveChatMessage(SaveMessageModel model)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                int response = 0;
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPSaveChat] @FromUserID, @ToUserID, @MessageText, @MessageType, @result", connection))
                    {
                        command.Parameters.AddWithValue("@FromUserID", model.FromId);
                        command.Parameters.AddWithValue("@ToUserID", model.ToId);
                        command.Parameters.AddWithValue("@MessageText", model.MessageText);
                        command.Parameters.AddWithValue("@MessageType", model.MessageType);



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

        public List<ApplicantUserModel> GetApplicantUsers(string userID)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                List<ApplicantUserModel> objList = new List<ApplicantUserModel>();
                ApplicantUserModel obj = null;
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[GetApplicantUserInfo] @userID ", connection))
                    {
                        command.Parameters.AddWithValue("@userID", userID);

                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                obj = new ApplicantUserModel();
                                obj.AgentName = Convert.ToString(reader["Name"]);
                                obj.UserId = Convert.ToString(reader["user_id"]);
                                obj.UserType = Convert.ToString(reader["userType"]);
                                obj.Photo = Convert.ToString(reader["Photo"]);
                                obj.MessageCount = Convert.ToInt32(reader["messageCount"]);
                                obj.TotalmessageCount = Convert.ToInt32(reader["TotalmessageCount"]);
                                objList.Add(obj);
                            }
                        }
                    }
                    connection.Close();
                    return objList;
                }
                catch (Exception ex)
                {
                    return new List<ApplicantUserModel>();
                }
            }
        }
        public EmailModel GetUserInfo(string userID)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                //List<EmailModel> objList = new List<EmailModel>();
                EmailModel obj = null;
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[GetUserInfo] @userID ", connection))
                    {
                        command.Parameters.AddWithValue("@userID", userID);

                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                obj = new EmailModel();
                                //obj.AgentName = Convert.ToString(reader["Name"]);
                                obj.userId = Convert.ToString(reader["user_id"]);
                                obj.userType = Convert.ToString(reader["userType"]);   
                                //objList.Add(obj);
                            }
                        }
                    }
                    connection.Close();
                    return obj;
                }
                catch (Exception ex)
                {
                    return new EmailModel();
                }
            }
        }

        public int UpdateMessageAsRead(string userID)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                int response = 0;
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPUpdateSetReadMessage] @UserId, @result", connection))
                    {
                        command.Parameters.AddWithValue("@UserId", userID);
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

        public List<UserChatHistoryVM> GetUnReadMsg(string toUserId, bool IsMarkAsRead)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                List<UserChatHistoryVM> objList = new List<UserChatHistoryVM>();
                UserChatHistoryVM obj = null;
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPGetUnReadMsg_v1] @ToUserID, @IsMarkeAsRead", connection))
                    {
                        command.Parameters.AddWithValue("@ToUserID", toUserId);
                        command.Parameters.AddWithValue("@IsMarkeAsRead", IsMarkAsRead);
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                obj = new UserChatHistoryVM();
                                obj.FromId = Convert.ToString(reader["FromId"]);
                                obj.Name = Convert.ToString(reader["Name"]);
                                obj.UnreadCount = Convert.ToInt32(reader["UnreadCount"].ToString());
                                obj.ChatHistory = reader["ChatHistory"] is DBNull ? new List<ChatModel>() : JsonConvert.DeserializeObject<List<ChatModel>>("[" + reader["ChatHistory"].ToString() + "]");    
                                objList.Add(obj);
                            }
                        }
                    }
                    connection.Close();
                    return objList;
                }
                catch (Exception ex)
                {
                    return new List<UserChatHistoryVM>();
                }
            }
        }
    }
}
