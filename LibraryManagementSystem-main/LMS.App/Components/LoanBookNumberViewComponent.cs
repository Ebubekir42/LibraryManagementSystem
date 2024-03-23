using Microsoft.AspNetCore.Mvc;
using LMS.Services.Contracts;
namespace LMS.App.Components
{
    public class LoanBookNumberViewComponent : ViewComponent
    {
        private readonly IServiceManager _manager;
        public LoanBookNumberViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }
        public string Invoke()
        {
            return _manager.LoanService.GetAllLoans(false).Count().ToString();
        }
    }
}
