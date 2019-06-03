using System.Collections.Generic;
using HAHotel.Models;

namespace HAHotel.Repository
{
    public interface IOrderRepository
    {
        bool Saving(Order order);

        List<Order> FetchListOrder(RoomTypeRequest request);

        Order GetOrderById(int id);
    }
}
