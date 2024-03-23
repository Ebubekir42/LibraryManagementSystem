using Microsoft.AspNetCore.Mvc;
using LMS.Services.Contracts;
namespace LMS.App.Components
{
    public class ContentTypeViewComponent
    {
        private readonly IServiceManager _manager;
        public ContentTypeViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }
        public string Invoke(int contentTypeId)
        {
            var carrier = _manager.ContentTypeService.GetContentType(contentTypeId, false);
            return carrier.ContentName;
        }
    }
}
