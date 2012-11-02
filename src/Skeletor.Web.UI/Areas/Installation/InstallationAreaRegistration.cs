﻿using System.Web.Mvc;

namespace Skeletor.Web.UI.Areas.Installation
{
    public class InstallationAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Installation";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Installation_default",
                "Installation/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
