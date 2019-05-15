using System;
using System.Web.Mvc;
using HAHotel.Models;
using HAHotel.Repository;

namespace HAHotel.Controllers
{
    public class ServiceController: BaseController
    {
        private readonly IOrderRepository _orderRepository;

        public ServiceController(ILayoutRepository layoutRepository, IOrderRepository orderRepository) : base(layoutRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            SetCurrentMenu();

            var model = new OrderModel
            {
                RoomTypes = LayoutRepository.FetchRoomTypes(),
                Order = new Order
                {
                    CheckIn = DateTime.UtcNow,
                    CheckOut = DateTime.UtcNow.AddDays(1)
                },
                Footer = LayoutRepository.LoadFooterDefaul()
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(OrderModel model)
        {
            SetCurrentMenu();

            if (ModelState.IsValid)
            {
                var result = _orderRepository.Saving(model.Order);

                if (result)
                {
                    SetSuccessMessage("Bạn vừa đặt phòng thành công. Chúng tôi sẽ liên hệ lại ngay với bạn sớm nhất.");
                }
                else
                {
                    AddFailedMessage("Đã có lỗi xảy ra xin vui lòng thử lại.");
                }
            }
            else
            {
                foreach (var item in ModelState.Values)
                {
                    foreach (var error in item.Errors)
                    {
                        SetFailedNotification(error.ErrorMessage);
                    }
                }
            }

            model.RoomTypes = LayoutRepository.FetchRoomTypes();

            model.Footer = LayoutRepository.LoadFooterDefaul();

            return View(model);
        }

        [HttpPost]
        public ActionResult Booking(Order order)
        {
            SetCurrentMenu();

            var model = new OrderModel
            {
                RoomTypes = LayoutRepository.FetchRoomTypes(),
                Order = order,
                Footer = LayoutRepository.LoadFooterDefaul()
            };

            return View("Index", model);
        }
    }
}