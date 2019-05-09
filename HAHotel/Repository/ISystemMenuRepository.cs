using HAHotel.Models;
using System.Collections.Generic;

namespace HAHotel.Repository
{
    public interface ISystemMenuRepository
    {
        List<SystemMenu> GetListRoomType(RoomTypeRequest request);

        SystemMenu GetById(int id);

        bool Save(SystemMenu systemMenu);

        List<SystemSlide> GetListSlides(RoomTypeRequest request);

        SystemSlide GetSlideById(int id);

        bool SaveSlide(SystemSlide systemSlide);


    }
}
