using System.ComponentModel.DataAnnotations;

namespace LMS.App.Models
{
    public class LoginModel
    {
        private String? _returnUrl;
        public String? IdentityNumber { get; set; }
        public String? Password { get; set; }
        public String ReturnUrl
        {
            get
            {
                if (_returnUrl is null)
                    return "/";
                else
                    return _returnUrl;
            }
            set
            {
                _returnUrl = value;
            }
        }
    }
}
