using System.Web.Http;
using WebActivatorEx;
using MusicService;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace MusicService
{
    /// <summary>
    /// Class configuration for Swagger.
    /// </summary>
    public class SwaggerConfig
    {
        /// <summary>
        /// Run the configuration.
        /// </summary>
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.PrettyPrint();
                        c.SingleApiVersion("v1", "MusicService")
                           .Description("A sample Web Service API for an AngularJS client");
                           //.Contact(cc => cc
                           //    .Name("Giulianno Sbrugnera")
                           //    .Url("https://github.com/giuliannosbrugnera/music-service")
                           //    .Email("giulianno.sbrugnera@gmail.com"))
                           //.License(lc => lc
                           //    .Name("MIT License")
                           //    .Url("https://opensource.org/licenses/MIT"));
                        c.IncludeXmlComments(GetXmlCommentsPath());
                    })
                .EnableSwaggerUi();
        }

        protected static string GetXmlCommentsPath()
        {
            return System.String.Format(@"{0}\bin\Documentation.XML", System.AppDomain.CurrentDomain.BaseDirectory);
        }
    }
}
