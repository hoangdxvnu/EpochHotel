using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HAHotel.Areas.Base
{
    public class BaseController : Controller
    {
        public int PageIndex
        {
            get
            {
                if(HttpContext.Request.QueryString != null && HttpContext.Request.QueryString["p"] != null)
                {
                    return int.Parse(HttpContext.Request.QueryString["p"]);
                }

                return 1;
            }
        }

        public int ItemId
        {
            get
            {
                if (HttpContext.Request.QueryString != null && HttpContext.Request.QueryString["itemId"] != null)
                {
                    return int.Parse(HttpContext.Request.QueryString["itemId"]);
                }

                return 0;
            }
        }

        protected void SetSuccessMessage(string msg)
        {
            ViewBag.SuccessMessage = msg;
        }

        protected void SetFailedMessage(string msg)
        {
            ViewBag.FailedMessage = msg;
        }

        protected void SetPageTitle(string title)
        {
            ViewBag.PageTitle = title;
        }
    }
}