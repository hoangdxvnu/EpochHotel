using System;
using System.Web.Mvc;
using HAHotel.Areas.Base;
using HAHotel.Models;
using HAHotel.Repository;

namespace HAHotel.Areas.Admin.Controllers
{
    public class AdminOrderController : BaseController
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IRoomTypeRepository _roomTypeRepository;

        public AdminOrderController(IOrderRepository orderRepository, IRoomTypeRepository roomTypeRepository)
        {
            _orderRepository = orderRepository;
            _roomTypeRepository = roomTypeRepository;
        }

        // GET: Admin/AdminOrder
        public ActionResult Index()
        {
            var models = _orderRepository.FetchListOrder(new RoomTypeRequest
            {
                PageIndex = 1,
                PageSize = 20,
                IsActive = 1
            });

            ViewBag.ListRoom = _roomTypeRepository.GetListRoomType(new RoomTypeRequest
            {
                IsActive = 1,
                PageSize = 20,
                PageIndex = 1
            });

            SetPageTitle("Quản lý đặt phòng");

            return View(models);
        }

        // GET: Admin/AdminOrder
        public ActionResult History()
        {
            var models = _orderRepository.FetchListOrder(new RoomTypeRequest
            {
                PageIndex = 1,
                PageSize = 20,
                IsActive = 1,
                Status = 1
            });

            ViewBag.ListRoom = _roomTypeRepository.GetListRoomType(new RoomTypeRequest
            {
                IsActive = 1,
                PageSize = 20,
                PageIndex = 1
            });

            SetPageTitle("Quản lý đặt phòng đã xử lý");

            return View(models);
        }

        public ActionResult Edit()
        {
            if (ItemId > 0)
            {
                var order = _orderRepository.GetOrderById(ItemId);
                SetPageTitle("Chỉnh sửa loại phòng");

                return View(order);
            }

            SetPageTitle("Cập nhật đặt phòng");

            return View(new Order());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(Order order)
        {
            if (order == null)
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

                if (order.OrderId > 0)
                {
                    order.CreatedAt = DateTime.Now;
                    order.CheckIn = DateTime.Now;
                    order.CheckOut = DateTime.Now;

                    SetPageTitle("Chỉnh sửa loại phòng");
                }
                else
                {
                    SetPageTitle("Tạo mới loại phòng");
                }

                return View(order);
            }

            var message = order.OrderId > 0 ? "Cập nhật" : "Thêm";

            if (order.OrderId > 0)
            {
                order.CreatedAt = DateTime.Now;
                order.CheckIn = DateTime.Now;
                order.CheckOut = DateTime.Now;
            }

            if (_orderRepository.Saving(order))
            {
                SetSuccessNotification($"{message} phòng thành công");
            }
            else
            {
                SetFailedNotification($"{message} loại phòng không thành công. Xin thử lại");
            }

            return RedirectToAction("Index");
        }
    }
}