using System.Web.Mvc;
using HAHotel.Repository;

namespace HAHotel.Controllers
{
    public class ServiceController: BaseController
    {
        public ServiceController(ILayoutRepository layoutRepository) : base(layoutRepository)
        {
            
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = LayoutRepository.LoadFooterDefaul();
            SetCurrentMenu();
            ViewBag.ListRooms = LayoutRepository.FetchRoomTypes();

            return View(model);
        }
    }
}