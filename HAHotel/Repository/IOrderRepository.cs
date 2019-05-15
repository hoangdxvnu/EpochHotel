using HAHotel.Models;

namespace HAHotel.Repository
{
    public interface IOrderRepository
    {
        bool Saving(Order order);
    }
}
