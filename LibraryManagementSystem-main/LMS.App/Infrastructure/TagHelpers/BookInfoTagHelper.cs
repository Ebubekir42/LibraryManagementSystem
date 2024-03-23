using Microsoft.AspNetCore.Razor.TagHelpers;
using LMS.Services.Contracts;
using LMS.Entities.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LMS.App.Infrastructure.TagHelpers
{
    [HtmlTargetElement("tr",Attributes = "book-info")]
    public class BookInfoTagHelper : TagHelper
    {
        private readonly IServiceManager _manager;
        [HtmlAttributeName("book")]
        public Book? book { get; set; }
        public BookInfoTagHelper(IServiceManager manager)
        {
            _manager = manager;
        }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var category = _manager.CategoryService.GetOneCategory(book.CategoryId, false);
            var bookAuthors = _manager.BookAuthorService.GetOneBookAuthorsByBook(book.BookId, false);
            TagBuilder td = new TagBuilder("td");
            TagBuilder td2 = new TagBuilder("td");
            td.Attributes.Add("class", "text-muted small");
            td.InnerHtml.AppendHtml("Yazar");
            string text = "";
            foreach(var bookAuthor in bookAuthors)
            {
                var author = _manager.AuthorService.GetOneAuthor(bookAuthor.AuthorId, false);
                text += author.FullName + ", ";
            }
            text = text.Remove(text.Count() - 2);
            td2.InnerHtml.AppendHtml(text);
            output.Content.AppendHtml(td);
            output.Content.AppendHtml(td2);
        }
    }
}
