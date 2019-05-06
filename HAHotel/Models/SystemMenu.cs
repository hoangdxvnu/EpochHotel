using System;

namespace HAHotel.Models
{
    public class SystemMenu
    {
        public int MenuItemId { get; set; }
        public string MenuItemName { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Alias { get; set; }
        public int OrderItem { get; set; }
        public string UrlImage { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}