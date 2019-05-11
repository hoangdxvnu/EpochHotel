using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HAHotel.Models
{
    public class Contact
    {
        [Required(ErrorMessage = "Bạn cần nhập tên")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Bạn cần nhập số điện thoại")]
        [RegularExpression(@"^0[0-9]{9,10}$", ErrorMessage ="Sai định dạng điện thoại")]
        public string Phone { get; set; }

        [RegularExpression(@"^[a-z][a-z0-9_\.]{5,32}@[a-z0-9]{2,}(\.[a-z0-9]{2,4}){1,2}$", ErrorMessage = "Sai định dạng email")]
        public string Email { get; set; }

        public string Content { get; set; }

        public int Id { get; set; }
    }
}