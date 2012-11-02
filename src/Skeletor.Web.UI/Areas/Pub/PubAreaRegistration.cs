using System.Web.Mvc;

namespace Skeletor.Web.UI.Areas.Pub
{
    public class PubAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Pub";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Pub_default",
                "{controller}/{action}/{id}",
                new { controller="Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
