using LMS.App.Infrastructure.Extensions;
using LMS.Entities.Models;
using System.Text.Json.Serialization;

namespace LMS.App.Models
{
    public class SessionBook : Book
    {
        [JsonIgnore]
        public ISession Session { get; set; }
        public static Book GetBook(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>().HttpContext.Session;
            SessionBook book = session.GetJson<SessionBook>("book") ?? new SessionBook();
            book.Session = session;
            return book;
        }
    }
}
