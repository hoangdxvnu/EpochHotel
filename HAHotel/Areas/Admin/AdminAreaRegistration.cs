using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HAHotel.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
            "Admin",
            "Admin/{controller}/{action}/{id}",
            new { area = $"{AreaName}", controller = "Home",action = "Index", id = UrlParameter.Optional },
            new[] { "HAHotel.Areas.Admin.Controllers" });
        }
    }
}