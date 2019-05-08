using System;
using System.ComponentModel.DataAnnotations;

namespace HAHotel.Models
{
    public class SystemMenu
    {
        public int MenuItemId { get; set; }
        [Required(ErrorMessage = "Bạn cần nhập tên menu")]
        public string MenuItemName { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Alias { get; set; }
        [Required(ErrorMessage = "Bạn cần nhập số thứ tự")]
        public int OrderItem { get; set; }
        [Required(ErrorMessage = "Bạn cần chọn ảnh")]
        public string UrlImage { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}