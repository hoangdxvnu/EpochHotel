using System.Web.Mvc;
using HAHotel.Areas.Base;
using HAHotel.Models;
using HAHotel.Repository;

namespace HAHotel.Areas.Admin.Controllers
{
    public class AdminNewsController : BaseController
    {
        private INewsRepository _newsRepository;

        public AdminNewsController(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        // GET: Admin/AdminNews
        public ActionResult Index()
        {
            var model = _newsRepository.GetListNew(new RoomTypeRequest
            {
                IsActive = -1,
                PageIndex = PageIndex,
                PageSize = 10,
                Keyword= Keyword
            });
            model.PageSize = 2;
            model.CurrentPage = PageIndex;
            model.BaseUrl = Url.Action("Index", "AdminNews", new { Area = "Admin" });
            model.Keyword = Keyword;

            SetPageTitle("Quản lý bài viết");

            return View(model);
        }

        public ActionResult Edit()
        {
            if (ItemId > 0)
            {
                var model = _newsRepository.GetById(ItemId);
                SetPageTitle("Sửa bài viết");

                return View(model);
            }

            SetPageTitle("Tạo mới bài viết");

            return View(new News());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(News newModel)
        {
            if (newModel == null)
            {
                SetFailedNotification("Có lỗi xảy ra. Vui lòng thử lại");
                return RedirectToAction("Index");
            }

            if (!ModelState.IsValid)
            {
                foreach (var item in ModelState.Values)
                {
                    foreach (var error in item.Errors)
                    {
                        SetFailedNotification(error.ErrorMessage);
                    }
                }
                if (ItemId > 0)
                {
                    SetPageTitle("Sửa bài viết");
                }
                else
                {
                    SetPageTitle("Tạo mới bài viết");
                }
                return View(newModel);
            }

            if (_newsRepository.Save(newModel))
            {
                SetSuccessNotification("Cập nhật bài viết thành công");
            }
            else
            {
                SetFailedNotification("Đã có lỗi xảy ra. Xin vui lòng thử lại");
            }

            return RedirectToAction("Index");
        }
    }
}