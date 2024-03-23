using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Entities.Dtos
{
    public class UserDtoForUpdate
    {
        public string? Id { get; set; }
        public string? IdentityNumber { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? UserName
        {
            get { return IdentityNumber; }
            set { IdentityNumber = value; }
        }
        public string? Password { get; set; }
        public HashSet<string>? UserRoles { get; set; }
        public HashSet<string> Roles { get; set; }
    }
}
