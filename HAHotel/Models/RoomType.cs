using System.ComponentModel.DataAnnotations;

namespace HAHotel.Models
{
    public class RoomType
    {
        public int RoomTypeId { get; set; }
        [Required]
        [Display(Name ="Tên loại phòng")]
        public string TypeName { get; set; }
        [Display(Name = "Ảnh đại diện")]
        public string UrlImage { get; set; }
        [Display(Name = "Hoạt động")]
        public bool IsActive { get; set; }
    }
}