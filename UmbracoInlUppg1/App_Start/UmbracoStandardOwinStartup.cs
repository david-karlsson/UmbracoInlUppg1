using Microsoft.Owin;
using Owin;
using System.Configuration;
using Umbraco.Web;
using UmbracoInlUppg1;

//To use this startup class, change the appSetting value in the web.config called 
// "owin:appStartup" to be "UmbracoStandardOwinStartup"

[assembly: OwinStartup("UmbracoStandardOwinStartup", typeof(UmbracoStandardOwinStartup))]

namespace UmbracoInlUppg1
{
    /// <summary>
    /// A standard way to configure OWIN for Umbraco
    /// </summary>
    /// <remarks>
    /// The startup type is specified in appSettings under owin:appStartup - change it to "UmbracoStandardOwinStartup" to use this class.
    /// </remarks>
    public class UmbracoStandardOwinStartup : UmbracoDefaultOwinStartup
    {
        /// <summary>
        /// Configures the back office authentication for Umbraco
        /// </summary>
        /// <param name="app"></param>
        protected override void ConfigureUmbracoAuthentication(IAppBuilder app)
        {
            // Must call the base implementation to configure the default back office authentication config.
            base.ConfigureUmbracoAuthentication(app);


            var clientId = ConfigurationManager.AppSettings["GoogleOAuthClientID"];

            var secret = ConfigurationManager.AppSettings["GoogleOAuthSecret"];

            app.ConfigureBackOfficeGoogleAuth(clientId, secret);

            /* 
            * Configure external logins for the back office:
            * 
            * Depending on the authentication sources you would like to enable, you will need to install 
            * certain Nuget packages. 
            * 
            * For Google auth:					    Install-Package UmbracoCms.IdentityExtensions.Google
            * For Facebook auth:					Install-Package UmbracoCms.IdentityExtensions.Facebook
            * For Azure ActiveDirectory auth:		Install-Package UmbracoCms.IdentityExtensions.AzureActiveDirectory
            * 
            * There are many more providers such as Twitter, Yahoo, ActiveDirectory, etc... most information can
            * be found here: http://www.asp.net/web-api/overview/security/external-authentication-services
            * 
            * For sample code on using external providers with the Umbraco back office, install one of the 
            * packages listed above to review it's code samples 
            *  
            */

            /*
             * To configure a simple auth token server for the back office:
             *             
             * By default the CORS policy is to allow all requests
             * 
             *      app.UseUmbracoBackOfficeTokenAuth(new BackOfficeAuthServerProviderOptions());
             *      
             * If you want to have a custom CORS policy for the token server you can provide
             * a custom CORS policy, example: 
             * 
             *      app.UseUmbracoBackOfficeTokenAuth(
             *          new BackOfficeAuthServerProviderOptions()
             *              {
             *             		//Modify the CorsPolicy as required
             *                  CorsPolicy = new CorsPolicy()
             *                  {
             *                      AllowAnyHeader = true,
             *                      AllowAnyMethod = true,
             *                      Origins = { "http://mywebsite.com" }                
             *                  }
             *              });
             */
        }
    }
}
