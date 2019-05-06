using System.Web.Mvc;
using HAHotel.Repository;

namespace HAHotel.Controllers
{
    public class MenuController: BaseController
    {
        public MenuController(ILayoutRepository layoutRepository):base(layoutRepository)
        {
        }

        public ActionResult MenuItem()
        {
            var model = LayoutRepository.FetchMenuItems();

            return PartialView("_Menu", model);
        }

        public ActionResult SectionRoom()
        {
            var model = LayoutRepository.FetchRoomTypes();

            return PartialView("_SectionRoomType", model);
        }

        public ActionResult Slide()
        {
            var model = LayoutRepository.FetchListSlides();

            return PartialView("_Slide", model);
        }

        public ActionResult HotNews()
        {
            var model = LayoutRepository.GetTopNews(4);

            return PartialView("_HotNews", model);
        }

        public ActionResult Reviews()
        {
            var model = LayoutRepository.FetchTopCustomer(3);

            return PartialView("_Reviews", model);
        }

        public ActionResult Footer()
        {
            var model = LayoutRepository.LoadFooterDefaul();

            return PartialView("_Footer", model);
        }
    }
}