using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace HAHotel.Models
{
    public class GridModel<T>
    {
        public List<T> Data { get; set; }

        public int TotalRecord { get; set; }

        public string BaseUrl { get; set; }

        public int CurrentPage { get; set; }

        public int PageSize { get; set; }

        public string GeneratePagination(string additionalClassname = "{additionalClassname}")
        {
            var pageNumber = TotalRecord % PageSize == 0 ? TotalRecord / PageSize : TotalRecord / PageSize + 1;
            var builder = new StringBuilder();
            builder.Append("<div class='dataTables_paginate paging_simple_numbers' id='dataTables-example_paginate'>");
            builder.Append("<ul class='pagination'>");
            builder.Append($"<li class=\"{additionalClassname} previous {(CurrentPage == 1 ? "disabled" : "")}\" id=\"dataTables - example_previous\">");
            builder.Append($"<a href=\"{BaseUrl}?p={(CurrentPage - 1 > 0 ? CurrentPage -1 : 0)}\" aria-controls=\"dataTables-example\" data-dt-idx=\"0\" tabindex=\"0\">Previous</a>");
            builder.Append("</li>");
            for (int i = 1; i <= pageNumber; i++)
            {
                builder.Append($"<li class=\"{additionalClassname} {(CurrentPage == i ? "active" : "")}\" id=\"dataTables - example_previous\">");
                builder.Append($"<a href=\"{BaseUrl + "?p=" + i}\" aria-controls=\"dataTables-example\" data-dt-idx=\"{i}\" tabindex=\"0\">{i}</a>");
                builder.Append("</li>");
            }
            builder.Append($"<li class=\"{additionalClassname} next {(CurrentPage == pageNumber ? "disabled" : "")}\" id=\"dataTables - example_previous\">");
            builder.Append($"<a href=\"{BaseUrl}?p={(CurrentPage < pageNumber ? CurrentPage  + 1 : pageNumber)}\" aria-controls=\"dataTables-example\" data-dt-idx=\"0\" tabindex=\"0\">Next</a>");
            builder.Append("</li>");
            builder.Append("</ul>");
            builder.Append("</div>");

            return builder.ToString();

        }
    }
}