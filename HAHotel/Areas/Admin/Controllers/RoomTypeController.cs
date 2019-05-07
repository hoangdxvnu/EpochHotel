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
        public ActionResult Edit(RoomType roomType)
        {
            return RedirectToAction("Index");
        }
    }
}