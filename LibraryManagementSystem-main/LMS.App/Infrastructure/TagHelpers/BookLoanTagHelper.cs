using Microsoft.AspNetCore.Razor.TagHelpers;
using LMS.Entities.Models;
using LMS.Services.Contracts;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LMS.App.Infrastructure.TagHelpers
{
    [HtmlTargetElement("tr",Attributes = "book-loan")]
    public class BookLoanTagHelper : TagHelper
    {
        private readonly IServiceManager _manager;
        public BookLoanTagHelper(IServiceManager manager)
        {
            _manager = manager;
        }
        [HtmlAttributeName("book")]
        public Book? Book { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            TagBuilder td = new TagBuilder("td");
            TagBuilder td2 = new TagBuilder("td");
            td.Attributes.Add("class", "text-muted small");
            td.InnerHtml.AppendHtml("Durum");
            td2.Attributes.Add("class", "text-info rafta__");
      
            var loan = _manager.LoanService.IsInLibraryTheBookByBook(Book.BookId);
            if (loan is not null)
                td2.InnerHtml.AppendHtml("Rafta Değil");
            else
                td2.InnerHtml.AppendHtml("Rafta");
            output.Content.AppendHtml(td);
            output.Content.AppendHtml(td2);
        }
    }
}
