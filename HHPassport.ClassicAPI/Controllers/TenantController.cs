using HH_PassportModel;
using HHPassport.BAL.Interface;
using HHPassport.DAL.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using static HHPassport.DAL.Enums.EnumHelper;

namespace HHPassport.ClassicAPI.Controllers
{
    //[Authorize]
    [RoutePrefix("Tenant")]
    public class TenantController : ApiController
    {
        readonly string apiBaseUrl = ConfigurationManager.AppSettings["ApiClassicBaseAddress"].ToString();
        private IIntegratorBusiness _IIntegratorBusiness;
        public TenantController(IIntegratorBusiness IntegratorBusiness)
        {
            _IIntegratorBusiness = IntegratorBusiness;
        }
        [Route("Save")]
        [HttpPost]
        public HttpResponseMessage tenant(TenantResponseModel tenantObj)
        {
            tenantObj.account_info.password = ConvertToHashPassword(tenantObj.account_info.password);
            //string cosignerRandomHashPassword = ConvertToHashPassword(CommonManager.CreateRandomPassword(6));
            string cosignerRandomHashPassword = ConvertToHashPassword(!string.IsNullOrEmpty(tenantObj.application_info.cosigner_info.password) ? tenantObj.application_info.cosigner_info.password : "@Password1");
            string token = Request.Headers.GetValues("Authorization").ToList()[0].ToString();
            if (!string.IsNullOrEmpty(token))
            {
                ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
                var customClaimValue = principal.Claims.Where(c => c.Type == "Env").Single().Value;
                LoginResponseModel tenantResponse = new LoginResponseModel();
                if (tenantObj.personal_info == null)
                {
                    tenantResponse.code = "Bad Request";
                    tenantResponse.message = "personal_info attribute is required.";
                    return Request.CreateResponse(HttpStatusCode.BadRequest, tenantResponse);
                }
                else if (tenantObj.account_info == null)
                {
                    tenantResponse.code = "Bad Request";
                    tenantResponse.message = "account_info attribute is required.";
                    return Request.CreateResponse(HttpStatusCode.BadRequest, tenantResponse);
                }
                else if (tenantObj.application_info == null)
                {
                    tenantResponse.code = "Bad Request";
                    tenantResponse.message = "application_info attribute is required.";
                    return Request.CreateResponse(HttpStatusCode.BadRequest, tenantResponse);
                }
                //else if (tenantObj.application_info.ap_details != null)
                //{
                //    DateTime dDate;
                //    string startDate = null, endDate = null;
                //    string[] sdate = null, edate = null;
                //    if (DateTime.TryParse(tenantObj.application_info.ap_details.rent.start_date.ToString(), out dDate))
                //    {
                //        startDate = String.Format("{0:d yyyy-MM-dd}", dDate);
                //        sdate = startDate.Split(' ');
                //    }
                //    if (DateTime.TryParse(tenantObj.application_info.ap_details.rent.end_date.ToString(), out dDate))
                //    {
                //        endDate = String.Format("{0:d yyyy-MM-dd}", dDate);
                //        edate = endDate.Split(' ');
                //    }

                //    if (sdate != null && edate != null)
                //        if ((sdate[1].ToString() != tenantObj.application_info.ap_details.rent.start_date.ToString()) && (edate[1].ToString() != tenantObj.application_info.ap_details.rent.end_date.ToString()))
                //        {
                //            tenantResponse.code = "BadRequest";
                //            tenantResponse.message = "Invalid date format, it must be YYYY-MM-DD format.";
                //            return Request.CreateResponse(HttpStatusCode.BadRequest, tenantResponse);
                //        }
                //}
                ResponseModel<string> response = new ResponseModel<string>();
                response = _IIntegratorBusiness.verify_email(tenantObj.account_info.email, customClaimValue);
                if (response.data != null)
                {
                    tenantResponse.code = "Conflict";
                    tenantResponse.message = "Email already in use";
                    return Request.CreateResponse(HttpStatusCode.OK, tenantResponse);
                }
                tenantObj.application_info.cosigner_info.password = cosignerRandomHashPassword;
                tenantResponse = _IIntegratorBusiness.tenant(tenantObj, customClaimValue, token);
                return Request.CreateResponse(HttpStatusCode.OK, tenantResponse);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized, true);
            }
        }

        #region "helper"
        private string ConvertToHashPassword(string passwordStr)
        {
            using (var client = new HttpClient())
            {
                string url = apiBaseUrl + APIPath.GetHashPassword.GetDescription().ToString() + "?passwordStr=" + passwordStr;
                HttpResponseMessage messge = client.GetAsync(url).Result;
                string result = messge.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<string>(result);
            }
        }

        #endregion
    }
}
