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
    public class PaymentBusiness : IPaymentBusiness
    {
        public int AddUpdatePaymentInfo(PaymentInfoModel model)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                int response = 0;
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPAddPaymentInfo] @ApplicantId, @Stripe_ProductId, @Stripe_SubscriptionId, @Stripe_SubscriptionStartDate, @Stripe_SubscriptionEndDate, @Stripe_ChargeId, @Amount, @IsRecurring, @Interval, @PaymentFor, @Status, @CreatedDate, @Result", connection))
                    {
                        command.Parameters.AddWithValue("@ApplicantId", model.ApplicantId);
                        if (model.Stripe_ProductId == null)
                        {
                            command.Parameters.AddWithValue("@Stripe_ProductId", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@Stripe_ProductId", model.Stripe_ProductId);
                        }

                        if (model.Stripe_SubscriptionId == null)
                        {
                            command.Parameters.AddWithValue("@Stripe_SubscriptionId", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@Stripe_SubscriptionId", model.Stripe_SubscriptionId);
                        }
                       
                        if (model.Stripe_SubscriptionStartDate == null)
                        {
                            command.Parameters.AddWithValue("@Stripe_SubscriptionStartDate", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@Stripe_SubscriptionStartDate", model.Stripe_SubscriptionStartDate);
                        }

                        if (model.Stripe_SubscriptionEndDate == null)
                        {
                            command.Parameters.AddWithValue("@Stripe_SubscriptionEndDate", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@Stripe_SubscriptionEndDate", model.Stripe_SubscriptionEndDate);
                        }

                        if (model.Stripe_ChargeId == null)
                        {
                            command.Parameters.AddWithValue("@Stripe_ChargeId", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@Stripe_ChargeId", model.Stripe_ChargeId);
                        }
                      
                        command.Parameters.AddWithValue("@Amount", model.Amount);
                        command.Parameters.AddWithValue("@IsRecurring", model.IsRecurring);
                        if (model.Interval == null)
                        {
                            command.Parameters.AddWithValue("@Interval", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@Interval", model.Interval);
                        }
                        command.Parameters.AddWithValue("@PaymentFor", model.PaymentFor);
                        command.Parameters.AddWithValue("@Status", model.Status);
                        command.Parameters.AddWithValue("@CreatedDate", model.CreatedDate);
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
    }
}
