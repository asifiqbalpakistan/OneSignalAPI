using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace AG_OneSignalAPI
{
    public static class WebApiConfig
    {
        //public const string URL_APPS = "https://onesignal.com/api/v1/apps"; // DO NOT TOUCH THIS 
        
        //public const string API_KEY = "MDM4MzI4ZTMtYjI4ZS00YzA0LThiZDYtNGE1YTMxZDc3MjQ0";

        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
