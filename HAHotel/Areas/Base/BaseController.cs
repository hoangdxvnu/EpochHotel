using HAHotel.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace HAHotel.Areas.Base
{
    public class BaseController : Controller
    {
        public Account AccountInfo { get; set; }

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
            HandleAuthendication();
            if (AccountInfo == null && !filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true))
            {
                filterContext.Result = new RedirectResult(Url.Action("Index", "Login", new { Area = "Admin" }));
                return;
            }

            HandleMessages();
        }

        private void HandleAuthendication()
        {
            var sessionData = HttpContext.Session[Constants.AccountSessionKey]?.ToString();
            if (string.IsNullOrEmpty(sessionData))
            {
                AccountInfo = null;

                return;
            }
            AccountInfo = JsonConvert.DeserializeObject<Account>(sessionData);
        }

        private void HandleMessages()
        {
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
            ViewBag.FailedMessage += $"<p>{msg}</p>";
        }

        protected void SetPageTitle(string title)
        {
            ViewBag.PageTitle = title;
        }

        protected void SetAccountSession(Account account)
        {
            HttpContext.Session.Add(Constants.AccountSessionKey, JsonConvert.SerializeObject(account));
        }
    }
}