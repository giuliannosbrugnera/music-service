using System.Web.Http;
using WebActivatorEx;
using MusicService;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace MusicService
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "MusicService");
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
