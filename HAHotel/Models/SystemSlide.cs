namespace HAHotel.Models
{
    public class SystemSlide
    {
        public int SlideId { get; set; }
        public string SlideName { get; set; }
        public string LinkUrl { get; set; }
        public string UrlImage { get; set; }
        public int OrderItem { get; set; }
        public bool IsActive { get; set; }
    }
}