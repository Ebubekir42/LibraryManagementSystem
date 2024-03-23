using Microsoft.AspNetCore.Mvc;
using LMS.Services.Contracts;
namespace LMS.App.Components
{
    public class CarrierTypeViewComponent : ViewComponent
    {
        private readonly IServiceManager _manager;
        public CarrierTypeViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }
        public string Invoke(int carrierTypeId)
        {
            var carrier = _manager.CarrierTypeService.GetCarrierType(carrierTypeId, false);
            return carrier.CarrierName;
        }
    }
}
