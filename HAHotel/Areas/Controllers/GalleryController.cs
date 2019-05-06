using System.Web.Mvc;
using HAHotel.Repository;

namespace HAHotel.Controllers
{
    public class GalleryController: BaseController
    {
        public GalleryController(ILayoutRepository layoutRepository) : base(layoutRepository)
        {
            
        }

        public ActionResult Index()
        {
            SetCurrentMenu();

            return View();
        }
    }
}