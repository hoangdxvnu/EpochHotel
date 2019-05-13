using HAHotel.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HAHotel.Models
{
    public class Account
    {
        public int AccountId { get; set; }

        [Required(ErrorMessage = "Bạn cần nhập tên đăng nhập")]
        [Display(Name ="Tên đăng nhập")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Bạn cần nhập password")]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }

        public DateTime CreatedDate { get; set; }

        public AccountTypeEnum AccountType { get; set; }
    }
}