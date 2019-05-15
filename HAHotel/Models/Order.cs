using System;
using System.ComponentModel.DataAnnotations;

namespace HAHotel.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập tên")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập số điện thoại")]
        public string Phone { get; set; }
        public string Email { get; set; }
        public int RoomId { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Status { get; set; }
        public string Description { get; set; }
    }
}