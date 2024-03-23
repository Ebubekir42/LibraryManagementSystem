using Microsoft.AspNetCore.Mvc;
using LMS.Services.Contracts;
namespace LMS.App.Components
{
    public class FormatViewComponent
    {
        private readonly IServiceManager _manager;
        public FormatViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }
        public string Invoke(int formatId)
        {
            var carrier = _manager.FormatService.GetFormat(formatId, false);
            return carrier.FormatName;
        }
    }
}
