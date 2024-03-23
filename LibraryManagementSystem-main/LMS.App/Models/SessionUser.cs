using LMS.Entities.Models;
using LMS.App.Infrastructure.Extensions;
using System.Text.Json.Serialization;

namespace LMS.App.Models
{
    public class SessionUser : ApplicationUser 
    {
        [JsonIgnore]
        public ISession Session { get; set; }
        public static ApplicationUser GetUser(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>().HttpContext.Session;
            SessionUser user = session.GetJson<SessionUser>("user") ?? new SessionUser();
            return user;
        }
    }
}
