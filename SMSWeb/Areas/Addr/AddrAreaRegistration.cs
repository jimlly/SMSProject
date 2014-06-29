using System.Web.Mvc;

namespace SMSWeb.Areas.Addr
{
    public class AddrAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Addr";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Addr_default",
                "Addr/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
