using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Skeletor.Web.UI.Infrastructure.MVC
{
    /// <summary>
    /// Resolve views based on the following convention:
    ///     ~\AreaName\ModuleName\ControllerName
    /// http://stackoverflow.com/questions/632964/can-i-specify-a-custom-location-to-search-for-views-in-asp-net-mvc
    /// </summary>
    public class SkeletorViewEngine : RazorViewEngine
    {

        public SkeletorViewEngine()
        {
            var viewLocations = new[] {  
            "~/Views/{1}/{0}.aspx",  
            "~/Views/{1}/{0}.ascx",  
            "~/Views/Shared/{0}.aspx",  
            "~/Views/Shared/{0}.ascx",  
            "~/Admin/Views/Shared/{0}.ascx",  
            "~/Setup/Views/Shared/{0}.ascx",  
            "~/AnotherPath/Views/{0}.ascx"
            // etc
        };

            this.PartialViewLocationFormats = viewLocations;
            this.ViewLocationFormats = viewLocations;
        }

    }
}