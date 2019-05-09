using HAHotel.Models;
using System.Collections.Generic;

namespace HAHotel.Repository
{
    public interface INewsRepository
    {
        List<News> GetListNew(RoomTypeRequest request);

        News GetById(int id);

        bool Save(News newModel);
    }
}
