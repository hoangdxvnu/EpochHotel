using System;
using System.ComponentModel.DataAnnotations;

namespace HAHotel.Models
{
    public class News
    {
        public int NewId { get; set; }
        [Display(Name = "Tiêu đề")]
        [Required(ErrorMessage = "Bạn phải nhập tiêu đều")]
        [MaxLength(512, ErrorMessage = "Tiêu đề không được quá 512 ký tự")]
        public string Title { get; set; }
        [Display(Name = "Mô tả ngắn gọn")]
        [Required(ErrorMessage = "Bạn phải nhập mô tả bài viết")]
        public string Description { get; set; }

        [Display(Name = "Nội dung chính")]
        public string MainContent { get; set; }

        [Display(Name = "Tin Hot")]
        public bool IsHot { get; set; }
        [Required(ErrorMessage = "Bạn phải chọn thứ tự sắp xếp khi là tin Hot")]

        [Display(Name = "Thứ tự sắp xếp tin Hot")]
        public int OrderItem { get; set; }

        [Display(Name = "Tiêu đề SEO")]
        [Required(ErrorMessage = "Bạn phải nhập tiêu đều cho Seo")]
        public string TitleSeo { get; set; }

        [Display(Name = "Ảnh đại diện")]
        [Required(ErrorMessage = "Bạn phải chọn ảnh đại diện cho bài viết")]
        public string UrlImage { get; set; }

        [Display(Name = "Hiển thị")]
        public bool IsActive { get; set; }
        public int LangId { get; set; } 
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
    }
}