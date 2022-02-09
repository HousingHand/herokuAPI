using HHPassport.BAL.Interface;
using System;
using System.Collections.Generic;
using HHPassport.DAL.Models;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace HHPassport.BAL.Service
{
    public class RewardsBusiness : IRewardsBusiness
    {
        public int AddUpdateRewards(RewardsModel model)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                int response = 0;
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPAddUpdateReward] @Id, @Title, @ImagePath, @Description, @Url, @Code, @created_by, @result", connection))
                    {
                        command.Parameters.AddWithValue("@Id", model.reward_id);
                        command.Parameters.AddWithValue("@Title", model.title);
                        command.Parameters.AddWithValue("@ImagePath", model.reward_picture == null ? DBNull.Value.ToString() : model.reward_picture);
                        command.Parameters.AddWithValue("@Description", model.description == null ? string.Empty : model.description);
                        command.Parameters.AddWithValue("@Url", model.url == null ? string.Empty : model.url);
                        command.Parameters.AddWithValue("@Code", model.code == null ? string.Empty : model.code);
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
        public int ChangeStatus(int rewardId, bool status)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                int response = 0;
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPChangeRewardStatus] @RewardId, @Status, @Result", connection))
                    {
                        command.Parameters.AddWithValue("@RewardId", rewardId);
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
        public List<RewardsModel> GetAllRewardList()
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                List<RewardsModel> objRewardList = new List<RewardsModel>();
                RewardsModel obj = null;
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPGetAllRewards]", connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                obj = new RewardsModel();
                                obj.reward_id = Convert.ToInt32(reader["reward_id"].ToString());
                                obj.title = reader["title"].ToString();
                                obj.reward_picture = reader["reward_picture"] == null ? DBNull.Value.ToString() : reader["reward_picture"].ToString();
                                obj.description = reader["description"] == null ? DBNull.Value.ToString() : reader["description"].ToString();
                                obj.is_active = Convert.ToBoolean(reader["is_active"].ToString());
                                obj.url = reader["url"] == null ? DBNull.Value.ToString() : reader["url"].ToString();
                                obj.code = reader["code"] == null ? DBNull.Value.ToString() : reader["code"].ToString();
                                obj.created_date = Convert.ToDateTime(reader["created_date"].ToString());
                                objRewardList.Add(obj);
                            }
                        }
                    }
                    connection.Close();
                    return objRewardList;
                }
                catch (Exception ex)
                {
                    return new List<RewardsModel>();
                }
            }
        }
    }
}