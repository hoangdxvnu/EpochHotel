using System.Web.Mvc;
using HAHotel.Repository;

namespace HAHotel.Controllers
{
    public class NewsController: BaseController
    {
        private readonly INewsRepository _newsRepository;

        public NewsController(ILayoutRepository layoutRepository, INewsRepository newsRepository) : base(layoutRepository)
        {
            this._newsRepository = newsRepository;
        }

        public ActionResult Index()
        {
            SetCurrentMenu();
            var news = _newsRepository.GetListNew(new Models.RoomTypeRequest {
                PageIndex = PageIndex,
                PageSize = 5
            });
            news.PageSize = 5;
            news.BaseUrl = Url.Action("Index", "News");
            news.CurrentPage = PageIndex;

            return View(news);
        }
    }
}