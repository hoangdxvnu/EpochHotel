using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HAHotel.Models
{
    public class News
    {
        public int NewsId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string MainContent { get; set; }
        public bool IsHot { get; set; }
        public int OrderItem { get; set; }
        public string TitleSeo { get; set; }
        public string UrlImage { get; set; }
        public bool IsActive { get; set; }
        public int LangId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
    }
}