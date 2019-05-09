using System.Web.Mvc;
using HAHotel.Areas.Base;
using HAHotel.Models;
using HAHotel.Repository;

namespace HAHotel.Areas.Admin.Controllers
{
    public class SystemSlideController : BaseController
    {
        private readonly ISystemMenuRepository _systemMenuRepository;

        public SystemSlideController(ISystemMenuRepository systemMenuRepository)
        {
            _systemMenuRepository = systemMenuRepository;
        }

        // GET: Admin/SystemSlide
        public ActionResult Index()
        {
            var model = _systemMenuRepository.GetListSlides(new RoomTypeRequest());
            return View(model);
        }

        public ActionResult Edit()
        {
            if (ItemId > 0)
            {
                var model = _systemMenuRepository.GetSlideById(ItemId);
                SetPageTitle("Sửa slide");

                return View(model);
            }

            SetPageTitle("Tạo mới slide");

            return View(new SystemSlide());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(SystemSlide systemSlide)
        {
            if (systemSlide == null)
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
                return View(systemSlide);
            }

            if (_systemMenuRepository.SaveSlide(systemSlide))
            {
                SetSuccessNotification("Cập nhật slide thành công");
            }
            else
            {
                SetFailedNotification("Đã có lỗi xảy ra. Xin vui lòng thử lại");
            }

            return RedirectToAction("Index");
        }
    }
}