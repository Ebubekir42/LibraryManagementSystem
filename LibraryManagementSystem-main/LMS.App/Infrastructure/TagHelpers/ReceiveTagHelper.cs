using Microsoft.AspNetCore.Razor.TagHelpers;
using LMS.Services.Contracts;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LMS.App.Infrastructure.TagHelpers
{
    [HtmlTargetElement("form",Attributes="receive")]
    public class ReceiveTagHelper : TagHelper
    {
        private readonly IServiceManager _manager;
        public ReceiveTagHelper(IServiceManager maanger)
        {
            _manager = maanger;
        }
        [HtmlAttributeName("receiveId")]
        public int receiveId { get; set; }
        [HtmlAttributeName("loanId")]
        public int loanId { get; set; }
        [HtmlAttributeName("perId")]
        public string? perId { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            TagBuilder input = new TagBuilder("input");
            input.Attributes.Add("type", "hidden");
            input.Attributes.Add("name", "receiveId");
            input.Attributes.Add("value", receiveId.ToString());
            TagBuilder input2 = new TagBuilder("input");
            input2.Attributes.Add("type", "hidden");
            input2.Attributes.Add("name", "loanId");
            input2.Attributes.Add("value", loanId.ToString());

            TagBuilder button = new TagBuilder("button");
            button.Attributes.Add("style", "width:112px; font-size:15px;");
            var receive = _manager.ReceiveService.GetReceive(receiveId, false);
            var loan = _manager.LoanService.GetLoan(loanId, false);

            if (loan.ReturnedDate is null)
            {
                button.Attributes.Add("class", "btn btn-primary");
                button.InnerHtml.AppendHtml("Teslim Al");
            }
            else
            {
                button.Attributes.Add("class", "btn btn-success");
                button.Attributes.Add("disabled", "true");
                button.InnerHtml.AppendHtml("Teslim Alındı");
            }
            output.Content.AppendHtml(input);
            output.Content.AppendHtml(input2);
            output.Content.AppendHtml(button);
        }
    }
}
