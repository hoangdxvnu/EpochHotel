using System;

namespace HAHotel.Models
{
    public class Reviews
    {
        public string Description { get; set; }
        public string CustomerName { get; set; }
        public string MarketCustomer { get; set; }
        public string UrlImage { get; set; }
        public bool IsActive { get; set; }
        public int LangId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public int CreatedBy { get; set; }
    }
}