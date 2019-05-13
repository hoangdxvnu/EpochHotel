using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using HAHotel.Models;
using HAHotel.Repository;

namespace HAHotel.Controllers
{
    public class BaseController : Controller
    {
        protected ILayoutRepository LayoutRepository;

        public BaseController(ILayoutRepository layoutRepository)
        {
            LayoutRepository = layoutRepository;
        }

        public void SetCurrentMenu()
        {
            var model = LayoutRepository.LoadFooterDefaul();
            ViewBag.CurrentMenu = CurrentMenu;
        }

        public SystemMenu CurrentMenu
        {
            get
            {
                var menus = LayoutRepository.FetchMenuItems();

               return menus?.FirstOrDefault(x =>
                    (x.Controller.ToLower() ==
                    this.ControllerContext.RouteData.Values["controller"].ToString().ToLower())
                    && (x.Action.ToLower() ==
                   this.ControllerContext.RouteData.Values["action"].ToString().ToLower())) ?? null;
            }
        }

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
            ViewBag.FailedMessage += $"<p>{msg}</p>";
        }
    }
}