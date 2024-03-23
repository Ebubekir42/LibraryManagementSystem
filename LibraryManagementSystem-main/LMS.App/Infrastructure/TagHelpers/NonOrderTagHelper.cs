using Microsoft.AspNetCore.Razor.TagHelpers;
using LMS.Services.Contracts;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LMS.App.Infrastructure.TagHelpers
{
    [HtmlTargetElement("form",Attributes = "nonOrder")]
    public class NonOrderTagHelper : TagHelper
    {
        private readonly IServiceManager _manager;
        public NonOrderTagHelper(IServiceManager manager)
        {
            _manager = manager;
        }
        [HtmlAttributeName("nonOrderId")]
        public int orderId { get; set; }
        [HtmlAttributeName("perId")]
        public string perId { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            TagBuilder input = new TagBuilder("input");
            input.Attributes.Add("type", "hidden");
            input.Attributes.Add("name", "orderId");
            input.Attributes.Add("value", orderId.ToString());

            TagBuilder button = new TagBuilder("button");
            button.Attributes.Add("style", "width:112px; font-size:15px;");
            var order = _manager.NonOrderService.GetNonOrder(orderId, false);
            if (order.ApplicationUserId is null)
            {
                button.Attributes.Add("class", "btn btn-primary");
                //if (!order.ApplicationUserId.Equals(perId))
                //    button.Attributes.Add("disabled", "true");
                button.InnerHtml.AppendHtml("Teslim Et");
            }
            else
            {
                button.Attributes.Add("class", "btn btn-success");
                button.Attributes.Add("disabled", "true");
                button.InnerHtml.AppendHtml("Teslim Edildi");
            }
            output.Content.AppendHtml(input);
            output.Content.AppendHtml(button);
        }
    }
}
