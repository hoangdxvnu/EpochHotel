using System.ComponentModel.DataAnnotations;

namespace HAHotel.Models
{
    public class Introduction
    {
        [Required(ErrorMessage = "Bạn bắt buộc phải nhập thông tin")]
        public string MainContent { get; set; }
    }
}