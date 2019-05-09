using System.ComponentModel.DataAnnotations;

namespace HAHotel.Models
{
    public class Footer
    {
        public int FooterId { get; set; }

        [Display(Name = "Tiêu đề")]
        [Required(ErrorMessage = "Bạn phải nhập tiêu đề")]
        public string TitleFooter { get; set; }

        [Display(Name = "Địa chỉ")]
        [Required(ErrorMessage = "Bạn phải nhập địa chỉ")]
        public string Address { get; set; }

        [Display(Name = "Số điện thoại")]
        [Required(ErrorMessage = "Bạn phải nhập số điện thoại")]
        public string Phone { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Bạn phải nhập email")]
        public string Email { get; set; }

        [Display(Name = "Facebook")]
        public string Facebook { get; set; }

        [Display(Name = "Twifter")]
        public string Twifter { get; set; }

        [Display(Name = "Youtube")]
        public string Youtube { get; set; }

        [Display(Name = "Google")]
        public string Google { get; set; }
    }
}