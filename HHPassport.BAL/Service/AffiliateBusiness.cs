using HHPassport.BAL.Interface;
using System;
using System.Collections.Generic;
using HHPassport.DAL.Models;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Newtonsoft.Json;

namespace HHPassport.BAL.Service
{
    public class AffiliateBusiness : IAffiliateBusiness
    {
        public int AddUpdateAffiliate(AffiliateModel model)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                int response = 0;
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPAddUpdateAffiliate] @affiliate_id, @affiliate_name, @email, @affiliate_code, @logo, @Affiliate_link, @country, @description, @AP_Partners, @Uni_Partners, @IsAPPayingFee, @IsAffiliateImpactPricing, @PricingType, @FixedMonthlyPrice, @FixedOneTimePrice, @PercentMonthlyPrice, @PercentOneTimePrice, @IsDoc, @ProofOfAddress, @PhotoId, @RegistrationForm, @ProofOfStudy, @ProofOfIncome, @ProofOfNI, @IsMoreField, @AnyProofId, @OtherProofId, @IsCosigner, @IsAffiliateRebate, @IsLimitedUse, @No_Of_Max_Uses, @CreatedBy, @Result", connection))
                    {
                        command.Parameters.AddWithValue("@affiliate_id", model.affiliate_id);
                        command.Parameters.AddWithValue("@affiliate_name", model.affiliate_name);
                        command.Parameters.AddWithValue("@email", model.email);
                        command.Parameters.AddWithValue("@affiliate_code", model.affiliate_code);
                        command.Parameters.AddWithValue("@logo", model.logo == null ? string.Empty : model.logo);
                        command.Parameters.AddWithValue("@Affiliate_link", model.Affiliate_link);
                        command.Parameters.AddWithValue("@country", model.country);
                        //command.Parameters.AddWithValue("@IsActive", model.IsActive);
                        command.Parameters.AddWithValue("@description", model.description);
                        command.Parameters.AddWithValue("@AP_Partners", model.AP_Partners);
                        command.Parameters.AddWithValue("@Uni_Partners", model.Uni_Partners);
                        command.Parameters.AddWithValue("@IsAPPayingFee", model.IsAPPayingFee);
                        command.Parameters.AddWithValue("@IsAffiliateImpactPricing", model.IsAffiliateImpactPricing);
                        command.Parameters.AddWithValue("@PricingType", model.PricingType);
                        command.Parameters.AddWithValue("@FixedMonthlyPrice", model.FixedMonthlyPrice);
                        command.Parameters.AddWithValue("@FixedOneTimePrice", model.FixedOneTimePrice);
                        command.Parameters.AddWithValue("@PercentMonthlyPrice", model.PercentMonthlyPrice);
                        command.Parameters.AddWithValue("@PercentOneTimePrice", model.PercentOneTimePrice);
                        command.Parameters.AddWithValue("@IsDoc", model.IsDoc);
                        command.Parameters.AddWithValue("@ProofOfAddress", model.ProofOfAddress);
                        command.Parameters.AddWithValue("@PhotoId", model.PhotoId);
                        command.Parameters.AddWithValue("@RegistrationForm", model.RegistrationForm);
                        command.Parameters.AddWithValue("@ProofOfStudy", model.ProofOfStudy);
                        command.Parameters.AddWithValue("@ProofOfIncome", model.ProofOfIncome);
                        command.Parameters.AddWithValue("@ProofOfNI", model.ProofOfNI);
                        command.Parameters.AddWithValue("@IsMoreField", model.IsMoreField);
                        command.Parameters.AddWithValue("@AnyProofId", model.AnyProofId);
                        command.Parameters.AddWithValue("@OtherProofId", model.OtherProofId);
                        command.Parameters.AddWithValue("@IsCosigner", model.IsCosigner);
                        command.Parameters.AddWithValue("@IsAffiliateRebate", model.IsAffiliateRebate);
                        command.Parameters.AddWithValue("@IsLimitedUse", model.IsLimitedUse);
                        command.Parameters.AddWithValue("@No_Of_Max_Uses", model.No_Of_Max_Uses);
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
        public AffiliateModel GetAffiliateSettings(string AffiliateCode)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {

                AffiliateModel obj = null;
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPGetAffiliateSettings] @affiliate_code", connection))
                    {
                        command.Parameters.AddWithValue("@affiliate_code", AffiliateCode);
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                obj = new AffiliateModel();
                                obj.affiliate_id = Convert.ToInt32(reader["affiliate_id"].ToString());
                                obj.affiliate_name = reader["affiliate_name"].ToString();
                                obj.affiliate_code = reader["affiliate_code"].ToString();
                                obj.email = reader["email"] is DBNull ? string.Empty : reader["email"].ToString();
                                obj.logo = reader["logo"] is DBNull ? string.Empty : ConfigurationManager.AppSettings["BaseAddress"].ToString() + reader["logo"].ToString();
                                obj.Affiliate_link = reader["Affiliate_link"].ToString();
                                obj.country = reader["country"].ToString();
                                obj.IsActive = Convert.ToBoolean(reader["IsActive"].ToString());
                                obj.description = reader["Description"].ToString();
                                obj.APPPartnerList = reader["AP_Partners"] is DBNull ? new List<APPartners>() : JsonConvert.DeserializeObject<List<APPartners>>(reader["AP_Partners"].ToString());
                                obj.UniPartnerList = reader["Uni_Partners"] is DBNull ? new List<UNIPartners>() : JsonConvert.DeserializeObject<List<UNIPartners>>(reader["Uni_Partners"].ToString());
                                obj.IsAPPayingFee = Convert.ToBoolean(reader["IsAPPayingFee"].ToString());
                                obj.IsAffiliateImpactPricing = Convert.ToBoolean(reader["IsAffiliateImpactPricing"].ToString());
                                obj.PricingType = reader["PricingType"].ToString();
                                obj.FixedMonthlyPrice = Convert.ToDecimal(reader["FixedMonthlyPrice"].ToString());
                                obj.FixedOneTimePrice = Convert.ToDecimal(reader["FixedOneTimePrice"].ToString());
                                obj.PercentMonthlyPrice = Convert.ToDecimal(reader["PercentMonthlyPrice"].ToString());
                                obj.PercentOneTimePrice = Convert.ToDecimal(reader["PercentOneTimePrice"].ToString());
                                obj.IsDoc = Convert.ToBoolean(reader["IsDoc"].ToString());
                                obj.ProofOfAddress = Convert.ToBoolean(reader["ProofOfAddress"].ToString());
                                obj.PhotoId = Convert.ToBoolean(reader["PhotoId"].ToString());
                                obj.RegistrationForm = Convert.ToBoolean(reader["RegistrationForm"].ToString());
                                obj.ProofOfIncome = Convert.ToBoolean(reader["ProofOfIncome"].ToString());
                                obj.ProofOfStudy = Convert.ToBoolean(reader["ProofOfStudy"].ToString());
                                obj.ProofOfNI = Convert.ToBoolean(reader["ProofOfNI"].ToString());
                                obj.IsMoreField = Convert.ToBoolean(reader["IsMoreField"].ToString());
                                obj.AnyProofId = reader["AnyProofId"].ToString();
                                obj.OtherProofId = reader["OtherProofId"].ToString();
                                obj.IsCosigner = Convert.ToBoolean(reader["IsCosigner"].ToString());
                                obj.IsAffiliateRebate = Convert.ToBoolean(reader["IsAffiliateRebate"].ToString());
                                obj.IsLimitedUse = Convert.ToBoolean(reader["IsLimitedUse"].ToString());
                                obj.No_Of_Max_Uses = Convert.ToInt32(reader["No_Of_Max_Uses"].ToString());
                                obj.NoOfCodeUsed = Convert.ToInt32(reader["NoOfCodeUsed"].ToString());
                            }
                        }
                        else
                        {
                            obj = new AffiliateModel();
                        }
                    }
                    connection.Close();
                    return obj;
                }
                catch (Exception ex)
                {
                    return new AffiliateModel();
                }
            }
        }
        public List<AffiliateModel> GetAffiliatesList(int AffiliateId)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                List<AffiliateModel> objAffiliatesList = new List<AffiliateModel>();
                AffiliateModel obj = null;
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPGetAffiliates] @affiliate_id", connection))
                    {
                        command.Parameters.AddWithValue("@affiliate_Id", AffiliateId);
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                obj = new AffiliateModel();
                                obj.affiliate_id = Convert.ToInt32(reader["affiliate_id"].ToString());
                                obj.affiliate_name = reader["affiliate_name"].ToString();
                                obj.email = reader["email"].ToString();
                                obj.affiliate_code = reader["affiliate_code"].ToString();
                                obj.Affiliate_link = reader["Affiliate_link"].ToString();
                                obj.logo = ConfigurationManager.AppSettings["BaseAddress"] + reader["logo"].ToString();
                                obj.country = reader["country"].ToString();
                                obj.IsActive = Convert.ToBoolean(reader["IsActive"].ToString());
                                obj.description = reader["Description"].ToString();
                                obj.AP_Partners = reader["AP_Partners"].ToString();
                                obj.Uni_Partners = reader["Uni_Partners"].ToString();
                                obj.IsAPPayingFee = Convert.ToBoolean(reader["IsAPPayingFee"].ToString());
                                obj.IsAffiliateImpactPricing = Convert.ToBoolean(reader["IsAffiliateImpactPricing"].ToString());
                                obj.PricingType = reader["PricingType"].ToString();
                                obj.FixedMonthlyPrice = Convert.ToDecimal(reader["FixedMonthlyPrice"].ToString());
                                obj.FixedOneTimePrice = Convert.ToDecimal(reader["FixedOneTimePrice"].ToString());
                                obj.PercentMonthlyPrice = Convert.ToDecimal(reader["PercentMonthlyPrice"].ToString());
                                obj.PercentOneTimePrice = Convert.ToDecimal(reader["PercentOneTimePrice"].ToString());
                                obj.IsDoc = Convert.ToBoolean(reader["IsDoc"].ToString());
                                obj.ProofOfAddress = Convert.ToBoolean(reader["ProofOfAddress"].ToString());
                                obj.PhotoId = Convert.ToBoolean(reader["PhotoId"].ToString());
                                obj.RegistrationForm = Convert.ToBoolean(reader["RegistrationForm"].ToString());
                                obj.ProofOfIncome = Convert.ToBoolean(reader["ProofOfIncome"].ToString());
                                obj.ProofOfStudy = Convert.ToBoolean(reader["ProofOfStudy"].ToString());
                                obj.ProofOfNI = Convert.ToBoolean(reader["ProofOfNI"].ToString());
                                obj.IsMoreField = Convert.ToBoolean(reader["IsMoreField"].ToString());
                                obj.AnyProofId = reader["AnyProofId"].ToString();
                                obj.OtherProofId = reader["OtherProofId"].ToString();
                                obj.IsCosigner = Convert.ToBoolean(reader["IsCosigner"].ToString());
                                obj.IsAffiliateRebate = Convert.ToBoolean(reader["IsAffiliateRebate"].ToString());
                                obj.IsLimitedUse = Convert.ToBoolean(reader["IsLimitedUse"].ToString());
                                obj.No_Of_Max_Uses = Convert.ToInt32(reader["No_Of_Max_Uses"].ToString());
                                obj.CreatedOn = Convert.ToDateTime(reader["CreatedOn"].ToString());
                                obj.CreatedBy = reader["CreatedBy"].ToString();
                               
                                objAffiliatesList.Add(obj);
                            }
                        }
                    }
                    connection.Close();
                    return objAffiliatesList;
                }
                catch (Exception ex)
                {
                    return new List<AffiliateModel>();
                }
            }
        }
        public int ActivateDeactivateAffiliate(int AffiliateId)
        {
            int response = 0;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Exec [dbo].[USPActivateDeactivateAffiliate]  @affiliate_id, @Result", connection))
                    {
                        command.Parameters.AddWithValue("@affiliate_id", AffiliateId);
                        command.Parameters.Add("@Result", SqlDbType.Int);
                        command.Parameters["@Result"].Direction = ParameterDirection.Output;
                        response = Convert.ToInt32(command.ExecuteScalar());
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    response = 0;
                }
            }
            return response;
        }
    }
}
