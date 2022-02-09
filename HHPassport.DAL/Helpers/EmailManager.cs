using HHPassport.DAL.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace HHPassport.DAL.Helpers
{
    public static class EmailManager
    {
        public static string SendForgetPasswordEmail(string emailAddress, string callbackUrl)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(ConfigurationManager.AppSettings["emailFromDisplayEmail"].ToString(), ConfigurationManager.AppSettings["emailFromDisplayName"].ToString());
                mail.IsBodyHtml = true;
                mail.To.Add(emailAddress);
                string[] bccEmiils = ConfigurationManager.AppSettings["bccEmails"].Split(',');
                foreach (var item in bccEmiils)
                {
                    mail.Bcc.Add(item);
                }
                mail.Subject = ConfigurationManager.AppSettings["ForgetPasswordSubject"].ToString();
                mail.Priority = MailPriority.High;
                string template = string.Empty;
                // string message = "<br/><br/>Please reset your password by clicking <a href=\"" + callbackUrl + "\">here</a>";
                string message = "<a target='_blank' style='color:#FFFFFF;font-size:16px;font-weight:400;line-height:120%;text-decoration:none;' href=\"" + callbackUrl + "\">Reset My Password</a>";
                template = File.ReadAllText(HttpContext.Current.Server.MapPath("~/Templates/forgetPassword-email-template.html"));
                //template = template.Replace("[#CustomerName]", customerName);
                template = template.Replace("[#Message]", message);
                template = template.Replace("[#year]", DateTime.Now.Year.ToString());

                mail.IsBodyHtml = true;
                mail.Body = template;
                SmtpClient SmtpServer = new SmtpClient();
                SmtpServer.Send(mail);
                return "1";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }
        public static string SendWelcomeEmail(string emailAddress, string password)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(ConfigurationManager.AppSettings["emailFromDisplayEmail"].ToString(), ConfigurationManager.AppSettings["emailFromDisplayName"].ToString());
                mail.IsBodyHtml = true;
                mail.To.Add(emailAddress);
                string[] bccEmiils = ConfigurationManager.AppSettings["bccEmails"].Split(',');
                foreach (var item in bccEmiils)
                {
                    mail.Bcc.Add(item);
                }
                mail.Subject = ConfigurationManager.AppSettings["WelcomeEmailSubject"].ToString();
                mail.Priority = MailPriority.High;
                string template = string.Empty;

                //template = File.ReadAllText(HttpContext.Current.Server.MapPath("~/Templates/welcome-email-template.html"));
                //template = template.Replace("[#emailaddress]", emailAddress);
                //template = template.Replace("[#username]", emailAddress);
                //template = template.Replace("[#password]", password);
                //mail.IsBodyHtml = true;
                //mail.Body = template;
                //SmtpClient SmtpServer = new SmtpClient();
                //SmtpServer.Send(mail);
                return "1";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }
        public static string SendApplicationFormEmail(String emailAddress, string name, bool isCosigner)
        {

            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(ConfigurationManager.AppSettings["emailFromDisplayEmail"].ToString(), ConfigurationManager.AppSettings["emailFromDisplayName"].ToString());
                mail.IsBodyHtml = true;
                mail.To.Add(emailAddress);
                string[] bccEmiils = ConfigurationManager.AppSettings["bccEmails"].Split(',');
                foreach (var item in bccEmiils)
                {
                    mail.Bcc.Add(item);
                }
                mail.Subject = ConfigurationManager.AppSettings["WelcomeEmailSubject"].ToString();
                mail.Priority = MailPriority.High;
                string template = string.Empty;

                template = File.ReadAllText(HttpContext.Current.Server.MapPath("~/Templates/applicant_registration_template.html"));
                template = template.Replace("[#name]", name);
                template = template.Replace("[#year]", DateTime.Now.Year.ToString());

                //if(isCosigner)
                //{

                //    template = template.Replace("[#ApprovedLink]", string.Empty);

                //}

                mail.IsBodyHtml = true;
                mail.Body = template;
                SmtpClient SmtpServer = new SmtpClient();
                SmtpServer.Send(mail);
                return "1";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }
        public static string SendApplicationCosignerEmail(GurantorCosignerVM cosigner, string Name)
        {

            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(ConfigurationManager.AppSettings["emailFromDisplayEmail"].ToString(), ConfigurationManager.AppSettings["emailFromDisplayName"].ToString());
                mail.IsBodyHtml = true;
                mail.To.Add(cosigner.Email);
                string[] bccEmiils = ConfigurationManager.AppSettings["bccEmails"].Split(',');
                foreach (var item in bccEmiils)
                {
                    mail.Bcc.Add(item);
                }
                mail.Subject = ConfigurationManager.AppSettings["CosignerWelcomeEmailSubject"].ToString();
                mail.Priority = MailPriority.High;
                string template = string.Empty;

                template = File.ReadAllText(HttpContext.Current.Server.MapPath("~/Templates/cosigner_approval_template.html"));
                template = template.Replace("[#name]", cosigner.FirstName + " " + cosigner.LastName);
                template = template.Replace("[#relationType]", cosigner.Relation);
                template = template.Replace("[#link]", cosigner.LinkURL);
                template = template.Replace("[#password]", cosigner.CoPassword);
                template = template.Replace("[#applicantName]", Name);
                template = template.Replace("[#year]", DateTime.Now.Year.ToString());


                mail.IsBodyHtml = true;
                mail.Body = template;
                SmtpClient SmtpServer = new SmtpClient();
                SmtpServer.Send(mail);
                return "1";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }
        public static string SendAPConfirmTenancyEmail(String emailAddress, string name)
        {

            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(ConfigurationManager.AppSettings["emailFromDisplayEmail"].ToString(), ConfigurationManager.AppSettings["emailFromDisplayName"].ToString());
                mail.IsBodyHtml = true;
                mail.To.Add(emailAddress);
                string[] bccEmiils = ConfigurationManager.AppSettings["bccEmails"].Split(',');
                foreach (var item in bccEmiils)
                {
                    mail.Bcc.Add(item);
                }
                mail.Subject = ConfigurationManager.AppSettings["EmailConfirmTenenacyDetail"].ToString();
                mail.Priority = MailPriority.High;
                string template = string.Empty;

                template = File.ReadAllText(HttpContext.Current.Server.MapPath("~/Templates/AP_confirmTenancy.html"));
                template = template.Replace("[#APContactName]", name);
                template = template.Replace("[#year]", DateTime.Now.Year.ToString());

                //if(isCosigner)
                //{

                //    template = template.Replace("[#ApprovedLink]", string.Empty);

                //}

                mail.IsBodyHtml = true;
                mail.Body = template;
                SmtpClient SmtpServer = new SmtpClient();
                SmtpServer.Send(mail);
                return "1";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }
        public static string SendMessageEmail(String emailAddress, string FromName, string ToName)
        {

            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(ConfigurationManager.AppSettings["emailFromDisplayEmail"].ToString(), ConfigurationManager.AppSettings["emailFromDisplayName"].ToString());
                mail.IsBodyHtml = true;
                mail.To.Add(emailAddress);
                string[] bccEmiils = ConfigurationManager.AppSettings["bccEmails"].Split(',');
                foreach (var item in bccEmiils)
                {
                    mail.Bcc.Add(item);
                }
                mail.Subject = ConfigurationManager.AppSettings["EmailSendMessageSubject"].ToString();
                mail.Priority = MailPriority.High;
                string template = string.Empty;
                //if(userType=="4")
                //template = File.ReadAllText(HttpContext.Current.Server.MapPath("~/Templates/AP_message_posted.html"));
                //else
                template = File.ReadAllText(HttpContext.Current.Server.MapPath("~/Templates/Tenant_message_posted.html"));

                template = template.Replace("[#FromName]", FromName);
                template = template.Replace("[#ToName]", ToName);
                template = template.Replace("[#year]", DateTime.Now.Year.ToString());

                //if(isCosigner)
                //{

                //    template = template.Replace("[#ApprovedLink]", string.Empty);

                //}

                mail.IsBodyHtml = true;
                mail.Body = template;
                SmtpClient SmtpServer = new SmtpClient();
                SmtpServer.Send(mail);
                return "1";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }
        public static string SendHFSEmail(String emailAddress, string name, string count, string userType)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(ConfigurationManager.AppSettings["emailFromDisplayEmail"].ToString(), ConfigurationManager.AppSettings["emailFromDisplayName"].ToString());
                mail.IsBodyHtml = true;
                mail.To.Add(emailAddress);
                string[] bccEmiils = ConfigurationManager.AppSettings["bccEmails"].Split(',');
                foreach (var item in bccEmiils)
                {
                    mail.Bcc.Add(item);
                }
                mail.Subject = ConfigurationManager.AppSettings["EmailRequestMatchViaHFS"].ToString();
                mail.Priority = MailPriority.High;
                string template = string.Empty;
                if (userType == "4")
                {
                    template = File.ReadAllText(HttpContext.Current.Server.MapPath("~/Templates/AP_via_HFS_template.html"));
                    template = template.Replace("[#APContactName]", name);
                    //template = template.Replace("[#applicantName]", name);
                }
                else
                {
                    template = File.ReadAllText(HttpContext.Current.Server.MapPath("~/Templates/Tenant_via_HFS_template.html"));

                    //template = template.Replace("[#APContactName]", name);
                    template = template.Replace("[#applicantName]", name);
                    template = template.Replace("[#NOAGENCIES]", count);
                }

                template = template.Replace("[#year]", DateTime.Now.Year.ToString());

                //if(isCosigner)
                //{

                //    template = template.Replace("[#ApprovedLink]", string.Empty);

                //}

                mail.IsBodyHtml = true;
                mail.Body = template;
                SmtpClient SmtpServer = new SmtpClient();
                SmtpServer.Send(mail);
                return "1";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

        public static string SendApplicantHFSSearchEmail(UserModel objUser, PropertySearchModel model, List<AgentHfsPrefernceModel> objAgentList)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(ConfigurationManager.AppSettings["emailFromDisplayEmail"].ToString(), ConfigurationManager.AppSettings["emailFromDisplayName"].ToString());
                mail.IsBodyHtml = true;
                mail.To.Add(ConfigurationManager.AppSettings["ApplicantHFSLeadsTo"].ToString());
                string[] bccEmiils = ConfigurationManager.AppSettings["bccEmails"].Split(',');
                foreach (var item in bccEmiils)
                {
                    mail.Bcc.Add(item);
                }
                mail.Subject = ConfigurationManager.AppSettings["NewLeadEmailSubject"].ToString();
                mail.Priority = MailPriority.High;
                string template = string.Empty;
                template = File.ReadAllText(HttpContext.Current.Server.MapPath("~/Templates/Applicant_HFS_Search_template.html"));
                template = template.Replace("[#name]", string.Format("{0} {1}", objUser.first_name, objUser.last_name));
                template = template.Replace("[#email]", objUser.user_email);
                template = template.Replace("[#contactno]", !string.IsNullOrEmpty(objUser.user_phone) ? objUser.user_phone : "--");
                template = template.Replace("[#usertype]", !string.IsNullOrEmpty(objUser.user_type) ? objUser.user_phone=="1" ? "Working professional" : "Student" : "--");
                template = template.Replace("[#location]", !string.IsNullOrEmpty(model.LocationName) ? model.LocationName : "--");
                template = template.Replace("[#distance_from_location]", model.FarFrom);
                template = template.Replace("[#weekly_monthly]", !string.IsNullOrEmpty(model.PriceInterval) ? model.PriceInterval == "PM" ? "Monthly" : "Weekly" : "---");
                template = template.Replace("[#maximumBudget]", model.PriceMax.ToString());
                template = template.Replace("[#minimumBudget]", model.PriceMin.ToString());
                template = template.Replace("[#no_Of_beds]", model.Rooms.ToString());
                template = template.Replace("[#furnishing]", model.Furnished.ToString());
                template = template.Replace("[#tags]", !string.IsNullOrEmpty(model.RequiredTags) ? model.RequiredTags : "--");
                template = template.Replace("[#extra_notes]", !string.IsNullOrEmpty(model.Notes) ? model.Notes : "--");
                template = template.Replace("[#year]", DateTime.Now.Year.ToString());
                string textBody = string.Empty;
                if (objAgentList.Count() > 0)
                {
                    textBody = "<td style='color: #023047;font-size: 13px;padding: 0px 0px 6px;font-family: arial;letter-spacing: 0.5px;'><table style='width:95%;margin:0px auto;color: #023047;font-size: 13px;padding: 0px 0px 6px;font-family: arial;letter-spacing: 0.5px;'><tbody><tr><td style='width: 150px;font - size: 15px; padding: 5px 0; color: #023047;font-weight: 600;'>Name (Title)</td><td style='font - size: 15px; padding: 5px 0; color: #023047;font-weight: 600;'> Email </td></tr></tbody>";
                    for (int loopCount = 0; loopCount < objAgentList.Count; loopCount++)
                    {
                        textBody += "<tr><td style='padding:5px 0;'>" + string.Format("{0} ({1})", objAgentList[loopCount].Name, objAgentList[loopCount].Title) + "</td><td style='padding:5px 0;'> " + objAgentList[loopCount].Email + "</td> </tr>";
                    }
                    textBody += "</table></td>";
                }
                else
                {
                    textBody += "<td style='color:#023047;font-size:13px;padding:0px 0px 10px;font-family: arial;letter-spacing:0.5px;text-align:center;'>No matching agents found</td>";
                }
                template = template.Replace("[#AgentList]", textBody);
                mail.IsBodyHtml = true;
                mail.Body = template;
                SmtpClient SmtpServer = new SmtpClient();
                SmtpServer.Send(mail);
                return "1";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }
    }
}
