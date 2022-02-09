using HH_PassportModel;
using HHPassport.BAL.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Mvc;

namespace HHPassport.ClassicAPI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }

    //public class CustomAccessKeyValidator : System.Web.Http.Filters.ActionFilterAttribute
    //{
    //    public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
    //    {
    //        bool IsSandboxExist = false; bool IsProdExist = false;
    //        string accessKeyStr = actionContext.Request.Headers.SingleOrDefault(x => x.Key == "access-key").Value?.First();
    //        if (!string.IsNullOrEmpty(accessKeyStr))
    //        {
    //            List<IntegratorModel> objList = new IntegratorBusiness().GetIntegratorList(0).ToList();
    //            IsSandboxExist = objList.Where(c => c.Sandbox_key == accessKeyStr).Any();
    //            IsProdExist = objList.Where(c => c.Prod_key == accessKeyStr).Any();
    //        }
    //        else
    //        {
    //            actionContext.Response = new HttpResponseMessage()
    //            {
    //                StatusCode = HttpStatusCode.Unauthorized,
    //                Content = new StringContent("Unauthorized User")
    //            };                
    //        }

    //        if (IsSandboxExist == false && IsProdExist == false)
    //        {
    //            actionContext.Response = new HttpResponseMessage()
    //            {
    //                StatusCode = HttpStatusCode.Unauthorized,
    //                Content = new StringContent("Unauthorized User")
    //            };
    //        }
    //        base.OnActionExecuting(actionContext);

    //    }
    //}
    //public class CustomAuthorizeAttribute : AuthorizeAttribute
    //{
    //    protected override bool AuthorizeCore(HttpContextBase httpContext)
    //    {
    //        bool authorize = false;
    //        //if (SessionManager.LoginID > 0 || SessionManager.AdminLoginID > 0)
    //        //{
    //        //    authorize = true;
    //        //}
    //        return authorize;
    //    }
    //    protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
    //    {
    //        filterContext.Result = new HttpUnauthorizedResult();
    //        filterContext.HttpContext.Response.Redirect("/Account/Login");
    //    }
    //}
    //public class AuthenticationFilter : AuthorizationFilterAttribute
    //{
    //    /// <summary>
    //    /// read requested header and validated
    //    /// </summary>
    //    /// <param name="actionContext"></param>
    //    public override void OnAuthorization(HttpActionContext actionContext)
    //    {
    //        var identity = FetchFromHeader(actionContext);

    //        if (identity != null)
    //        {
    //            //var securityService = actionContext.ControllerContext.Configuration.DependencyResolver.GetService(typeof(ILoginService)) as ILoginService;
    //            //if (securityService.TokenAuthentication(identity))
    //            //{
    //            //    CurrentThread.SetPrincipal(new GenericPrincipal(new GenericIdentity(identity), null), null, null);
    //            //}
    //            //else
    //            //{
    //            //    actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
    //            //    return;
    //            //}
    //        }
    //        else
    //        {
    //            actionContext.Response = new HttpResponseMessage(HttpStatusCode.BadRequest);
    //            return;
    //        }
    //        base.OnAuthorization(actionContext);
    //    }

    //    /// <summary>
    //    /// retrive header detail from the request 
    //    /// </summary>
    //    /// <param name="actionContext"></param>
    //    /// <returns></returns>
    //    private string FetchFromHeader(HttpActionContext actionContext)
    //    {
    //        string requestToken = null;

    //        var authRequest = actionContext.Request.Headers.Authorization;
    //        if (authRequest != null && !string.IsNullOrEmpty(authRequest.Scheme) && authRequest.Scheme == "access-key")
    //            requestToken = authRequest.Parameter;

    //        return requestToken;
    //    }
    //}

}
