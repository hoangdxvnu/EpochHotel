using System.Web.Mvc;
using HAHotel.Repository;

namespace HAHotel.Controllers
{
    public class RoomController: BaseController
    {
        private readonly IRoomTypeRepository _roomTypeRepository;

        public RoomController(ILayoutRepository layoutRepository, IRoomTypeRepository roomTypeRepository) : base(layoutRepository)
        {
            _roomTypeRepository = roomTypeRepository;
        }

        public ActionResult Index()
        {
            SetCurrentMenu();
            return View();
        }

        public ActionResult Detail(int roomId)
        {
            var model = _roomTypeRepository.GetById(roomId);
            return View(model);
        }
    }
}