using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using ProductStore.Models;

namespace ProductStore.Infrastructured
{
    [HtmlTargetElement("span", Attributes = "model , category-id")]
    public class CategoryTagHelper:TagHelper
    {
        public IEnumerable<Categories> Model { get; set; }
        public int CategoryId { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var Category = from m in Model.ToList() where m.CategoryID == CategoryId select m;
            output.Attributes.SetAttribute("style","float:right");
            output.Content.Append(Category.FirstOrDefault().CategoryName);
            switch (CategoryId)
            {
                case 1:
                    output.Attributes.SetAttribute("class", $"badge-pill badge-primary");
                    break;
                case 2:
                    output.Attributes.SetAttribute("class", $"badge-pill badge-success");
                    break;
                case 3:
                    output.Attributes.SetAttribute("class", $"badge-pill badge-success");
                    break;
                case 4:
                    output.Attributes.SetAttribute("class", $"badge-pill badge-dark");
                    break;
                case 5:
                    output.Attributes.SetAttribute("class", $"badge-pill badge-danger");
                    break;
                case 6:
                    output.Attributes.SetAttribute("class", $"badge-pill badge-warning");
                    break;
                case 7:
                    output.Attributes.SetAttribute("class", $"badge-pill badge-info");
                    break;
                case 8:
                    output.Attributes.SetAttribute("class", $"badge-pill badge-warning");
                    break;
            }

        }
    }
}
