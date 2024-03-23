using Microsoft.AspNetCore.Mvc;
using LMS.Services.Contracts;

namespace LMS.App.Components
{
    public class MediaTypeViewComponent : ViewComponent
    {
        private readonly IServiceManager _manager;
        public MediaTypeViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }
        public string Invoke(int carrierTypeId)
        {
            var carrier = _manager.CarrierTypeService.GetCarrierType(carrierTypeId, false);
            var media = _manager.MediaTypeService.GetMediaType(carrier.MediaTypeId, false);
            return media.MediaName;
        }
    }
}
