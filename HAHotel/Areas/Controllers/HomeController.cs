using System.Web.Mvc;
using HAHotel.Repository;

namespace HAHotel.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILayoutRepository _layoutRepository;

        public HomeController(ILayoutRepository layoutRepository):base(layoutRepository)
        {
            _layoutRepository = layoutRepository;
        }

        public ActionResult Index()
        {
            SetCurrentMenu();
            
            return View();
        }

        public ActionResult About()
        {
            SetCurrentMenu();

            var model = LayoutRepository.LoadDefaultIntroduction();

            return View(model);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}