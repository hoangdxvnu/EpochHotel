using System.Web.Mvc;
using HAHotel.Repository;

namespace HAHotel.Controllers
{
    public class ContactController: BaseController
    {
        public ContactController(ILayoutRepository layoutRepository):base(layoutRepository)
        {
        }

        public ActionResult Index()
        {
            var model = LayoutRepository.LoadFooterDefaul();
            SetCurrentMenu();
            return View(model);
        }
    }
}