using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HAHotel.Models
{
    public class RoomTypeRequest
    {
        public int IsActive { get; set; }

        public int PageSize { get; set; }

        public int PageIndex { get; set; }
    }
}