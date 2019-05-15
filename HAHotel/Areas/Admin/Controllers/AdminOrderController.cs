using System.Web.Mvc;
using HAHotel.Areas.Base;
using HAHotel.Models;
using HAHotel.Repository;

namespace HAHotel.Areas.Admin.Controllers
{
    public class AdminOrderController : BaseController
    {
        private readonly IOrderRepository _orderRepository;

        public AdminOrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
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

            return View(models);
        }
    }
}