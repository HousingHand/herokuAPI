using HHPassport.BAL.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Security.Claims;
using HH_PassportModel;
using System.Net.Http;
using System.Net;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Newtonsoft.Json;
using static HHPassport.DAL.Enums.EnumHelper;
using iTextSharp.tool.xml;
using Swagger.Net.Annotations;
using HHPassport.ClassicAPI.Models;

namespace HHPassport.ClassicAPI.Controllers
{
    [Authorize]
    [RoutePrefix("Integrator")]
    public class IntegratorController : ApiController
    {
        #region "private member"
        private IIntegratorBusiness _IIntegratorBusiness;
        string appPhysicalPath = Convert.ToString(ConfigurationManager.AppSettings["APPPhysicalPath"]);
        readonly string apiBaseUrl = ConfigurationManager.AppSettings["ApiClassicBaseAddress"].ToString();
        #endregion

        #region "constructor"
        public IntegratorController(IIntegratorBusiness IntegratorBusiness)
        {
            _IIntegratorBusiness = IntegratorBusiness;
        }

        public IntegratorController()
        {
        }
        #endregion

        [Route("GetIntegrators")]
        [HttpGet]
        public HttpResponseMessage GetIntegrators(int id)
        {
            List<IntegratorModel> objList = _IIntegratorBusiness.GetIntegratorList(id);
            return Request.CreateResponse(HttpStatusCode.OK, objList);
        }

