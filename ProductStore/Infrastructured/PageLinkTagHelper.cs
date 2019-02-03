using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using ProductStore.Models.ViewModels;

namespace ProductStore.Infrastructured
{
    [HtmlTargetElement("div",ParentTag = "body",Attributes = "product-list")]
    public class PageLinkTagHelper:TagHelper
    {
        private readonly IUrlHelperFactory _factory;

        public PageLinkTagHelper(IUrlHelperFactory factory)
        {
            _factory = factory;
        }
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }

        public ProductList ProductList { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper helper = _factory.GetUrlHelper(ViewContext);
            TagBuilder div = new TagBuilder("div");
            div.Attributes["style"]="margin:1%";
            for (int i = 1; i <= ProductList.PageInfo.TotalPages; i++)
            {
                TagBuilder a = new TagBuilder("a");
                a.Attributes["href"] = helper.Action(ViewContext.RouteData.Values["action"].ToString() , new {productPage = i});
                a.Attributes["style"] = "padding:5px 15px";
                a.Attributes["class"] = ProductList.PageInfo.ProductPage.Equals(i) ? "badge-pill badge-primary": "badge-pill badge-secondary"; 
                a.InnerHtml.Append(i.ToString());
                div.InnerHtml.AppendHtml(a);            
            }
            output.PostContent.AppendHtml(div);
        }
    }
}
