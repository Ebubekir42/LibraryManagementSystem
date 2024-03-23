using Microsoft.AspNetCore.Razor.TagHelpers;
using LMS.Services.Contracts;
using Microsoft.AspNetCore.Mvc.Rendering;
using LMS.Entities.Models;

namespace LMS.App.Infrastructure.TagHelpers
{
    [HtmlTargetElement("tr",Attributes = "book-category")]
    public class BookCategoryTagHelper : TagHelper
    {
        private readonly IServiceManager _manager;
        [HtmlAttributeName("book")]
        public Book? Book { get; set; }
        public BookCategoryTagHelper(IServiceManager manager)
        {
            _manager = manager;
        }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            TagBuilder td = new TagBuilder("td");
            TagBuilder td2 = new TagBuilder("td");
            td.Attributes.Add("class", "text-muted small");
            td.InnerHtml.AppendHtml("Kategori");
            var category = _manager.CategoryService.GetOneCategory(Book.CategoryId,false);
            td2.InnerHtml.AppendHtml(category.CategoryName);
            output.Content.AppendHtml(td);
            output.Content.AppendHtml(td2);
        }
    }
}
