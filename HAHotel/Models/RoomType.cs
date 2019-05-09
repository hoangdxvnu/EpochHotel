using System.ComponentModel.DataAnnotations;

namespace HAHotel.Models
{
    public class RoomType
    {
        public int RoomTypeId { get; set; }
        [Required(ErrorMessage = "Bạn cần nhập tên loại phòng")]
        [Display(Name = "Tên loại phòng")]
        public string TypeName { get; set; }
        [Display(Name = "Ảnh đại diện")]
        public string UrlImage { get; set; }
        [Display(Name = "Hoạt động")]
        public bool IsActive { get; set; }

        [Display(Name = "Giá phòng")]
        public double Price { get; set; }

        [Display(Name = "Phòng Hot")]
        public bool IsHot { get; set; }

        [Display(Name = "Mô tả")]
        public string Description { get; set; }

    }
}