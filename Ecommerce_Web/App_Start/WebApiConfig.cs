using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;

namespace Ecommerce_Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();



      

          
            config.Routes.MapHttpRoute("DefaultApiWithId", "api/{controller}/{id}", new { id = RouteParameter.Optional }, new { id = @"\d+" });
           config.Routes.MapHttpRoute("DefaultApiWithAction", "api/{controller}/{action}");
            config.Routes.MapHttpRoute("DefaultApiGet", "api/{controller}", new { action = "Get" }, new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) });
            config.Routes.MapHttpRoute("DefaultApiPost", "api/{controller}", new { action = "Post" }, new { httpMethod = new HttpMethodConstraint(HttpMethod.Post) });

            //JSON.NET formatter: data -> json
            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}
