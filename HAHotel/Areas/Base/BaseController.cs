using System;
using System.Collections.Generic;
using System.IO;
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
                if (HttpContext.Request.QueryString != null && HttpContext.Request.QueryString["p"] != null)
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

        public List<string> ErrorMessages { get; set; } = new List<string>();

        public void SetSuccessNotification(string msg)
        {
            TempData["SuccessMessage"] = msg;
        }

        public void SetFailedNotification(List<string> msg)
        {
            TempData["FailedMessage"] = msg;
        }

        public void SetFailedNotification(string msg)
        {
            if (TempData["FailedMessage"] == null)
            {
                TempData["FailedMessage"] = new List<string> { msg };
            }
            else
            {
                ((List<string>)TempData["FailedMessage"]).Add(msg);
            }
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (TempData["SuccessMessage"] != null && !string.IsNullOrEmpty(TempData["SuccessMessage"].ToString()))
            {
                SetSuccessMessage(TempData["SuccessMessage"].ToString());
            }

            var errorMessages = (List<string>)TempData["FailedMessage"];
            if (errorMessages != null && errorMessages.Any())
            {
                foreach (var item in errorMessages)
                    AddFailedMessage(item);
            }
        }

        protected void SetSuccessMessage(string msg)
        {
            ViewBag.SuccessMessage = msg;
        }

        protected void AddFailedMessage(string msg)
        {
            if (ViewBag.FailedMessage == null)
                ViewBag.FailedMessage = string.Empty;
            ViewBag.FailedMessage += msg;
        }

        protected void SetPageTitle(string title)
        {
            ViewBag.PageTitle = title;
        }
    }
}