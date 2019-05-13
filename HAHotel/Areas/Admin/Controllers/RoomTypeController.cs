using HAHotel.Areas.Base;
using HAHotel.Models;
using HAHotel.Repository;
using System.Web.Mvc;

namespace HAHotel.Areas.Admin.Controllers
{
    public class RoomTypeController : BaseController
    {
        private readonly IRoomTypeRepository _roomTypeRepository;

        public RoomTypeController(IRoomTypeRepository roomTypeRepository)
        {
            _roomTypeRepository = roomTypeRepository;
        }

        public ActionResult Index()
        {
            var listType = _roomTypeRepository.GetListRoomType(new RoomTypeRequest {
                IsActive = -1
            });
            SetPageTitle("Quản lý loại phòng");

            return View(listType);
        }

        public ActionResult Edit()
        {
            if (ItemId > 0)
            {
                var roomType = _roomTypeRepository.GetById(ItemId);
                SetPageTitle("Chỉnh sửa loại phòng");

                return View(roomType);
            }

            SetPageTitle("Tạo mới loại phòng");

            return View(new RoomType());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(RoomType roomType)
        {
            if (roomType == null)
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
                    SetPageTitle("Chỉnh sửa loại phòng");
                }
                else
                {
                    SetPageTitle("Tạo mới loại phòng");
                }
                return View(roomType);
            }

            var message = roomType.RoomTypeId > 0 ? "Cập nhật" : "Thêm";
            if (_roomTypeRepository.Save(roomType))
            {
                SetSuccessNotification($"{message} phòng thành công");
            }
            else
            {
                SetFailedNotification($"{message} loại phòng không thành công. Xin thử lại");
            }

            return RedirectToAction("Index");
        }

        public ActionResult Delete()
        {
            if (ItemId < 0)
            {
                return RedirectToAction("Index");
            }

            _roomTypeRepository.Delete(ItemId);
            SetSuccessNotification("Xóa loại phòng thành công");

            return RedirectToAction("Index");
        }
    }
}