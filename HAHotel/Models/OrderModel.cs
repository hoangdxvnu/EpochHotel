using System.Collections.Generic;

namespace HAHotel.Models
{
    public class OrderModel
    {
        public Footer Footer { get; set; }

        public Order Order { get; set; }

        public IEnumerable<RoomType> RoomTypes { get; set; }
    }
}