        [Route("AddUpdate")]
        [HttpPost]
        public HttpResponseMessage AddUpdate([FromBody] IntegratorModel obj)
        {
            try
            {
                var kvpList = new List<KeyValuePair<string, string>>
                    {
                    new KeyValuePair<string, string>("Email", obj.Email),
                    new KeyValuePair<string, string>("Password", "@Password1"),
                    new KeyValuePair<string, string>("ConfirmPassword", "@Password1")
                    };
                FormUrlEncodedContent rqstBody = new FormUrlEncodedContent(kvpList);
                using (var client = new HttpClient())
                {
                    HttpResponseMessage messge = null;
                    string result = string.Empty;
                    string url = apiBaseUrl + APIPath.IntegratorRegister.GetDescription().ToString();
                    if (obj.Integrator_Id == 0)
                    {
                        messge = client.PostAsync(url, rqstBody).Result;
                        result = messge.Content.ReadAsStringAsync().Result;
                    }
                    else
                    {
                        messge = new HttpResponseMessage();
                        messge = Request.CreateResponse(HttpStatusCode.OK);
                    }
                    if (messge.IsSuccessStatusCode)
                    {
                        int res = _IIntegratorBusiness.AddUpdateIntegrator(obj);
                        if (res > 0)
                        {
                            return Request.CreateResponse(HttpStatusCode.OK);
                        }
                        else
                        {
                            return Request.CreateResponse(HttpStatusCode.InternalServerError);
                        }
                    }
                    else
                    {
                        ErrorModel error = JsonConvert.DeserializeObject<ErrorModel>(result);
                        return Request.CreateResponse(HttpStatusCode.InternalServerError, error.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }
        }

        #region "old API's"
        //[Route("TestValidate")]
        //[HttpPost]
        //public HttpResponseMessage TestValidate()
        //{
        //    string token = Request.Headers.GetValues("Authorization").ToList()[0].ToString();
        //    if (!string.IsNullOrEmpty(token))
        //    {
        //        ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
        //        var customClaimValue = principal.Claims.Where(c => c.Type == "Env").Single().Value;
        //        return Request.CreateResponse(HttpStatusCode.OK, true);
        //    }
        //    else
        //    {
        //        return Request.CreateResponse(HttpStatusCode.Unauthorized, true);
        //    }
        //}

        //[Route("{id}")]
        //[Route("ap/{id}")]
        //[HttpPost]
        //public HttpResponseMessage UpdateTenant(string id, TenantResponseModel tenantObj)
        //{
        //    string token = Request.Headers.GetValues("Authorization").ToList()[0].ToString();

        //    if (!string.IsNullOrEmpty(token))
        //    {
        //        ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
        //        var customClaimValue = principal.Claims.Where(c => c.Type == "Env").Single().Value;
        //        ResponseModel<string> tenantResponse = new ResponseModel<string>();
        //        tenantResponse = _IIntegratorBusiness.UpdateTenant(id, tenantObj, customClaimValue);
        //        //return tenantResponse;

        //        return Request.CreateResponse(HttpStatusCode.OK, tenantResponse);
        //    }
        //    else
        //    {
        //        return Request.CreateResponse(HttpStatusCode.Unauthorized, true);
        //    }

        //}

        //[Route("balance/{id}")]
        //[HttpGet]
        //public HttpResponseMessage GetTenantBalance(string id)
        //{
        //    string token = Request.Headers.GetValues("Authorization").ToList()[0].ToString();

        //    if (!string.IsNullOrEmpty(token))
        //    {
        //        ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
        //        var customClaimValue = principal.Claims.Where(c => c.Type == "Env").Single().Value;
        //        ResponseModel<PaymentInfo> tenantResponse = new ResponseModel<PaymentInfo>();
        //        tenantResponse = _IIntegratorBusiness.GetTenantBalance(id, customClaimValue);

        //        return Request.CreateResponse(HttpStatusCode.OK, tenantResponse);
        //    }
        //    else
        //    {
        //        return Request.CreateResponse(HttpStatusCode.Unauthorized, true);
        //    }

        //}

        //[Route("email/find-by-email")]
        //[HttpGet]
        //public HttpResponseMessage find_by_email(string email)
        //{
        //    string token = Request.Headers.GetValues("Authorization").ToList()[0].ToString();

        //    if (!string.IsNullOrEmpty(token))
        //    {
        //        ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
        //        var customClaimValue = principal.Claims.Where(c => c.Type == "Env").Single().Value;
        //        ResponseModel<FindByEmailModel> tenantResponse = new ResponseModel<FindByEmailModel>();
        //        tenantResponse = _IIntegratorBusiness.find_by_email(email, customClaimValue, token);

        //        return Request.CreateResponse(HttpStatusCode.OK, tenantResponse);
        //    }
        //    else
        //    {
        //        return Request.CreateResponse(HttpStatusCode.Unauthorized, true);
        //    }

        //}

        //[HttpGet]
        //[Route("api/FileAPI/GetFile")]
        //public HttpResponse GetFile(string fileName)
        //{
        //    //HttpResponse response = HttpContext.Current.Response;
        //    //response.Clear();
        //    //response.ClearContent();
        //    //response.ClearHeaders();
        //    //response.Buffer = true;
        //    //string filePath = HttpContext.Current.Server.MapPath("~/Files/") + fileName;
        //    //response.AddHeader("Content-Disposition", "attachment;filename=\"" + filePath + "\"");

        //    //WebClient req = new WebClient();
        //    //byte[] data = req.DownloadData(HttpContext.Current.Server.MapPath(fileName));
        //    //HttpContext.Current.Response.BinaryWrite(data);
        //    //return response;
        //    HttpResponse Response = HttpContext.Current.Response;
        //    Document pdfDoc = new Document(PageSize.A4, 25, 10, 25, 10);
        //    PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        //    pdfDoc.Open();
        //    Paragraph Text = new Paragraph("This is test file");
        //    pdfDoc.Add(Text);
        //    pdfWriter.CloseStream = false;
        //    pdfDoc.Close();
        //    Response.Buffer = true;
        //    Response.ContentType = "application/pdf";
        //    Response.AddHeader("content-disposition", "attachment;filename=Example.pdf");
        //    Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //    Response.Write(pdfDoc);
        //    Response.End();
        //    return Response;
        //}

        //[AllowAnonymous]
        //[HttpGet]
        //[Route("api/ped/{id}")]
        //public HttpResponse DownloadPDF(string id)
        //{
        //    string token = Request.Headers.GetValues("Authorization").ToList()[0].ToString();
        //    HttpResponse Response = HttpContext.Current.Response;
        //    if (!string.IsNullOrEmpty(token))
        //    {
        //        ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
        //        var customClaimValue = principal.Claims.Where(c => c.Type == "Env").Single().Value;
        //        string url = System.Web.HttpContext.Current.Server.MapPath("~/PaymentTemplate.html");
        //        string ImgPath = System.Web.HttpContext.Current.Server.MapPath("~/hh-logo.png");
        //        ResponseModel<PedDetails> resObj = new ResponseModel<PedDetails>();
        //        resObj = _IIntegratorBusiness.TenantPDF(id, customClaimValue);
        //        //CSSResolver cssResolver = new StyleAttrCSSResolver();
        //        //CssFile cssFile = iTextSharp.tool.xml.XMLWorkerHelper.GetCSS(new ByteArrayInputStream(CSS.getBytes()));
        //        //cssResolver.addCss(cssFile);
        //        var HTMLContent = File.ReadAllText(Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~"), "PaymentTemplate.html"));

        //        //HTMLContent = HTMLContent.Replace("$$agent_Name", resObj.data.agent_Name.ToString());
        //        HTMLContent = HTMLContent.Replace("$$StartDate", resObj.data.StartDate.ToString());
        //        HTMLContent = HTMLContent.Replace("$$Path", ImgPath);
        //        HTMLContent = HTMLContent.Replace("$$EndDate", resObj.data.EndDate.ToString());
        //        HTMLContent = HTMLContent.Replace("$$PhoneNumber", resObj.data.phone_number.ToString());
        //        HTMLContent = HTMLContent.Replace("$$Email", resObj.data.email.ToString());
        //        HTMLContent = HTMLContent.Replace("$$User_Name", resObj.data.agent_Name.ToString() + resObj.data.first_name.ToString());
        //        //HttpResponse Response = HttpContext.Current.Response;
        //        WebClient req = new WebClient();
        //        Response.Clear();
        //        Response.ContentType = "application/pdf";
        //        Response.AddHeader("content-disposition", "attachment;filename=" + "PDFfile.pdf");
        //        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //        Response.BinaryWrite(GetPDF(HTMLContent));
        //        // byte[] data = req.DownloadData(GetPDF(HTMLContent));
        //        Response.End();
        //        return Response;
        //    }
        //    else
        //    {

        //        return Response;
        //    }
        //}

        //[Route("upload-document/{id}")]
        //[Route("upload-cosigner-document/{id}")]
        //[HttpPost]
        //public HttpResponseMessage UploadDocuments(string id, TenantDocumentModel list)
        //{
        //    string token = Request.Headers.GetValues("Authorization").ToList()[0].ToString();

        //    if (!string.IsNullOrEmpty(token))
        //    {
        //        try
        //        {
        //            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
        //            var customClaimValue = principal.Claims.Where(c => c.Type == "Env").Single().Value;
        //            int res = 0;
        //            res = _IIntegratorBusiness.UploadDocuments(list, id);
        //            if (res > 0)
        //            {
        //                return Request.CreateResponse(HttpStatusCode.OK, "Tenant document/s has been successfully uploaded!");
        //            }
        //            else
        //            {
        //                return Request.CreateResponse(HttpStatusCode.InternalServerError);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
        //        }
        //    }
        //    else
        //    {
        //        return Request.CreateResponse(HttpStatusCode.Unauthorized, true);
        //    }
        //}

        //[Route("documents/{id}")]
        //[HttpGet]
        //public HttpResponseMessage GetDocuments(string id)
        //{
        //    ResponseModel<List<docs>> obj = new ResponseModel<List<docs>>();
        //    try
        //    {
        //        string token = Request.Headers.GetValues("Authorization").ToList()[0].ToString();

        //        if (!string.IsNullOrEmpty(token))
        //        {
        //            List<docs> listDoc = _IIntegratorBusiness.GetDocuments(id);
        //            obj.data = listDoc;
        //            obj.message = "Tenant documents has been successfully retrieved!";
        //            return Request.CreateResponse(HttpStatusCode.OK, obj);
        //        }
        //        else
        //        {
        //            return Request.CreateResponse(HttpStatusCode.Unauthorized, true);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        obj.data = new List<docs>();
        //        obj.message = "Problem while retriving data!";

        //        return Request.CreateResponse(HttpStatusCode.InternalServerError, obj);
        //    }
        //}

        //[Route("verify/refno/{id}")]
        //[HttpGet]
        //public HttpResponseMessage ValidateRefNumber(string id, string refno)
        //{
        //    string token = Request.Headers.GetValues("Authorization").ToList()[0].ToString();

        //    if (!string.IsNullOrEmpty(token))
        //    {
        //        VerficationModel objModel = new VerficationModel();

        //        bool isValid = _IIntegratorBusiness.GetValidateRefNumber(id, refno);

        //        if (isValid)
        //        {
        //            objModel.text = "valid";
        //            objModel.status = isValid;
        //        }
        //        else
        //        {
        //            objModel.text = "invalid"; objModel.status = isValid;
        //        }


        //        return Request.CreateResponse(HttpStatusCode.OK, objModel);
        //    }
        //    else
        //    {
        //        return Request.CreateResponse(HttpStatusCode.Unauthorized, true);
        //    }
        //}

        //[Route("cosigner/{id}")]
        //[HttpPost]
        //public HttpResponseMessage CreateUpdateCosigner(string id, CosignerInfo cosignerObj)
        //{
        //    string token = Request.Headers.GetValues("Authorization").ToList()[0].ToString();

        //    if (!string.IsNullOrEmpty(token))
        //    {
        //        ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
        //        var customClaimValue = principal.Claims.Where(c => c.Type == "Env").Single().Value;
        //        ResponseModel<string> tenantResponse = new ResponseModel<string>();
        //        ResponseModel<string> response = new ResponseModel<string>();
        //        response = _IIntegratorBusiness.verify_email(cosignerObj.email, customClaimValue);

        //        //if (response.data != null)
        //        //{
        //        //    tenantResponse.code = "Conflict";
        //        //    tenantResponse.message = "Email already in use";
        //        //    return Request.CreateResponse(HttpStatusCode.OK, tenantResponse);
        //        //}
        //        tenantResponse = _IIntegratorBusiness.CreateUpdateCosigner(id, cosignerObj, customClaimValue);
        //        return Request.CreateResponse(HttpStatusCode.OK, tenantResponse);
        //    }
        //    else
        //    {
        //        return Request.CreateResponse(HttpStatusCode.Unauthorized, true);
        //    }
        //}
        #endregion

        #region "helper"
        private string verifyDateFormat(string inputString)
        {

            DateTime dDate;

            if (DateTime.TryParse(inputString, out dDate))
            {
                return String.Format("{0:d yyyy-MM-dd}", dDate);
            }
            else
            {
                Console.WriteLine("Invalid"); // <-- Control flow goes here
                return null;
            }
        }

        private byte[] GetPDF(string pHTML)
        {
            // byte[] bPDF = null;

            //MemoryStream ms = new MemoryStream();          
            ////TextReader txtReader = new StringReader(pHTML);
            //TextReader txtReader = new StringReader(pHTML);

            //// 1: create object of a itextsharp document class  
            //Document doc = new Document(PageSize.A4, 25, 25, 25, 25);

            //// 2: we create a itextsharp pdfwriter that listens to the document and directs a XML-stream to a file  
            //PdfWriter oPdfWriter = PdfWriter.GetInstance(doc, ms);

            //// 3: we create a worker parse the document  
            //HTMLWorker htmlWorker = new HTMLWorker(doc);

            //// 4: we open document and start the worker on the document  
            //doc.Open();
            //htmlWorker.StartDocument();


            //// 5: parse the html into the document  
            //htmlWorker.Parse(txtReader);

            //// 6: close the document and the worker  
            //htmlWorker.EndDocument();
            //htmlWorker.Close();
            //doc.Close();

            //bPDF = ms.ToArray();
            //return bPDF;


            byte[] bytes;
            using (var ms = new MemoryStream())
            {
                //Document doc = new Document(PageSize.A4, 25, 25, 25, 25);
                using (var doc = new iTextSharp.text.Document(PageSize.A4.Rotate(), 0, 0, 0, 0))
                {
                    //doc.SetPageSize(new Rectangle(850f, 1100f));
                    using (var writer = PdfWriter.GetInstance(doc, ms))
                    {
                        doc.Open();

                        using (var srHtml = new StringReader(pHTML))
                        {
                            XMLWorkerHelper.GetInstance().ParseXHtml(writer, doc, srHtml);
                        }

                        //doc.NewPage();
                        doc.Close();
                    }
                }
                bytes = ms.ToArray();
            }
            return bytes;

        }
        #endregion
    }   

}