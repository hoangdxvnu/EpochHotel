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

            return View("EditIntroduction", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult EditIntroduction(Introduction introduction)
        {
            if (introduction == null)
            {
                SetFailedNotification("Có lỗi xảy ra. Vui lòng thử lại");
                return RedirectToAction("Index");
            }

            if (!ModelState.IsValid)
            {
                foreach (var item in ModelState.Values)
                {
                    SetFailedNotification(item.Value.ToString());
                }
                return View("EditIntroduction", introduction);
            }

            if (_layoutRepository.SaveIntroduction(introduction))
            {
                SetSuccessNotification("Cập nhật thông tin công ty thành công");
            }
            else
            {
                SetFailedNotification("Cập nhật thông tin không thành công. Xin thử lại");
            }

            return RedirectToAction("Introduction", "Home");
        }

        public ActionResult EditFooter()
        {
            SetPageTitle("Cấu hình footer");

            var model = _layoutRepository.LoadFooterDefaul();

            return View("EditFooter", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult EditFooter(Footer footer)
        {
            SetPageTitle("Cấu hình footer");

            if (footer == null)
            {
                SetFailedNotification("Có lỗi xảy ra. Vui lòng thử lại");
                return RedirectToAction("Index");
            }

            if (!ModelState.IsValid)
            {
                foreach (var item in ModelState.Values)
                {
                    SetFailedNotification(item.Value.ToString());
                }
                return View(footer);
            }

            if (_layoutRepository.SaveFooter(footer))
            {
                SetSuccessNotification("Cập nhật thông tin footer thành công");
            }
            else
            {
                SetFailedNotification("Cập nhật thông tin footer thành công. Xin thử lại");
            }

            return RedirectToAction("EditFooter", "Home");
        }
    }
}