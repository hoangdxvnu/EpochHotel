using System.Web.Mvc;
using HAHotel.Repository;

namespace HAHotel.Controllers
{
    public class RoomController: BaseController
    {
        public RoomController(ILayoutRepository layoutRepository) : base(layoutRepository)
        {
            
        }

        public ActionResult Index()
        {
            SetCurrentMenu();
            return View();
        }
    }
}