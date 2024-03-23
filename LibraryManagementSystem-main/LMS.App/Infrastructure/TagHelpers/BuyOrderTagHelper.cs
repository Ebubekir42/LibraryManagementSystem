using Microsoft.AspNetCore.Razor.TagHelpers;
using LMS.Services.Contracts;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace LMS.App.Infrastructure.TagHelpers
{
    [HtmlTargetElement("form", Attributes = "buyOrder")]

    public class BuyOrderTagHelper : TagHelper
    {
        private readonly IServiceManager _manager;
        public BuyOrderTagHelper(IServiceManager manager)
        {
            _manager = manager;
        }
        [HtmlAttributeName("orderId")]
        public int orderId { get; set; }
        [HtmlAttributeName("kuryeId")]
        public string kuryeId { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            TagBuilder input = new TagBuilder("input");
            input.Attributes.Add("type", "hidden");
            input.Attributes.Add("name", "buyId");
            input.Attributes.Add("value", orderId.ToString());

            TagBuilder button = new TagBuilder("button");
            button.Attributes.Add("style", "width:112px; font-size:15px;");
            button.Attributes.Add("type", "submit");

            var order = _manager.OrderService.GetOrder(orderId, false);
            if(order.ApplicationUserId is null)
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
            output.Content.AppendHtml(button);
        }
    }
}
