using System.Web.Mvc;
using HAHotel.Areas.Base;
using HAHotel.Models;
using HAHotel.Repository;

namespace HAHotel.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        private ILayoutRepository _layoutRepository;

        public HomeController(ILayoutRepository layoutRepository)
        {
            _layoutRepository = layoutRepository;
        }

        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Introduction()
        {
            var model = _layoutRepository.LoadDefaultIntroduction();

            return View("Introduction", model);
        }

        [HttpGet]
        public ActionResult EditIntroduction()
        {
            var model = _layoutRepository.LoadDefaultIntroduction();

            return View("Introduction", model);
        }

        [HttpPost]
        public ActionResult EditIntroduction(Introduction introduction)
        {

            return View("Introduction");
        }
    }
}