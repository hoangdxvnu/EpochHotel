using System.Collections.Generic;
using HAHotel.Models;

namespace HAHotel.Repository
{
    public interface ILayoutRepository
    {
        IEnumerable<SystemMenu> FetchMenuItems();

        IEnumerable<RoomType> FetchRoomTypes();

        IEnumerable<SystemSlide> FetchListSlides();

        IEnumerable<News> GetTopNews(int top);

        IEnumerable<Reviews> FetchTopCustomer(int top);

        Footer LoadFooterDefaul();

        Introduction LoadDefaultIntroduction();
    }
}