using System.Web.Mvc;
using HAHotel.Areas.Base;
using HAHotel.Models;
using HAHotel.Repository;

namespace HAHotel.Areas.Admin.Controllers
{
    public class MenuController : BaseController
    {
        private readonly ISystemMenuRepository _menuRepository;

        public MenuController(ISystemMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        // GET: Admin/Menu
        public ActionResult Index()
        {
            var listType = _menuRepository.GetListRoomType(new RoomTypeRequest
            {
                IsActive = -1
            });
            SetPageTitle("Quản lý menu");

            return View(listType);
        }

        public ActionResult Edit()
        {
            if (ItemId > 0)
            {
                var roomType = _menuRepository.GetById(ItemId);
                SetPageTitle("Chỉnh sửa menu");

                return View(roomType);
            }

            SetPageTitle("Tạo mới menu");

            return View(new SystemMenu());
        }

        [HttpPost]
        public ActionResult Edit(SystemMenu systemMenu)
        {
            if (systemMenu == null)
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
                    SetPageTitle("Chỉnh sửa menu");
                }
                else
                {
                    SetPageTitle("Tạo mới menu");
                }
                return View(systemMenu);
            }

            if (_menuRepository.Save(systemMenu))
            {
                SetSuccessNotification("Thêm loại phòng thành công");
            }
            else
            {
                SetFailedNotification("Thêm loại phòng không thành công. Xin thử lại");
            }

            return RedirectToAction("Index");
        }
    }
}