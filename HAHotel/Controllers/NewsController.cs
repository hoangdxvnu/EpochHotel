using System.Web.Mvc;
using HAHotel.Repository;

namespace HAHotel.Controllers
{
    public class NewsController: BaseController
    {

        public NewsController(ILayoutRepository layoutRepository) : base(layoutRepository)
        {
            
        }

        public ActionResult Index()
        {
            SetCurrentMenu();

            return View();
        }
    }
}