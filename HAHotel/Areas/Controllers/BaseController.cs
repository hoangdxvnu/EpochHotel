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
    }
}