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
            var listType = _menuRepository.GetListRoomType(new RoomTypeRequest());
            SetPageTitle("Quản lý danh sách menu");

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

            return View();
        }

        [HttpPost]
        public ActionResult Edit(SystemMenu systemMenu)
        {
            return RedirectToAction("Index");
        }
    }
}