using Microsoft.AspNetCore.Mvc;
using LMS.Services.Contracts;
namespace LMS.App.Components
{
    public class LanguageViewComponent
    {
        private readonly IServiceManager _manager;
        public LanguageViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }
        public string Invoke(int languageId)
        {
            var carrier = _manager.LanguageService.GetLanguage(languageId, false);
            return carrier.Name;
        }
    }
}
