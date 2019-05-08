using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HAHotel.Areas.Base;

namespace HAHotel.Areas.Admin.Controllers
{
    public class IntroductionController : BaseController
    {
        // GET: Admin/Introduction
        public ActionResult Index()
        {
            return View();
        }
    }
}