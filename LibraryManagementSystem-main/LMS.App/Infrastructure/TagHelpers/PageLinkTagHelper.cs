using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using LMS.App.Models;
using Microsoft.AspNetCore.Mvc;

namespace LMS.App.Infrastructure.TagHelpers
{
    [HtmlTargetElement("div",Attributes = "page-model")]
    public class PageLinkTagHelper : TagHelper
    {
        private readonly IUrlHelperFactory _urlHelperFactory;
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext? ViewContext { get; set; }
        public Pagination PageModel { get; set; }
        public String? PageAction { get; set; }
        public bool PageClassesEnabled { get; set; } = false;
        public string PageClass { get; set; } = string.Empty;
        public string PageClassNormal { get; set; } = string.Empty;
        public string PageClassSelected { get; set; } = string.Empty;
        public String CategoryId { get; set; } = String.Empty;
        public PageLinkTagHelper(IUrlHelperFactory urlHelperFactory)
        {
            _urlHelperFactory = urlHelperFactory;
        }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (ViewContext is not null && PageModel is not null)
            {
                IUrlHelper urlHelper = _urlHelperFactory.GetUrlHelper(ViewContext);
                TagBuilder div = new TagBuilder("div");
                for (int i = 1; i <= PageModel.TotalPages; i++)
                {
                    TagBuilder _a = new TagBuilder("a");
                    _a.Attributes["href"] = urlHelper.Action(PageAction, new { PageNumber = i,categoryId = CategoryId });
                    if (PageClassesEnabled)
                    {
                        _a.AddCssClass(PageClass);
                        _a.AddCssClass(i == PageModel.CurrentPage ? PageClassSelected : PageClassNormal);
                    }
                    _a.InnerHtml.Append(i.ToString());
                    div.InnerHtml.AppendHtml(_a);
                }
                output.Content.AppendHtml(div.InnerHtml);
            }
        }
    }
}
