using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using HHPassport.ClassicAPI.Models;
using Microsoft.Owin;
using HHPassport.BAL.Service;
using HH_PassportModel;
using HHPassport.DAL.Models;

namespace HHPassport.ClassicAPI.Providers
{
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        private readonly string _publicClientId;

        public ApplicationOAuthProvider(string publicClientId)
        {
            if (publicClientId == null)
            {
                throw new ArgumentNullException("publicClientId");
            }

            _publicClientId = publicClientId;
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var userManager = context.OwinContext.GetUserManager<ApplicationUserManager>();
            IFormCollection parameters = await context.Request.ReadFormAsync();
            string Env = parameters.Get("SecretKey");
            //KeyValidatorModel objModel = new UserBusiness().IsValidKey( Env,"");
            KeyValidatorModel objModel = new KeyValidatorModel();
            if (objModel == null)
            {
                context.SetError("invalid_grant", "Invalid Key");
                return;
            }
            ApplicationUser user = await  userManager.FindByNameAsync(objModel.email);         
            
            if (user == null)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return;
            }

            ClaimsIdentity oAuthIdentity = await user.GenerateUserIdentityAsync(userManager,
               OAuthDefaults.AuthenticationType);
            ClaimsIdentity cookiesIdentity = await user.GenerateUserIdentityAsync(userManager,
                CookieAuthenticationDefaults.AuthenticationType);

            AuthenticationProperties properties = CreateProperties(user.UserName  , objModel );
            AuthenticationTicket ticket = new AuthenticationTicket(oAuthIdentity, properties);
             oAuthIdentity.AddClaim(new Claim("Env", Convert.ToBoolean(objModel.IsProduction) ? "Production" : "Development"));
            context.Validated(ticket);
            //context.OwinContext.Response.Headers.Add("Environment", new[] { Convert.ToBoolean(objModel.IsProduction) ? "Production" : "Development" });

            context.Request.Context.Authentication.SignIn(cookiesIdentity);
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            // Resource owner password credentials does not provide a client ID.
            if (context.ClientId == null)
            {
                context.Validated();
            }

            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context)
        {
            if (context.ClientId == _publicClientId)
            {
                Uri expectedRootUri = new Uri(context.Request.Uri, "/");

                if (expectedRootUri.AbsoluteUri == context.RedirectUri)
                {
                    context.Validated();
                }
            }

            return Task.FromResult<object>(null);
        }


       


        public static AuthenticationProperties CreateProperties(string userName, KeyValidatorModel objModel)
        {

            if (objModel == null)
                objModel = new KeyValidatorModel();

            IDictionary<string, string> data = new Dictionary<string, string>
            {
                { "userName", userName },
                {"Environment", Convert.ToBoolean(objModel.IsProduction) ? "Production" : "Development" }
            };
            return new AuthenticationProperties(data);
        }
    }
}