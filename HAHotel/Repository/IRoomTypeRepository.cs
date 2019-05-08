using HAHotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAHotel.Repository
{
    public interface IRoomTypeRepository
    {
        List<RoomType> GetListRoomType(RoomTypeRequest request);

        RoomType GetById(int id);

        bool Save(RoomType roomType);

        bool Delete(int id);
    }
}
