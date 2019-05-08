using HAHotel.Areas.Base;
using HAHotel.Models;
using HAHotel.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            var listType = _roomTypeRepository.GetListRoomType(new RoomTypeRequest());
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

            return View();
        }

        [HttpPost]
        public ActionResult Edit(RoomType roomType, HttpPostedFileBase image)
        {
            if (roomType == null || image == null)
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
                return RedirectToAction("Index");
            }

            var imageFolderPath = "/images";
            SaveFile(image, $"~{imageFolderPath}");
            roomType.UrlImage = imageFolderPath + image.FileName;
            if (_roomTypeRepository.Save(roomType))
            {
                SetSuccessNotification("Thêm loại phòng thành công");
            }
            else
            {
                SetFailedNotification("Thêm loại phòng không thành công. Xin thử lại");
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